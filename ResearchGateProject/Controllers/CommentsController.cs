using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResearchGateProject.Data;
using ResearchGateProject.Data.Services;
using ResearchGateProject.Data.Static;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGate.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CommentsController : Controller
    {
        private static string paperid;
        private readonly ICommentService _service;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentsController(ICommentService service, AppDbContext context , UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _service = service;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var Comments = GetComment();
            return View(Comments);
        }

        public IEnumerable<Comment> GetComment()
        {
            var allComments = _context.Comments;
            return allComments;
        }

        [HttpGet]
        public IActionResult Create(string Id)
        {
            paperid = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, NewCommentVM comment)
        {
            if (!ModelState.IsValid) return View(comment);
            var NewComment = await SetComment(id, comment);
            await _service.AddNewCommentAsync(NewComment);
            return RedirectToAction("Details", "Paper", new { id = paperid });
        }

        public async Task<NewCommentVM> SetComment(string id, NewCommentVM comment)
        {
            var comments = _context.Comments.ToList();
            var NewId = comments.Count + 1;
            var AutherId = _userManager.GetUserId(User);
            comment.Id = NewId.ToString();
            comment.PaperId = paperid;
            comment.ApplicationUserId = AutherId;

            return comment;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var commentDetails = await _service.GetByIdAsync(id);
            if (commentDetails == null) return View("NotFound");
            return View(commentDetails);
        }
     
       
    }
}
