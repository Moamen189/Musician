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

        public IActionResult Details(int id)
        {
            Song song = context.Songs.FirstOrDefault(s => s.Id == id);
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

        public IActionResult Update(int id)
        {
            Song song = context.Songs.FirstOrDefault(y => y.Id == id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Update(int id , Song NewSong)
        {
            var song = context.Songs.FirstOrDefault(X => X.Id == id);
            if (song.Author != null)
            {
                song.Title = NewSong.Title;
                song.Author = NewSong.Author;
            
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("Update", NewSong);
            }
        }

        public IActionResult Delete(int id)
        {
            Song song = context.Songs.FirstOrDefault(a => a.Id == id);
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
