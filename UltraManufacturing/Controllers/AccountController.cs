using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UltraManufacturing.Models;
using UltraManufacturing.Models.ViewModels;
using MailKit.Net.Smtp;
using MimeKit;
using UltraManufacturing.Services;
using Microsoft.Extensions.Options;

namespace UltraManufacturing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UMAuthentication _emAuth;
        public AccountController(UMAuthentication emAuth)
        {
            _emAuth = emAuth;
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLogin model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var loggedIn = _emAuth.SignIn(model.Email, model.Password);
                if (loggedIn)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            _emAuth.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
