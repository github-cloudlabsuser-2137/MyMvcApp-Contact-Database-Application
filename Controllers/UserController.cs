using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index(string searchTerm)
        {
              if (string.IsNullOrEmpty(searchTerm))
            {
                return View(userlist);
            }

            var results = userlist.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(results);
        }

        // GET: User/Search
        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(new List<User>());
            }

            var results = userlist.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(results);
        }
            
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);
            
            // If the user is not found, return a NotFound result
            if (user == null)
            {
            return NotFound();
            }

            // Return the view with the user details
            return View(user);
        }

        // GET: User/Create
        // GET: User/Create
        public ActionResult Create()
        {
            // Return the view to create a new user
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            // Add the new user to the userlist
            userlist.Add(user);
            
            // Redirect to the Index action to display the updated list of users
            return RedirectToAction(nameof(Index));
            }
            
            // If the model state is not valid, return the Create view with the user data to display validation errors
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user is not found, return a NotFound result
            if (user == null)
            {
            return NotFound();
            }

            // Return the view with the user details to edit
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
            // Find the user with the specified ID in the userlist
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            
            // If the user is not found, return a NotFound result
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the user's properties
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // existingUser.Phone = user.Phone;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, return the Edit view with the user data to display validation errors
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user is not found, return a NotFound result
            if (user == null)
            {
            return NotFound();
            }

            // Return the view with the user details to confirm deletion
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user is not found, return a NotFound result
            if (user == null)
            {
            return NotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction(nameof(Index));
        }
}
