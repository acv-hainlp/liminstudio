using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using limingallery.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Web.Routing;

namespace limingallery.Controllers
{
    public class LikesController : Controller
    {
        private ApplicationDbContext _context;

        public LikesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // release memory
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int postId)
        {
            var currentUser = User.Identity.GetUserId();
            var findLike = _context.Likes
                .Where(c=>c.PostId == postId && c.UserId == currentUser)
                .FirstOrDefault(); // if user liked post, find like is true

            if (findLike == null) //if user not like, insert like
            {
                var like = new Like
                {
                    PostId = postId,
                    CreateOn = DateTime.Now,
                    UserId = currentUser,
                };

                _context.Likes.Add(like);
                _context.SaveChanges();

                return RedirectToAction("Index", "Posts");

            }

            //delete if like is exit
            return RedirectToAction("Delete", new RouteValueDictionary(
             new { controller = "Likes", action = "Delete", Id = findLike.Id }));
        }

        public ActionResult Delete(int id)
        {
            Like like = new Like { Id = id };
            _context.Likes.Attach(like);
            _context.Entry(like).State = EntityState.Deleted;

            _context.SaveChanges();

            return RedirectToAction("Index", "Posts");
        }
    }
}