using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Home_Service.Models;
using Home_Service.ViewModel;
using Home_Service;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

public class LoginController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly HomeServiceDB _context;

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, HomeServiceDB context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager= signInManager;
        _context = context;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userExist = await _userManager.FindByEmailAsync(model.Email);

            if (userExist == null)
            {
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.UserName, // You can use email as the username if needed
                    Gender = model.Gender,
                    Age = model.Age,
                    Role = model.Role,
                    Status = model.Status,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    
                    await _userManager.AddToRoleAsync(user, model.Role.ToString());
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User with this email already exists");
            }
        }   
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }   
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // You can use the email as the username for login
            var SignedUser = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(SignedUser.UserName, model.Password,false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Service");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
        }
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            // Log or print the error message
            var errorMessage = error.ErrorMessage;
            // Handle the error as needed
        }
        return View(model);
    }

}
