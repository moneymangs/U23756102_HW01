using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U23756102_HW01.Models;

namespace U23756102_HW01.Controllers
{
    public class DriverController : Controller
    {
        

        

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.Services = ServiceRepository.Services;
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Driver driver, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                using (var reader = new BinaryReader(ImageFile.InputStream))
                {
                    byte[] imageBytes = reader.ReadBytes(ImageFile.ContentLength);
                    driver.ImagePath = "data:image/jpeg;base64,"+ Convert.ToBase64String(imageBytes);
                }
            }

            

            DriverRepository.Drivers.Add(driver);
            return RedirectToAction("VehicleDriver", "Home");
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Services = ServiceRepository.Services;
            Driver selectedVehicle = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == id);
            return View(selectedVehicle);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver, HttpPostedFileBase imageFile)
        {
            var existing = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == driver.DriverID);
            if (existing == null)
                return HttpNotFound();

            existing.FirstName = driver.FirstName;
            existing.LastName = driver.LastName;
            existing.PhoneNumber = driver.PhoneNumber;
            existing.ImagePath = driver.ImagePath;
            existing.ServiceID = driver.ServiceID;

            if (imageFile != null && imageFile.ContentLength > 0)
            {
                using (var reader = new BinaryReader(imageFile.InputStream))
                {
                    byte[] imageBytes = reader.ReadBytes(imageFile.ContentLength);
                    existing.ImagePath = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
                }
            }
            else
            {
                // Keep the existing image if no new image is uploaded
                existing.ImagePath = driver.ImagePath;
            }

            return RedirectToAction("VehicleDriver", "Home");
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DriverRepository.Drivers.Remove(DriverRepository.Drivers.FirstOrDefault(v => v.DriverID == id));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                ModelState.AddModelError("", "An error occurred while trying to delete the driver: " + ex.Message);
            }
            return RedirectToAction("VehicleDriver", "Home");
        }




    }
}
