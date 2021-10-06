using System.Collections.Generic;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public interface IPrincipalService
    {
        void CreatePrincipal(CreatePrincipalCommand command);
        void DeletePrincipal(DeletePrincipalCommand command);
        List<Principal> GetAllPrincipals();
        User GetPrincipalById(ReadPrincipalCommand command);
        void UpdatePrincipal(UpdatePrincipalCommand command);
    }
}