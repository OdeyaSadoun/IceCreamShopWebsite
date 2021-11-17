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

        public IActionResult predictTasteWithAllParameters(string city, string season, string day, double temperature)
        {

            ViewBag.Message = PredictFlavorWithAllParameters(city, season,day,temperature);
            return View();
        }
        public string PredictFlavor( string city)
        {
            var day = DateTime.Now.DayOfWeek.ToString();
            WheatherClass weather = new WheatherClass();
            var temperature = weather.CheckWeather(city).feels_like;
            
            var day1 = DateTime.Now;
            string season = "";
            if (day1.Month == 9 || day1.Month == 10 || day1.Month == 11)
                season = "autumn";
            else if (day1.Month == 12 || day1.Month == 1 || day1.Month == 2)
                season = "winter";
            else if (day1.Month == 3 || day1.Month == 4 || day1.Month == 5)
                season = "spring";
            else
                season = "summer";

            if (temperature == null)
            {
                return "Vanilla";
            }
            if (temperature > 33.74096)
            {
                if (temperature > 37.8)
                {
                    if (city == null)
                    {
                        return "Lemon";
                    }
                    if (city.Equals("Jerusalem"))
                    {
                        if (day == null)
                        {
                            return "Lemon";
                        }
                        if (day.Equals("Thursday"))
                        {
                            if (temperature > 39.5)
                            {
                                return "Lemon";
                            }
                            if (temperature <= 39.5)
                            {
                                return "Lemon";
                            }
                        }
                        if (!day.Equals("Thursday"))
                        {
                            if (day.Equals("Tuesday"))
                            {
                                if (temperature > 40.115)
                                {
                                    return "Lemon";
                                }
                                if (temperature <= 40.115)
                                {
                                    if (temperature > 38.945)
                                    {
                                        return "Lemon";
                                    }
                                    if (temperature <= 38.945)
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                            if (!day.Equals("Tuesday"))
                            {
                                if (day.Equals("Friday"))
                                {
                                    return "Lemon";
                                }
                                if (!day.Equals("Friday"))
                                {
                                    if (temperature > 38.53)
                                    {
                                        if (temperature > 40.05)
                                        {
                                            return "Lemon";
                                        }
                                        if (temperature <= 40.05)
                                        {
                                            if (temperature > 38.58)
                                            {
                                                if (day.Equals("Wednesday"))
                                                {
                                                    return "Lemon";
                                                }
                                                if (!day.Equals("Wednesday"))
                                                {
                                                    if (temperature > 38.75)
                                                    {
                                                        if (temperature > 39.2)
                                                        {
                                                            if (temperature > 39.75)
                                                            {
                                                                if (day.Equals("Sunday"))
                                                                {
                                                                    return "Lemon";
                                                                }
                                                                if (!day.Equals("Sunday"))
                                                                {
                                                                    return "Lemon";
                                                                }
                                                            }
                                                            if (temperature <= 39.75)
                                                            {
                                                                return "Lemon";
                                                            }
                                                        }
                                                        if (temperature <= 39.2)
                                                        {
                                                            return "Lemon";
                                                        }
                                                    }
                                                    if (temperature <= 38.75)
                                                    {
                                                        return "Lemon";
                                                    }
                                                }
                                            }
                                            if (temperature <= 38.58)
                                            {
                                                return "Lemon";
                                            }
                                        }
                                    }
                                    if (temperature <= 38.53)
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                        }
                    }
                    if (!city.Equals("Jerusalem"))
                    {
                        if (city.Equals("Rehovot"))
                        {
                            if (day == null)
                            {
                                return "Bannana";
                            }
                            if (day.Equals("Monday"))
                            {
                                return "Bannana";
                            }
                            if (!day.Equals("Monday"))
                            {
                                return "Strawberry Delight";
                            }
                        }
                        if (!city.Equals("Rehovot"))
                        {
                            if (city.Equals("Tel Aviv"))
                            {
                                if (temperature > 133.5)
                                {
                                    return "Chocolate";
                                }
                                if (temperature <= 133.5)
                                {
                                    return "Bannana";
                                }
                            }
                            if (!city.Equals("Tel Aviv"))
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    if (day == null)
                                    {
                                        return "Lemon";
                                    }
                                    if (day.Equals("Wednesday"))
                                    {
                                        if (city.Equals("Bnei Brak"))
                                        {
                                            return "Strawberry Delight";
                                        }
                                        if (!city.Equals("Bnei Brak"))
                                        {
                                            if (city.Equals("Petach Tiqwa"))
                                            {
                                                return "Strawberry Delight";
                                            }
                                            if (!city.Equals("Petach Tiqwa"))
                                            {
                                                return "Lemon";
                                            }
                                        }
                                    }
                                    if (!day.Equals("Wednesday"))
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                        }
                    }
                }
                if (temperature <= 37.8)
                {
                    if (city == null)
                    {
                        return "Bannana";
                    }
                    if (city.Equals("Holon"))
                    {
                        return "Lemon";
                    }
                    if (!city.Equals("Holon"))
                    {
                        return "Bannana";
                    }
                }
            }
            if (temperature <= 33.74096)
            {
                if (temperature > 19.15238)
                {
                    if (temperature > 30.4)
                    {
                        if (temperature > 32.75)
                        {
                            if (city == null)
                            {
                                return "Vanilla";
                            }
                            if (city.Equals("Eilat"))
                            {
                                return "Vanilla";
                            }
                            if (!city.Equals("Eilat"))
                            {
                                if (city.Equals("Haifa"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Haifa"))
                                {
                                    if (city.Equals("Ashdod"))
                                    {
                                        return "Vanilla";
                                    }
                                    if (!city.Equals("Ashdod"))
                                    {
                                        if (temperature > 33.3)
                                        {
                                            return "Bannana";
                                        }
                                        if (temperature <= 33.3)
                                        {
                                            return "Strawberries in cream";
                                        }
                                    }
                                }
                            }
                        }
                        if (temperature <= 32.75)
                        {
                            return "Bannana";
                        }
                    }
                    if (temperature <= 30.4)
                    {
                        if (city == null)
                        {
                            return "Vanilla";
                        }
                        if (city.Equals("Netanya"))
                        {
                            if (season == null)
                            {
                                return "Lotus";
                            }
                            if (season.Equals("summer"))
                            {
                                return "Lotus";
                            }
                            if (!season.Equals("summer"))
                            {
                                return "Vanilla";
                            }
                        }
                        if (!city.Equals("Netanya"))
                        {
                            if (temperature > 28.05)
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    return "Bannana";
                                }
                            }
                            if (temperature <= 28.05)
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    if (temperature > 24.45)
                                    {
                                        return "Vanilla";
                                    }
                                    if (temperature <= 24.45)
                                    {
                                        return "Chocolate";
                                    }
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    if (city.Equals("Ashdod"))
                                    {
                                        if (temperature > 24.5)
                                        {
                                            return "Chocolate";
                                        }
                                        if (temperature <= 24.5)
                                        {
                                            return "Vanilla";
                                        }
                                    }
                                    if (!city.Equals("Ashdod"))
                                    {
                                        return "Chocolate";
                                    }
                                }
                            }
                        }
                    }
                }
                if (temperature <= 19.15238)
                {
                    if (temperature > 12.5)
                    {
                        if (city == null)
                        {
                            return "chocolate";
                        }
                        if (city.Equals("Tel Aviv"))
                        {
                            return "chocolate";
                        }
                        if (!city.Equals("Tel Aviv"))
                        {
                            if (city.Equals("Rehovot"))
                            {
                                return "chocolate";
                            }
                            if (!city.Equals("Rehovot"))
                            {
                                return "Pistachio Craze";
                            }
                        }
                    }
                    if (temperature <= 12.5)
                    {
                        if (city == null)
                        {
                            return "Strawberries in cream";
                        }
                        if (city.Equals("Jerusalem"))
                        {
                            return "chocolate";
                        }
                        if (!city.Equals("Jerusalem"))
                        {
                            if (city.Equals("Petah Tiqwa"))
                            {
                                return "chocolate";
                            }
                            if (!city.Equals("Petah Tiqwa"))
                            {
                                if (city.Equals("Netanya"))
                                {
                                    return "Strawberries in cream";
                                }
                                if (!city.Equals("Netanya"))
                                {
                                    if (city.Equals("Eilat"))
                                    {
                                        return "Strawberries in cream";
                                    }
                                    if (!city.Equals("Eilat"))
                                    {
                                        return "Vanilla";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public string PredictFlavorWithAllParameters(string city, string season, string day, double temperature)
        {
  
            if (temperature == null)
            {
                return "Vanilla";
            }
            if (temperature > 33.74096)
            {
                if (temperature > 37.8)
                {
                    if (city == null)
                    {
                        return "Lemon";
                    }
                    if (city.Equals("Jerusalem"))
                    {
                        if (day == null)
                        {
                            return "Lemon";
                        }
                        if (day.Equals("Thursday"))
                        {
                            if (temperature > 39.5)
                            {
                                return "Lemon";
                            }
                            if (temperature <= 39.5)
                            {
                                return "Lemon";
                            }
                        }
                        if (!day.Equals("Thursday"))
                        {
                            if (day.Equals("Tuesday"))
                            {
                                if (temperature > 40.115)
                                {
                                    return "Lemon";
                                }
                                if (temperature <= 40.115)
                                {
                                    if (temperature > 38.945)
                                    {
                                        return "Lemon";
                                    }
                                    if (temperature <= 38.945)
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                            if (!day.Equals("Tuesday"))
                            {
                                if (day.Equals("Friday"))
                                {
                                    return "Lemon";
                                }
                                if (!day.Equals("Friday"))
                                {
                                    if (temperature > 38.53)
                                    {
                                        if (temperature > 40.05)
                                        {
                                            return "Lemon";
                                        }
                                        if (temperature <= 40.05)
                                        {
                                            if (temperature > 38.58)
                                            {
                                                if (day.Equals("Wednesday"))
                                                {
                                                    return "Lemon";
                                                }
                                                if (!day.Equals("Wednesday"))
                                                {
                                                    if (temperature > 38.75)
                                                    {
                                                        if (temperature > 39.2)
                                                        {
                                                            if (temperature > 39.75)
                                                            {
                                                                if (day.Equals("Sunday"))
                                                                {
                                                                    return "Lemon";
                                                                }
                                                                if (!day.Equals("Sunday"))
                                                                {
                                                                    return "Lemon";
                                                                }
                                                            }
                                                            if (temperature <= 39.75)
                                                            {
                                                                return "Lemon";
                                                            }
                                                        }
                                                        if (temperature <= 39.2)
                                                        {
                                                            return "Lemon";
                                                        }
                                                    }
                                                    if (temperature <= 38.75)
                                                    {
                                                        return "Lemon";
                                                    }
                                                }
                                            }
                                            if (temperature <= 38.58)
                                            {
                                                return "Lemon";
                                            }
                                        }
                                    }
                                    if (temperature <= 38.53)
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                        }
                    }
                    if (!city.Equals("Jerusalem"))
                    {
                        if (city.Equals("Rehovot"))
                        {
                            if (day == null)
                            {
                                return "Bannana";
                            }
                            if (day.Equals("Monday"))
                            {
                                return "Bannana";
                            }
                            if (!day.Equals("Monday"))
                            {
                                return "Strawberry Delight";
                            }
                        }
                        if (!city.Equals("Rehovot"))
                        {
                            if (city.Equals("Tel Aviv"))
                            {
                                if (temperature > 133.5)
                                {
                                    return "Chocolate";
                                }
                                if (temperature <= 133.5)
                                {
                                    return "Bannana";
                                }
                            }
                            if (!city.Equals("Tel Aviv"))
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    if (day == null)
                                    {
                                        return "Lemon";
                                    }
                                    if (day.Equals("Wednesday"))
                                    {
                                        if (city.Equals("Bnei Brak"))
                                        {
                                            return "Strawberry Delight";
                                        }
                                        if (!city.Equals("Bnei Brak"))
                                        {
                                            if (city.Equals("Petach Tiqwa"))
                                            {
                                                return "Strawberry Delight";
                                            }
                                            if (!city.Equals("Petach Tiqwa"))
                                            {
                                                return "Lemon";
                                            }
                                        }
                                    }
                                    if (!day.Equals("Wednesday"))
                                    {
                                        return "Lemon";
                                    }
                                }
                            }
                        }
                    }
                }
                if (temperature <= 37.8)
                {
                    if (city == null)
                    {
                        return "Bannana";
                    }
                    if (city.Equals("Holon"))
                    {
                        return "Lemon";
                    }
                    if (!city.Equals("Holon"))
                    {
                        return "Bannana";
                    }
                }
            }
            if (temperature <= 33.74096)
            {
                if (temperature > 19.15238)
                {
                    if (temperature > 30.4)
                    {
                        if (temperature > 32.75)
                        {
                            if (city == null)
                            {
                                return "Vanilla";
                            }
                            if (city.Equals("Eilat"))
                            {
                                return "Vanilla";
                            }
                            if (!city.Equals("Eilat"))
                            {
                                if (city.Equals("Haifa"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Haifa"))
                                {
                                    if (city.Equals("Ashdod"))
                                    {
                                        return "Vanilla";
                                    }
                                    if (!city.Equals("Ashdod"))
                                    {
                                        if (temperature > 33.3)
                                        {
                                            return "Bannana";
                                        }
                                        if (temperature <= 33.3)
                                        {
                                            return "Strawberries in cream";
                                        }
                                    }
                                }
                            }
                        }
                        if (temperature <= 32.75)
                        {
                            return "Bannana";
                        }
                    }
                    if (temperature <= 30.4)
                    {
                        if (city == null)
                        {
                            return "Vanilla";
                        }
                        if (city.Equals("Netanya"))
                        {
                            if (season == null)
                            {
                                return "Lotus";
                            }
                            if (season.Equals("summer"))
                            {
                                return "Lotus";
                            }
                            if (!season.Equals("summer"))
                            {
                                return "Vanilla";
                            }
                        }
                        if (!city.Equals("Netanya"))
                        {
                            if (temperature > 28.05)
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    return "Vanilla";
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    return "Bannana";
                                }
                            }
                            if (temperature <= 28.05)
                            {
                                if (city.Equals("Tiberia"))
                                {
                                    if (temperature > 24.45)
                                    {
                                        return "Vanilla";
                                    }
                                    if (temperature <= 24.45)
                                    {
                                        return "Chocolate";
                                    }
                                }
                                if (!city.Equals("Tiberia"))
                                {
                                    if (city.Equals("Ashdod"))
                                    {
                                        if (temperature > 24.5)
                                        {
                                            return "Chocolate";
                                        }
                                        if (temperature <= 24.5)
                                        {
                                            return "Vanilla";
                                        }
                                    }
                                    if (!city.Equals("Ashdod"))
                                    {
                                        return "Chocolate";
                                    }
                                }
                            }
                        }
                    }
                }
                if (temperature <= 19.15238)
                {
                    if (temperature > 12.5)
                    {
                        if (city == null)
                        {
                            return "chocolate";
                        }
                        if (city.Equals("Tel Aviv"))
                        {
                            return "chocolate";
                        }
                        if (!city.Equals("Tel Aviv"))
                        {
                            if (city.Equals("Rehovot"))
                            {
                                return "chocolate";
                            }
                            if (!city.Equals("Rehovot"))
                            {
                                return "Pistachio Craze";
                            }
                        }
                    }
                    if (temperature <= 12.5)
                    {
                        if (city == null)
                        {
                            return "Strawberries in cream";
                        }
                        if (city.Equals("Jerusalem"))
                        {
                            return "chocolate";
                        }
                        if (!city.Equals("Jerusalem"))
                        {
                            if (city.Equals("Petah Tiqwa"))
                            {
                                return "chocolate";
                            }
                            if (!city.Equals("Petah Tiqwa"))
                            {
                                if (city.Equals("Netanya"))
                                {
                                    return "Strawberries in cream";
                                }
                                if (!city.Equals("Netanya"))
                                {
                                    if (city.Equals("Eilat"))
                                    {
                                        return "Strawberries in cream";
                                    }
                                    if (!city.Equals("Eilat"))
                                    {
                                        return "Vanilla";
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
