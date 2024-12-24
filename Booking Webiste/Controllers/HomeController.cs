using Booking_Webiste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Webiste.Controllers
{
    public class HomeController : Controller
    {
        private readonly PatientDBContext patientDB;

        public HomeController(PatientDBContext patientDB)
        {
            this.patientDB = patientDB;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var stdData = await patientDB.Patients.ToListAsync();
            return View(stdData);

        }
        [HttpGet]
        public IActionResult Create() 
        {
            List<string> slots = new List<string>()
            {
                " 12Am -  1Pm ",
                " 1Pm  -  2Pm ",
                " 2Pm  -  3Pm ",
                " 3Pm  -  4Pm ",
                " 4Pm  -  5Pm ",
                " 6Pm  -  7Pm ",
                " 7Pm  -  8Pm ",
                " 8Pm  -  9Pm "
            };

            ViewBag.Slots = new SelectList(slots);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient std)
        {
            if (ModelState.IsValid)
            {
                await patientDB.Patients.AddAsync(std);
                await patientDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<string> slots = new List<string>()
            {
                " 12Am -  1Pm ",
                " 1Pm  -  2Pm ",
                " 2Pm  -  3Pm ",
                " 3Pm  -  4Pm ",
                " 4Pm  -  5Pm ",
                " 6Pm  -  7Pm ",
                " 7Pm  -  8Pm ",
                " 8Pm  -  9Pm " 
            }; 

            ViewBag.Slots = new SelectList(slots);
            var data = patientDB.Patients.FirstOrDefault(x => x.PatientId == id);
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Patient Model)
        {
            var data = await patientDB.Patients.FirstOrDefaultAsync(x => x.PatientId == Model.PatientId);
            if (data != null)
            {
                data.PatientId = Model.PatientId;
                data.Name = Model.Name;
                data.Email = Model.Email;
                data.Phone = Model.Phone;
                data.Date = Model.Date;
                data.Slots = Model.Slots;
                data.No_Of_Persons = Model.No_Of_Persons;

                patientDB.SaveChanges();
            }

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdData = await patientDB.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await patientDB.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (data == null)
            {
                return NotFound();
            }

            patientDB.Patients.Remove(data);
            await patientDB.SaveChangesAsync();
            ViewBag.Message = " Record Delete Successfully";
           // return RedirectToAction(nameof(Index));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }  
    }  
}