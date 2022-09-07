using Microsoft.AspNetCore.Mvc;
using Musician.Context;
using Musician.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Musician.Controllers
{
    public class SongController : Controller
    {
        MusicContext context = new MusicContext();
        public IActionResult Index()
        {
            List<Song> Song = context.Songs.ToList();
            return View(Song);
        }

        public IActionResult Details(string title)
        {
            Song song = context.Songs.FirstOrDefault(s => s.Title == title);
            return View(song);
        }


        public IActionResult Create()
        {
            return View(new Song());
        }
        [HttpPost]
        public IActionResult Create(Song song)
        {
            if (song.Author != null)
            {
                context.Songs.Add(song);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", song);
            }
        }

        public IActionResult Update(string title)
        {
            Song song = context.Songs.FirstOrDefault(y => y.Title == title);
            return View(song);
        }
        [HttpPost]
        public IActionResult Update(string title , Song NewSong)
        {
            var song = context.Songs.FirstOrDefault(X => X.Title == title);
            if (song.Author != null)
            {
                song.Author = NewSong.Author;
            
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("Update", NewSong);
            }
        }

        public IActionResult Delete(string title)
        {
            Song song = context.Songs.FirstOrDefault(a => a.Title == title);
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
