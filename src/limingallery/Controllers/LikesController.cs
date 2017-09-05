using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using limingallery.Models;
using Microsoft.AspNet.Identity;

namespace limingallery.Controllers
{
    public class LikesController : Controller
    {
        private ApplicationDbContext _context;

        public LikesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int postId)
        {
            var like = new Like
            {
                PostId = postId,
                CreateOn = DateTime.Now,
                UserId = User.Identity.GetUserId(),
            };

            _context.Likes.Add(like);
            _context.SaveChanges();

            return RedirectToAction("Index","Posts");
        }
    }
}