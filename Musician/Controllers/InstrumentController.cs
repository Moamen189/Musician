using Microsoft.AspNetCore.Mvc;
using Musician.Context;
using Musician.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musician.Controllers
{
    public class InstrumentController : Controller
    {
        MusicContext context = new MusicContext();

        public IActionResult Index()
        {
            List<Instrument> instrument = context.Instruments.ToList();
            return View(instrument);
        }

        public IActionResult Details(int id)
        {
            Instrument instrument = context.Instruments.FirstOrDefault(x => x.Id == id);
            return View(instrument);
        }


        public IActionResult Create()
        {
            return View(new Instrument());
        }
        [HttpPost]
        public IActionResult Create(Instrument instrument)
        {
            
            if(instrument.Key != null)
            {
                context.Instruments.Add(instrument);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", instrument);
            }
        }

        public IActionResult Update(int id)
        {
            Instrument instrument = context.Instruments.FirstOrDefault(x => x.Id == id);
            return View(instrument);
        }
        [HttpPost]
        public IActionResult Update(int id , Instrument NewInstrument)
        {
            var instrument = context.Instruments.FirstOrDefault(X => X.Id == id);
            if (instrument.Key != null)
            {

                instrument.Key = instrument.Key;
                instrument.Name = instrument.Name;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("Update", NewInstrument);
            }
        }

        public IActionResult Delete(int id)
        {
            Instrument insttrument = context.Instruments.FirstOrDefault(a => a.Id == id);
            context.Instruments.Remove(insttrument);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
