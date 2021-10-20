using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Model.mappings;

namespace WebUserAPI.Services
{
    public class PrincipalService : IPrincipalService
    {
        protected readonly IRepository<Principal> repository;
        protected readonly IRepository<Party> partyRepo;

        public PrincipalService(IRepository<Principal> repository, IRepository<Party> partyRepo)
        {
            this.repository = repository;
            this.partyRepo = partyRepo;
        }

        public Guid CreatePrincipal(Model.CreatePrincipalCommand command)
        {
            Principal principal;
            var guid = Guid.NewGuid();
            if (command.Type == "user")
                principal = new User(guid, command.Name);
            else
                principal = new Group(guid, command.Name);

            foreach (Guid id in command.Groups ?? new List<Guid>())
            {
                var group = repository.GetById<Group>(id);
                principal.AddGroup(group);
            }

            repository.Create(principal);
            repository.Save();
            return guid;
        }
        public void UpdatePrincipal(Model.PatchPrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            principal.UpdateName(command.Name);
            repository.Update(principal);
            repository.Save();
        }
        public List<Model.Principal> GetAllPrincipals()
        {
            return repository.GetAll().Select<Principal,Model.Principal>(x=>mapPrincipal(x,true)).ToList();
        }
        public Model.Principal GetPrincipalById(Model.ReadPrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            return mapPrincipal(principal, true);
        }
        private Model.Principal mapPrincipal(Principal principal, bool needMapGroups)
        {
            var modelpParty = new PartyDto();
            if(principal.PartyId != null)
                modelpParty=  PartyService.mapPartyToPartyDto(principal.Party); // HERE
            return new Model.Principal
            {
                Type = getPrincipalType(principal),
                Id = principal.Id,
                Name = principal.Name,
                Groups = needMapGroups ? principal.Memberships.Select(g => mapMembership(g)).ToList() : new List<Model.Membership>(),
                Party = modelpParty
            };
        }
        private string getPrincipalType(Principal principal)
        {
            if (principal is User) return "user";
            return "group";
        }
        private Model.Membership mapMembership(Membership g)
        {
            return new Model.Membership { GroupId = g.GroupId, JoinDate = g.JoinDate };
        }
        public void DeletePrincipal(Model.DeletePrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            repository.Delete(principal);
            repository.Save();
        }
        public void PrincipalJoinsToGroup(Model.PatchPrincipalCommand command)
        {
            var thePrincipal = repository.GetById<User>(command.Id);
            var theGroup = repository.GetById<Group>(command.GroupId);

            thePrincipal.AddGroup(theGroup);

            repository.Update(thePrincipal);
            repository.Save();
        }
        public void PrincipalLeavesGroup(Model.PatchPrincipalCommand command)
        {
            var thePrincipal = repository.GetById<Principal>(command.Id);
            var theGroup = repository.GetById<Group>(command.GroupId);

            thePrincipal.RemoveGroup(theGroup);

            repository.Update(thePrincipal);
            repository.Save();
        }

        public void AssignParty(Model.PatchPrincipalCommand command)
        {
            var principal = repository.GetById<Principal>(command.Id);
            var party = partyRepo.GetById<Party>(command.PartyId);

            principal.AssignParty(party);

            repository.Update(principal);
            repository.Save();
        }
    }
}
