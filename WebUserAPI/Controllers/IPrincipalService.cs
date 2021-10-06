using System.Collections.Generic;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    public interface IPrincipalService
    {
        void CreatePrincipal(ICreate command);
        void DeletePrincipal(IDelete command);
        List<User> GetAllPrincipals();
        User GetPrincipalById(IRead command);
        void UpdatePrincipal(IUpdate command);
    }
}