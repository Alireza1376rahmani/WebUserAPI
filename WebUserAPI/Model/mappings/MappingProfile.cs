using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessParty, PartyDto>().ConvertUsing(party => new PartyDto
            {
                Id = party.Id,
                Type = "business",
                Name = party.Name,
                LastName = null,
                NationalNumber = party.NationalId
            });
            CreateMap<IndividualParty, PartyDto>().ConvertUsing(party => new PartyDto
            {
                Id = party.Id,
                Type = "individual",
                Name = party.Name,
                LastName = party.LastName,
                NationalNumber = party.NationalCode
            });

            CreateMap<Party, PartyDto>().ConvertUsing(party => new PartyDto
            {
                Id = party.Id,
                Name = party.Name
            }) ;

            CreateMap<PartyDto, PutPartyCommand>();
            CreateMap<String, Party>();
        }
    }
}
