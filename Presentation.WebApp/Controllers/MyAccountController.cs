using Application.Abstractions.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;
using System.Security.Claims;

namespace Presentation.WebApp.Controllers;

[Authorize]
public class MyAccountController(IAccountService accountService, IAuthService authService) : Controller
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await accountService.GetUserAccountAsync(UserId);
        if (!result.Succeeded)
            return RedirectToAction("Index", "Home");

        var model = new MyAccountViewModel
        {
            UserId = result.Details!.UserId,
            Email = result.Details.Email,
            FirstName = result.Details.FirstName,
            LastName = result.Details.LastName,
            PhoneNumber = result.Details.PhoneNumber
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(MyAccountViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var result = await accountService.UpdateUserAccountDetailsAsync(new(
            UserId: UserId,
            FirstName: model.FirstName,
            LastName: model.LastName,
            PhoneNumber: model.PhoneNumber
        ));

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View("Index", model);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete()
    {
        var result = await accountService.DeleteUserAccountAsync(UserId);
        if (!result.Succeeded)
            return RedirectToAction("Index");

        await authService.SignOutUserAsync();
        return RedirectToAction("Index", "Home");
    }
}