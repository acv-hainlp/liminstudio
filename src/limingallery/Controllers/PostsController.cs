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
            if(!ModelState.IsValid)
            {
                return View();
            }

            // Use your file here
            if (Post.File.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(Post.File.FileName);
                var fileName = Post.Title.ToLower() + ".png";
                fileName = fileName.Replace(" ", "");
                var path = Path.Combine(Server.MapPath("~/Content/Images/uploads"), fileName);
                Post.File.SaveAs(path);
            }

            Post.UserId = User.Identity.GetUserId();
            _context.Posts.Add(Post);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound("Not found");
            }

            return HttpNotFound("Not found");
        }
    }
}