using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Home_Service.Models;
using Home_Service.ViewModel;
using Home_Service;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System.Security.Claims;

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
        _signInManager = signInManager;
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
                    UserName = model.UserName,
                    Gender = model.Gender,
                    Age = model.Age,
                    Status = model.Status,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };
                // Check if the role exists, and create it if not
                var roleExists = await _roleManager.RoleExistsAsync(model.Role.ToString());
                if (!roleExists)
                {
                    var role = new IdentityRole(model.Role.ToString());
                    await _roleManager.CreateAsync(role);
                }

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
            var signedUser = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Retrieve the user
                var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);

                // Retrieve user roles
                var roles = await _userManager.GetRolesAsync(user);

                // Now, 'roles' contains the roles associated with the user

                // Add user ID as a claim
                await _signInManager.UserManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id));

                // Redirect to the appropriate action
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
