﻿using limingallery.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace limingallery.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;
        public CommentsController()
        {
            _context = new ApplicationDbContext(); //create context
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // release memory
        }

        // GET: Comments

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "Posts", action = "Details", Id = comment.PostId }));
            }

            comment.UserId = User.Identity.GetUserId();
            comment.CreateOn = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", new RouteValueDictionary(
             new { controller = "Posts", action = "Details", Id = comment.PostId }));
        }


    }
}