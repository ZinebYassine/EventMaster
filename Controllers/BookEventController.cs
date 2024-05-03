using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class BookEventController : Controller
    {


        public readonly ApplicationDBcontext _db;
        public BookEventController(ApplicationDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objBookEventList = _db.BookEvents.ToList();
            return View(objBookEventList);
        }


        public IActionResult Create()
        {
            // Fetch the list of available venues from the database
            var availableVenues = _db.Venues.ToList();

            // Create a new instance of the EventViewModel and set the AvailableVenues property
            var model = new BookEvent
            {
                AvailableVenues = availableVenues.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(BookEvent model)
        {
            // Check if the model is valid before processing
            if (!ModelState.IsValid)
            {
                // If not valid, fetch the list of available venues again and return the view with errors
                model.AvailableVenues = _db.Venues.Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Name }).ToList();
                return View(model);
            }

            // Convert the view model to the entity models (BookEvent and Event) and save to the database
            var newBookEvent = new BookEvent
            {
                Name = model.Name,
                date = model.date,
                Venue = model.Venue
            };

            var newEvent = new Event
            {
                Name = model.Name,
                date = model.date,
                Venue = model.Venue
                // Add other properties as needed
            };

            _db.BookEvents.Add(newBookEvent);
            _db.Events.Add(newEvent);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}

