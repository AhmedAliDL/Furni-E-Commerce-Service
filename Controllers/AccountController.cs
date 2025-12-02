using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                var userAccount = new UserAccountViewModel
                {
                    FName = user.FName,
                    LName = user.LName,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Address = user.Address,
                    Country = user.Country,
                    City = user.City

                };
                return View(userAccount);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                User user = new()
                {
                    FName = registerViewModel.FName,
                    LName = registerViewModel.LName,
                    Email = registerViewModel.Email,
                    PasswordHash = registerViewModel.Password,
                    PhoneNumber = registerViewModel.Phone,
                    Address = registerViewModel.Address,
                    UserName = registerViewModel.Email,
                    Country = registerViewModel.Country,
                    City = registerViewModel.City
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
            }
            ModelState.AddModelError("", "Data is wrong!");
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    var verifyPassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (verifyPassword)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Index", "Home");

                    }
                    ModelState.AddModelError("Password", "Password isn`t correct");
                }
                ModelState.AddModelError("Email", "Email isn`t found");
            }
            ModelState.AddModelError("", "Data is wrong!");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAccount()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                var userAccount = new UserEditAccountViewModel
                {
                    FName = user.FName,
                    LName = user.LName,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Address = user.Address,
                    Country = user.Country,
                    City = user.City
                };
                return View(userAccount);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditAccount(UserEditAccountViewModel userEditAccountViewModel)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {

                user.FName = userEditAccountViewModel.FName ?? user.FName;
                user.LName = userEditAccountViewModel.LName ?? user.LName;
                user.PhoneNumber = userEditAccountViewModel.Phone ?? user.PhoneNumber;
                user.Email = userEditAccountViewModel.Email ?? user.Email;
                user.Country = userEditAccountViewModel.Country ?? user.Country;
                user.City = userEditAccountViewModel.City ?? user.City;
                user.Address = userEditAccountViewModel.Address ?? user.Address;
                if (!string.IsNullOrWhiteSpace(userEditAccountViewModel.OldPassword) && !string.IsNullOrWhiteSpace(userEditAccountViewModel.Password))
                {
                    IdentityResult changePasswordResult;

                    changePasswordResult = await _userManager.ChangePasswordAsync(user, userEditAccountViewModel.OldPassword, userEditAccountViewModel.Password);


                    if (!changePasswordResult.Succeeded)
                    {
                        foreach (var error in changePasswordResult.Errors)
                        {
                            ModelState.AddModelError("OldPassword", error.Description);
                        }
                        return View(userEditAccountViewModel);
                    }
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
    }
}
