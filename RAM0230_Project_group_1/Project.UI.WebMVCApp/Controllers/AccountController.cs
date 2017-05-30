using Microsoft.Owin.Security;
using Project.Domain.Core;
using Project.Domain.Repository;
using Project.UI.WebMVCApp.Models.AuthViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork uow;
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public AccountController(IUnitOfWork uow) { this.uow = uow; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = uow.Users.FindUser(u => u.Login.Equals(model.Login) && u.Password.Equals(model.Password));
                if (user == null) { ModelState.AddModelError("", "Неверный логин или пароль."); }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));
                    if (user.Role != null) { claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name, ClaimValueTypes.String)); }

                    AuthenticationManager.SignOut();

                    AuthenticationProperties properties = new AuthenticationProperties { IsPersistent = true };
                    AuthenticationManager.SignIn(properties, claim);

                    return RedirectToAction("Index", "Visits");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}