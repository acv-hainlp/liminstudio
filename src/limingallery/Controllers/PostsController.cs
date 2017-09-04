using limingallery.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace limingallery.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;
        public PostsController()
        {
            _context = new ApplicationDbContext(); //create context
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // release memory
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var posts = _context.Posts
                .Include(p=>p.User) //join public ApplicationUser User { get; set; }
                .ToList();
            return View(posts);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound("Not found");
            }
            return View(post);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Post Post)
        {
            if(!ModelState.IsValid )
            {
                return View();
            }

            // Use your file here
            if (Post.File.ContentLength > 0)
            {
                Post.CreateOn = DateTime.Now;
                Post.UserId = User.Identity.GetUserId();
                Post.ImageName = User.Identity.GetUserId() + (DateTime.Now.Ticks).ToString() + ".png";
                var path = Path.Combine(Server.MapPath("~/Content/Images/uploads"), Post.ImageName);
                Post.File.SaveAs(path);

                _context.Posts.Add(Post);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound("Not found");
            }

            return HttpNotFound("Not found");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound("Not found");
            }

            if (post.UserId == User.Identity.GetUserId())
            {
                var path = Path.Combine(Server.MapPath("~/Content/Images/uploads"), post.ImageName);
                System.IO.File.Delete(path);
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}