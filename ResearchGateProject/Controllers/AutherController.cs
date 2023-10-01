using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchGateProject.Data;
using ResearchGateProject.Data.Services;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Controllers
{
    public class AutherController : Controller
    {
        private readonly IApplicationUsersService _service;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public AutherController(UserManager<ApplicationUser> userManager, AppDbContext context, IApplicationUsersService service)
        {
            _userManager = userManager;
            _context = context;
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AuthersList = GetAuthers().ToList();
            return View(AuthersList);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var FilteredAuther = FilterAuthers(searchString);
            return View("Index", FilteredAuther);
        }
        
        
        [AllowAnonymous]
        public async Task<IActionResult> ShowProfile()
        {
            var Id =  _userManager.GetUserId(User);
            var user =GetAuthers().Single(User => User.Id == Id);            
            return View(user);
        }
       

        [AllowAnonymous]
        public async Task<IActionResult> ShowAutherInformation(string id)
        {
            var autherInfomation = await _service.GetAuthersByIdAsync(id);
            var papers = GetPapers().ToList();
            Paper_comentsVM AuthersPapers = new Paper_comentsVM
            {
                User = autherInfomation,
                papers = papers               
            };

            return View(AuthersPapers);
        }

        
        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {
            var AutherDetails = await _service.GetByIdAsync(id);
            if (AutherDetails == null) return View("NotFound");
            return View(AutherDetails);
            
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string id, ApplicationUser user)
        {
            var User = await _context.Users.SingleAsync(User => User.Id == id);

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            User.ProfilePictureURL = user.ProfilePictureURL;
            User.FirstName = user.FirstName;
            User.LastName = user.LastName;
            User.Uni = user.Uni;
            User.Dept = user.Dept;
            User.Email = user.Email;           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowProfile));
        }

         
        public IEnumerable<ApplicationUser> FilterAuthers(String searchString)
        {
            var AuthersList = GetAuthers().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredAuthers = AuthersList.Where(n => string.Equals(n.FirstName, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Uni, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Email, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return filteredAuthers;
            }

            return AuthersList;

        }

        public IEnumerable<ApplicationUser> GetAuthers()
        {
            var allAuthers = _context.ApplicationUsers;
            return allAuthers;
        }

        public IEnumerable<Paper> GetPapers()
        {
            var papers = _context.Papers;
            return papers;
        }

    }
}
