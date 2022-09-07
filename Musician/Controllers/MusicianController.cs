using Microsoft.AspNetCore.Mvc;
using Musician.Context;
using Musician.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musician.Controllers
{
    public class MusicianController : Controller
    {
        MusicContext context = new MusicContext();

        public IActionResult Index()
        {
            List<Musiciann> Musicans = context.Musicians.ToList();
            return View(Musicans);
        }

        public IActionResult Details(int id)
        {
            Musiciann musician = context.Musicians.FirstOrDefault(M => M.Id == id);
            return View(musician);
        }


        public IActionResult Create()
        {
            return View(new Musiciann());
        }
        [HttpPost]
        public IActionResult Create(Musiciann musician)
        {
            if (musician.Name != null)
            {
                context.Musicians.Add(musician);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create" , musician);
            }
            
        }

        public IActionResult Update(int id)
        {
            Musiciann musician = context.Musicians.FirstOrDefault(X => X.Id == id);

            return View(musician);
        }
        [HttpPost]
        public IActionResult Update(int id , Musiciann NewMusiciann)
        {
           var musician = context.Musicians.FirstOrDefault(X => X.Id == id);
            if (musician.Name != null)
            {
                musician.Name = NewMusiciann.Name;
                musician.Phone = NewMusiciann.Phone;
                musician.City = NewMusiciann.City;
                musician.Street = NewMusiciann.Street;
                musician.Albums = NewMusiciann.Albums;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("Update", NewMusiciann);
            }
        }

        public IActionResult Delete(int id)
        {
            Musiciann musician = context.Musicians.FirstOrDefault(a => a.Id == id);
            context.Musicians.Remove(musician);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
