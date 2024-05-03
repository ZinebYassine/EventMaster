using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        public readonly ApplicationDBcontext _db;
        public CustomerController(ApplicationDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCustomerList = _db.Customers.ToList();
            return View(objCustomerList);
        }

        //Get

        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Customer Cust)
        {
            _db.Customers.Add(Cust);
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return Cust;
        }
        public IActionResult Delete(int id)
        {
            Customer custToDelete = _db.Customers.Find(id);

            if (custToDelete == null)
            {
                // Customer not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }

            // Delete the customer
            _db.Customers.Remove(custToDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Customer custToEdit = _db.Customers.Find(id);

            if (custToEdit == null)
            {

                return NotFound();
            }

            return View(custToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Customer updatedCust)
        {

            Customer existingCust = _db.Customers.Find(updatedCust.Id);

            if (existingCust == null)
            {
                // Customer not found, handle appropriately (e.g., return a not found view)
                return NotFound();
            }
            existingCust.FirstName = updatedCust.FirstName;
            existingCust.LastName = updatedCust.LastName;
            existingCust.Phone = updatedCust.Phone;



            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

