using ResearchGateProject.Data;
using ResearchGateProject.Data.Static;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ResearchGateProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var usersList = await _context.Users.ToListAsync();
            return View(usersList);
        }


       
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var cheackUser = await CheackUser(loginVM);
            if (!(cheackUser))
            {
                TempData["Error"] = "Wrong Email. Please, try again!";
                return View(loginVM);
            }           
            return RedirectToAction("Index", "Paper");
        }
      

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                PhoneNumber = registerVM.Mobile,
                Uni = registerVM.Uni,
                Dept = registerVM.Dept,
                Email = registerVM.Email, 
                ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                UserName = registerVM.Email,
                NormalizedEmail = registerVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<bool> CheackUser(LoginVM loginVM)
        {
            var user = await _context.ApplicationUsers.SingleAsync(c => c.Email == loginVM.EmailAddress);
            var CheachkPass = await CheackPassword(user, loginVM);            
            if (!(CheachkPass)) return false;
            return true;

        }

        public async Task<bool> CheackPassword(ApplicationUser user, LoginVM loginVM)
        {           
            var ReasultAction =await CheackedResult(user, loginVM);
            if (!(ReasultAction))
            {
                return false;

            }
            return true;

        }

        public async Task<bool> CheackedResult(ApplicationUser user, LoginVM loginVM)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);           
            return result.Succeeded;
        }
    }
}
