using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Features.Auth.Commands;
using Products.Features.Auth.Commands.Queries;
using Products.Models.Auth;
using System.Security.Claims;

namespace Products.Controllers;

public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: Auth/Login
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Product");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST: Auth/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var command = new LoginUserCommand
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            };

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Muvaffaqiyatli kirildi!";
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hisobingiz vaqtincha bloklangan. Keyinroq urinib ko'ring.");
            }
            else if (result.RequiresTwoFactor)
            {
                // 2FA implementatsiyasi uchun
                ModelState.AddModelError("", "Ikki bosqichli autentifikatsiya talab qilinadi.");
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Kirish muvaffaqiyatsiz");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi: " + ex.Message);
        }

        return View(model);
    }

    // GET: Auth/Register
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Product");
        }
        return View();
    }

    // POST: Auth/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            // Email mavjudligini tekshirish
            var emailExists = await _mediator.Send(new CheckUserEmailExistsQuery { Email = model.Email });
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Bu email bilan foydalanuvchi allaqachon ro'yxatdan o'tgan");
                return View(model);
            }

            var command = new RegisterUserCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Ro'yxatdan o'tish muvaffaqiyatli! Endi tizimga kirishingiz mumkin.";
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi: " + ex.Message);
        }

        return View(model);
    }

    // POST: Auth/Logout
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutUserCommand());
        TempData["SuccessMessage"] = "Tizimdan muvaffaqiyatli chiqildi";
        return RedirectToAction(nameof(Login));
    }

    // GET: Auth/Profile
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction(nameof(Login));
        }

        var userProfile = await _mediator.Send(new GetCurrentUserQuery { UserId = userId });
        if (userProfile == null)
        {
            return NotFound();
        }

        return View(userProfile);
    }

    // GET: Auth/ChangePassword
    [Authorize]
    public IActionResult ChangePassword()
    {
        return View();
    }

    // POST: Auth/ChangePassword
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction(nameof(Login));
            }

            var command = new ChangePasswordCommand
            {
                UserId = userId,
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword
            };

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Parol muvaffaqiyatli o'zgartirildi";
                return RedirectToAction(nameof(Profile));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Xatolik yuz berdi: " + ex.Message);
        }

        return View(model);
    }

    // GET: Auth/AccessDenied
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    #region Helper Methods

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Index", "Product");
        }
    }

    #endregion
}
