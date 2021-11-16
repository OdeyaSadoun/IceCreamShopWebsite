using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamProject.Models;
using System.Net;
using Firebase.Storage;

//nisayon
namespace IceCreamProject.Controllers
{
    public class IceCreamFlavorsController : Controller
    {
        private readonly OrdersContext _context;

        public IceCreamFlavorsController(OrdersContext context)
        {
            _context = context;
        }

        // GET: IceCreamFlavors
        public async Task<IActionResult> Index()
        {
            return View(await _context.IceCreamFlavor.ToListAsync());
        }

        // GET: IceCreamFlavors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCreamFlavor = await _context.IceCreamFlavor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iceCreamFlavor == null)
            {
                return NotFound();
            }

            return View(iceCreamFlavor);
        }

        // GET: IceCreamFlavors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IceCreamFlavors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Amount,Flavour,ImagePath,Details")] IceCreamFlavor iceCreamFlavor)
        {

            if (ModelState.IsValid)
            {
                firebaseImgAsync(iceCreamFlavor.ImagePath, iceCreamFlavor.Flavour);
                ImaggaSampleClass imagga = new ImaggaSampleClass();
                var result = imagga.CheckImage(iceCreamFlavor.ImagePath);
                for (int i = 0; i < 10; i++)
                { 
                    if (result[i] == "ice cream")
                    {
                        _context.Add(iceCreamFlavor);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
               
            }
            return View(iceCreamFlavor);
        }


        /**
*  Predictor for taste from model/61536e8299dfe70749005f17
*  Predictive model by BigML - Machine Learning Made Easy 00000
*/
        public IActionResult predict()
        {
            return View();
        }
        public IActionResult predictTaste(string city)
        {
            ViewBag.Message = PredictFlavor(city);
            return View();
        }
            public string PredictFlavor( string city)
        {
            var day = DateTime.Now.DayOfWeek.ToString();
            WheatherClass weather = new WheatherClass();
            var temperature = weather.CheckWeather(city).feels_like;
                if (city == null)
                {
                    return "Coconut Pleasure";
                }
                if (city.Equals("Jerusalem"))
                {
                    if (temperature == null)
                    {
                        return "Ube Adventure";
                    }
                    if (temperature > 22.5)
                    {
                        if (temperature > 29.5)
                        {
                            if (day == null)
                            {
                                return "Sweet Cheese";
                            }
                            if (day.Equals("Thursday"))
                            {
                                if (temperature > 37)
                                {
                                    return "Blueberry Explosion";
                                }
                                if (temperature <= 37)
                                {
                                    return "Sweet Cheese";
                                }
                            }
                            if (!day.Equals("Thursday"))
                            {
                                if (temperature > 41)
                                {
                                    return "Coconut Pleasure";
                                }
                                if (temperature <= 41)
                                {
                                    if (day.Equals("Sunday"))
                                    {
                                        return "Coconut Pleasure";
                                    }
                                    if (!day.Equals("Sunday"))
                                    {
                                        return "Sweet Cheese";
                                    }
                                }
                            }
                        }
                        if (temperature <= 29.5)
                        {
                            return "Coconut Pleasure";
                        }
                    }
                    if (temperature <= 22.5)
                    {
                        if (temperature > 19.5)
                        {
                            return "Pistachio Craze";
                        }
                        if (temperature <= 19.5)
                        {
                            if (temperature > 17.4)
                            {
                                if (day == null)
                                {
                                    return "Strawberry Delight";
                                }
                                if (day.Equals("Sunday"))
                                {
                                    return "Strawberry Delight";
                                }
                                if (!day.Equals("Sunday"))
                                {
                                    return "Ube Adventure";
                                }
                            }
                            if (temperature <= 17.4)
                            {
                                return "Ube Adventure";
                            }
                        }
                    }
                }
                if (!city.Equals("Jerusalem"))
                {
                    if (temperature == null)
                    {
                        return "Pistachio Craze";
                    }
                    if (temperature > 32.5)
                    {
                        if (city.Equals("Tel Aviv"))
                        {
                            if (day == null)
                            {
                                return "Pistachio Craze";
                            }
                            if (day.Equals("Sunday"))
                            {
                                return "Bubblegum Bomb";
                            }
                            if (!day.Equals("Sunday"))
                            {
                                return "Pistachio Craze";
                            }
                        }
                        if (!city.Equals("Tel Aviv"))
                        {
                            if (city.Equals("Modiin"))
                            {
                                return "Ube Adventure";
                            }
                            if (!city.Equals("Modiin"))
                            {
                                if (day == null)
                                {
                                    return "Strawberry Delight";
                                }
                                if (day.Equals("Tuesday"))
                                {
                                    return "Citrus Love";
                                }
                                if (!day.Equals("Tuesday"))
                                {
                                    if (temperature > 40.5)
                                    {
                                        if (city.Equals("Elad"))
                                        {
                                            return "Strawberry Delight";
                                        }
                                        if (!city.Equals("Elad"))
                                        {
                                            if (temperature > 41.5)
                                            {
                                                return "Pistachio Craze";
                                            }
                                            if (temperature <= 41.5)
                                            {
                                                return "Citrus Love";
                                            }
                                        }
                                    }
                                    if (temperature <= 40.5)
                                    {
                                        return "Strawberry Delight";
                                    }
                                }
                            }
                        }
                    }
                    if (temperature <= 32.5)
                    {
                        if (city.Equals("Modiin"))
                        {
                            return "Coconut Pleasure";
                        }
                        if (!city.Equals("Modiin"))
                        {
                            if (day == null)
                            {
                                return "Blueberry Explosion";
                            }
                            if (day.Equals("Tuesday"))
                            {
                                if (city.Equals("Rosh Haain"))
                                {
                                    return "Pistachio Craze";
                                }
                                if (!city.Equals("Rosh Haain"))
                                {
                                    if (city.Equals("Tel Aviv"))
                                    {
                                        return "Coconut Pleasure";
                                    }
                                    if (!city.Equals("Tel Aviv"))
                                    {
                                        return "Bubblegum Bomb";
                                    }
                                }
                            }
                            if (!day.Equals("Tuesday"))
                            {
                                if (day.Equals("Friday"))
                                {
                                    if (temperature > 18)
                                    {
                                        if (temperature > 24.5)
                                        {
                                            return "Sweet Cheese";
                                        }
                                        if (temperature <= 24.5)
                                        {
                                            return "Pistachio Craze";
                                        }
                                    }
                                    if (temperature <= 18)
                                    {
                                        return "Blueberry Explosion";
                                    }
                                }
                                if (!day.Equals("Friday"))
                                {
                                    if (city.Equals("Bnei Brak"))
                                    {
                                        if (temperature > 23.75)
                                        {
                                            return "Coconut Pleasure";
                                        }
                                        if (temperature <= 23.75)
                                        {
                                            return "Citrus Love";
                                        }
                                    }
                                    if (!city.Equals("Bnei Brak"))
                                    {
                                        if (city.Equals("Petach Tiqwa"))
                                        {
                                            return "Citrus Love";
                                        }
                                        if (!city.Equals("Petach Tiqwa"))
                                        {
                                            return "Blueberry Explosion";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
        




        // GET: IceCreamFlavors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCreamFlavor = await _context.IceCreamFlavor.FindAsync(id);
            if (iceCreamFlavor == null)
            {
                return NotFound();
            }
            return View(iceCreamFlavor);
        }

        // POST: IceCreamFlavors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Amount,Flavour,ImagePath,Details")] IceCreamFlavor iceCreamFlavor)
        {
            if (id != iceCreamFlavor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iceCreamFlavor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IceCreamFlavorExists(iceCreamFlavor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iceCreamFlavor);
        }

        // GET: IceCreamFlavors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCreamFlavor = await _context.IceCreamFlavor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iceCreamFlavor == null)
            {
                return NotFound();
            }

            return View(iceCreamFlavor);
        }

        // POST: IceCreamFlavors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iceCreamFlavor = await _context.IceCreamFlavor.FindAsync(id);
            _context.IceCreamFlavor.Remove(iceCreamFlavor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IceCreamFlavorExists(int id)
        {
            return _context.IceCreamFlavor.Any(e => e.Id == id);
        }

        public async void firebaseImgAsync(string webUrl, string name)
        {
            WebClient client = new WebClient();
            string path = @"C:\imges\" + name + ".jpg";
            client.DownloadFile(webUrl, path);//Download img to computer
            var stream = System.IO.File.Open(path, System.IO.FileMode.Open);
            var task = new FirebaseStorage("icecream-d62c3.appspot.com").Child(name +
           ".jpg").PutAsync(stream);
            var url = await task;
        }

    }
}
