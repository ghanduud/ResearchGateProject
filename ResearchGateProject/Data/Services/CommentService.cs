using ResearchGateProject.Data.Base;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.Services
{
    public class CommentService : EntityBaseRepository<Comment>, ICommentService
    {
        private readonly AppDbContext _context;
        public CommentService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCommentAsync(NewCommentVM data)
        {
            //var x = data.PaperId;
            var newComment = new Comment()
            {
                Id = data.Id,             
                Body = data.Body,
                PaperId = data.PaperId,
                ApplicationUserId = data.ApplicationUserId
                //PaperId = "2"

            };
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();

           


        }
    }
}
