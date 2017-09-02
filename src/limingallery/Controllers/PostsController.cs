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

        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
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

            return View(post);
        }

        [HttpPost]
		public ActionResult Edit(Post post)
		{
            if(!ModelState.IsValid)
            {
                return View();
            }

            //var postInDB = _context.Posts.SingleOrDefault(p => p.Id == post.Id);
            _context.Posts.Attach(post);
            var postEntry = _context.Entry(post);
            postEntry.State = EntityState.Modified;
            //postEntry.Property("Title").IsModified = false; // disable Title change
            _context.SaveChanges();

            return RedirectToAction("Index");
		}

        public ActionResult Delete(int id)
        {
            var post = new Post() { Id = id };
            _context.Entry(post).State = EntityState.Deleted;

            _context.SaveChanges();

            //var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            //if (post == null)
            //{
            //    return HttpNotFound("Not found");
            //}

            //if (post.UserId == User.Identity.GetUserId())
            //{
            //    _context.Posts.Remove(post);
            //    _context.SaveChanges();
            //}

            return RedirectToAction("Index");
        }
    }
}