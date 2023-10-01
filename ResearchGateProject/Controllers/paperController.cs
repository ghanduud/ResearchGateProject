using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResearchGateProject.Data;
using ResearchGateProject.Data.Services;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using ResearchGateProject.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class paperController : Controller
    {

               
        private static string paperid;
        private readonly IPapersService _service;
        private readonly ICommentService _CommentService;      
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public paperController(UserManager<ApplicationUser> userManager, AppDbContext context, IPapersService service , ICommentService CommentService )
        {
            _userManager = userManager;
            _context = context;
            _service = service;
            _CommentService = CommentService;
           
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Cinemas/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //await
            var PaperDropdownsData = await _service.GetNewPaperDropdownsValues();        
            ViewBag.ApplicationUsers = new SelectList(PaperDropdownsData.ApplicationUsers, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPaperVM paper)
        {
            if (!ModelState.IsValid)
            {
                var PaperDropdownsData = await _service.GetNewPaperDropdownsValues();

                ViewBag.ApplicationUsers = new SelectList(PaperDropdownsData.ApplicationUsers, "Id", "FirstName");

                return View(paper);
            }
            var papersList = Getpaper().ToList();
            var NewId = papersList.Count + 1;
            paper.Id = NewId.ToString();
            await _service.AddNewPaperAsync(paper);
            return RedirectToAction("Index");
        }

        public IEnumerable<Paper> Getpaper()
        {
            var allPapers = _context.Papers;
            return allPapers;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var PaperDetail = await _service.GetPaperByIdAsync(id);
            var comments = await _context.Comments.Where(c => c.PaperId == PaperDetail.Id).ToListAsync();
            var authers = await _context.ApplicationUsers.ToListAsync();
            var AutherId = _userManager.GetUserId(User);
            //comments.Where(c => c.PaperId == PaperDetail.Id);
            var TypeLike = await _context.Likes.Where(c => c.Type == "like" &  c.PaperId == PaperDetail.Id).ToListAsync();
            var TypeDisLike = await _context.Likes.Where(c => c.Type == "Dislike" & c.PaperId == PaperDetail.Id).ToListAsync();
          
            Paper_comentsVM PaperComment = new Paper_comentsVM 
            { 
                paper = PaperDetail,
                coments = comments,
                ApplicationUser = authers,
                NumbersOfLike = TypeLike.Count,
                NumbersOfDisLike = TypeDisLike.Count,
                ApplicationUserId=AutherId

            };
            return View(PaperComment);
        }

        //[HttpGet]
        //public IActionResult Like(string Id)
        //{
        //    paperid = Id;
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Like(string id, Like like)
        //{
                       
        //    var AutherId = _userManager.GetUserId(User);
        //    var likes = _context.Likes.ToList();
        //    var NewId = likes.Count + 1;
        //    like.Id = NewId.ToString();
        //    like.Type = "like";
        //    like.PaperId = id;
        //    like.ApplicationUserId = AutherId;
        //    await _Likeservice.AddNewLikeAsync(like);                                   
        //    return RedirectToAction("Details" , new { id = id });
        //}

       
        //[HttpGet]
        //public IActionResult DisLike(string Id)
        //{
        //    paperid = Id;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> DisLike(string id, Like like)
        //{           
           
        //    var AutherId = _userManager.GetUserId(User);
        //    Paper_comentsVM PaperLike = new Paper_comentsVM();
        //    var likes = _context.Likes.ToList();
        //    var NewId = likes.Count + 1;
        //    like.Id = NewId.ToString();
        //    like.Type = "Dislike";
        //    like.PaperId = id;
        //    like.ApplicationUserId = AutherId;
        //    await _Likeservice.AddNewLikeAsync(like);
        //    return RedirectToAction("Details", new { id = id });

        //}



    }
}
