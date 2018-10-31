using EpioneWeb.Models;
using EpioneWeb.CustomLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace EpioneWeb.Controllers
{
   
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth

        [HttpGet]
        public ActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }

            //Checks whether the input is the same as those literals. Note: Never ever do this! This is just to demo the validation while we're not yet doing any database interaction
            if (model.Email == "admin@admin.com" && model.Password == "123456")
            {
                var identity = new ClaimsIdentity(new[] {
 new Claim(ClaimTypes.Name, "Fatma"),
 new Claim(ClaimTypes.Email, "fatma.essafi@esprit.tn"),
 new Claim(ClaimTypes.Country, "Tunisie")
    }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Email or Password");
            return View(model); //Should always be declared on the end of an action method
        }

        

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Users model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MainDbContext())
                {
                    var encryptedPassword = CustomEnrypt.Encrypt(model.Password);
                    var user = db.Users.Create();
                    user.Email = model.Email;
                    user.Password = encryptedPassword;
                    user.Cin = model.Cin;
                    user.LastName = model.LastName;
                    user.FirstName = model.FirstName;
                    user.Gender = model.Gender;
                    user.BirthDate = model.BirthDate;
                    user.HomeAddress = model.HomeAddress;
                    user.Phone = model.Phone;
                    user.CivilStatus = model.CivilStatus;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more fields have been");
            }
            return View();
        }

    }
}