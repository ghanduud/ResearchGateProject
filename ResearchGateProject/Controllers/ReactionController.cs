using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResearchGateProject.Data;
using ResearchGateProject.Data.Services;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Controllers
{
    public class ReactionController : Controller
    {
        private static string paperid;
        private readonly ILikeService _service;        
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ReactionController(UserManager<ApplicationUser> userManager, AppDbContext context, ILikeService service)
        {
            _userManager = userManager;
            _context = context;
            _service = service;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Like(string Id)
        {
            paperid = Id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Like(string id, Like like)
        {

            var AutherId = _userManager.GetUserId(User);
            var likes = _context.Likes.ToList();
            var NewId = likes.Count + 1;
            like.Id = NewId.ToString();
            like.Type = "like";
            like.PaperId = id;
            like.ApplicationUserId = AutherId;
            await _service.AddNewLikeAsync(like);
            return RedirectToAction("Details", "Paper", new { id = id });
        }


        [HttpGet]
        public IActionResult DisLike(string Id)
        {
            paperid = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DisLike(string id, Like like)
        {

            var AutherId = _userManager.GetUserId(User);
            Paper_comentsVM PaperLike = new Paper_comentsVM();
            var likes = _context.Likes.ToList();
            var NewId = likes.Count + 1;
            like.Id = NewId.ToString();
            like.Type = "Dislike";
            like.PaperId = id;
            like.ApplicationUserId = AutherId;
            await _service.AddNewLikeAsync(like);
            return RedirectToAction("Details", "Paper", new { id = id });

        }

    }
}
