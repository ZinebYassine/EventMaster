using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class VenueController : Controller
    {

        public readonly ApplicationDBcontext _db;
        public VenueController(ApplicationDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objVenueList = _db.Venues.ToList();
            return View(objVenueList);
        }

        //Get

        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Venue Ven)
        {
            _db.Venues.Add(Ven);
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return Ven;
        }
        public IActionResult Delete(int id)
        {
            Venue venToDelete = _db.Venues.Find(id);

            if (venToDelete == null)
            {
                // Venue not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }

            // Delete the venomer
            _db.Venues.Remove(venToDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Venue venToEdit = _db.Venues.Find(id);

            if (venToEdit == null)
            {

                return NotFound();
            }

            return View(venToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Venue updatedVen)
        {

            Venue existingVen = _db.Venues.Find(updatedVen.Id);

            if (existingVen == null)
            {
                // Venue not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }
            existingVen.Name = updatedVen.Name;
            existingVen.Manager = updatedVen.Manager;
            existingVen.ManagerPhone = updatedVen.ManagerPhone;
            existingVen.adresse = updatedVen.adresse;
            existingVen.Capacity = updatedVen.Capacity;



            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}