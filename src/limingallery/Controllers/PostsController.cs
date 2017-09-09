using limingallery.Models;
using limingallery.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                .Include(p => p.Likes) // join Likes 
                .Include(p=>p.Comments)
                .ToList();
            return View(posts);
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if(id == null) return RedirectToAction("Index");

            var post = _context.Posts
                .Include(p=>p.Likes)
                .Include(p=>p.Comments)
                .Include(p=>p.User)
                .FirstOrDefault(p => p.Id == id);
            var comments = _context.Comments.Where(c => c.PostId == id)
                .Include(c => c.User)
                .ToList();

            if (post == null)
            {
                return HttpNotFound("Not found");
            }

            var viewModel = new PostCommentViewModes
            {
                Post = post,
                Comments = comments
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(Post Post)
        {
            if (!ModelState.IsValid)
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
        public ActionResult Edit(int id, string title, string description)
        {
            {
                if (string.IsNullOrEmpty(title))
                {
                    return RedirectToAction("Details", new RouteValueDictionary(
                        new { controller = "Posts", action = "Details", Id = id }));
                }

                var post = _context.Posts.SingleOrDefault(p => p.Id == id);

                _context.Posts.Attach(post);
                post.Title = title;
                post.Description = description;

                //_context.Entry(post).State = EntityState.Modified;
                //_context.Entry(post).Property(p => p.File).IsModified = false;
                _context.Configuration.ValidateOnSaveEnabled = false; //disable validation
                _context.SaveChanges();

                return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "Posts", action = "Details", Id = id }));
            }
        }

        public ActionResult Delete(int id)
        {
            //var post = new Post() { Id = id };
            //var path = Path.Combine(Server.MapPath("~/Content/Images/uploads"), post.ImageName);
            //System.IO.File.Delete(path);

            //_context.Entry(post).State = EntityState.Deleted;

            //_context.SaveChanges();

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