using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musician.Context;
using Musician.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musician.Controllers
{
    public class AlbumController : Controller
    {
        MusicContext context = new MusicContext();

        public IActionResult Index()
        {
            var Albums = context.Albums.Include(X => X.Musician).ToList();
            return View(Albums);
        }

        public IActionResult Details(int id)
        {
            Album album = context.Albums.FirstOrDefault(a => a.Id == id);
            return View(album);
        }


        public IActionResult Create()
        {
            return View(new Album());
        }
        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (album.Title != null)
            {
                context.Albums.Add(album);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", album);
            }
        }

        public IActionResult Update(int id)
        {
            Album album = context.Albums.FirstOrDefault(a => a.Id == id);
            var mus = context.Musicians.ToList();
            ViewBag.Musicers = mus;
            return View(album);
        }
        [HttpPost]
        public IActionResult Update(int id , Album NewAlbum)
        {
            var album = context.Albums.FirstOrDefault(X => X.Id == id);
            if (album != null)
            {
                album.Title = NewAlbum.Title;
                album.Date = NewAlbum.Date;
                album.MusicianId = NewAlbum.MusicianId;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                var mus = context.Musicians.ToList();
                ViewBag.Musicers = mus;
                return View("Update", NewAlbum);
            }
        }

        public IActionResult Delete(int id)
        {
            Album album = context.Albums.FirstOrDefault(a => a.Id == id);
            context.Albums.Remove(album);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
