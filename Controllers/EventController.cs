using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        

        public readonly ApplicationDBcontext _db;
        public EventController(ApplicationDBcontext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var objEventList=_db.Events.ToList();
            return View(objEventList);
        }

        //Get

        public IActionResult Create()
        {
            // Fetch the list of available venues from the database
            var availableVenues = _db.Venues.ToList();

            // Create a new instance of the EventViewModel and set the AvailableVenues property
            var model = new Event
            {
                AvailableVenues = availableVenues.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList()
            };

            return View(model);
        }

        //Post
        [HttpPost]
        public IActionResult Create(Event model)
        {
            // Check if the model is valid before processing
            if (!ModelState.IsValid)
            {
                // If not valid, fetch the list of available venues again and return the view with errors
                model.AvailableVenues = _db.Venues.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();
                return View(model);
            }

            
            var newEvent = new Event
            {
                Name = model.Name,
                date = model.date,
                Venue = model.Venue
            };

            _db.Events.Add(newEvent); 
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Event eveToDelete = _db.Events.Find(id);

            if (eveToDelete == null)
            {
                // Eveloyee not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }

            // Delete the employee
            _db.Events.Remove(eveToDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Event eveToEdit = _db.Events.Find(id);

            if (eveToEdit == null)
            {
                
                return NotFound();
            }

            return View(eveToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Event updatedEve)
        {

            Event existingEve = _db.Events.Find(updatedEve.Id);

            if (existingEve == null)
            {
                // Eveloyee not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }
            existingEve.Name = updatedEve.Name;
            existingEve.date = updatedEve.date;
            existingEve.Venue = updatedEve.Venue;


            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
