using Application.Abstractions.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

public class AuthenticationController(IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult SignUp()
    {
        return View(new SignUpViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignUp(SignUpViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        TempData["Email"] = model.Email;
        return RedirectToAction("SetPassword");
    }

    [HttpGet]
    public IActionResult SetPassword()
    {
        var model = new SetPasswordViewModel
        {
            Email = TempData["Email"]?.ToString() ?? ""
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (!model.AcceptTerms)
        {
            ModelState.AddModelError("AcceptTerms", "You must accept the terms");
            return View(model);
        }

        var result = await authService.SignUpUserAsync(model.Email, model.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View(model);
        }

        return RedirectToAction("SignIn");
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View(new SignInViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.SignInUserAsync(model.Email, model.Password, model.RememberMe);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View(model);
        }

        return RedirectToAction("Index", "MyAccount");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public new async Task<IActionResult> SignOut()
    {
        await authService.SignOutUserAsync();
        return RedirectToAction("Index", "Home");
    }
}