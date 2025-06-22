using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U23756102_HW01.Models;

namespace U23756102_HW01.Controllers
{
    
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View(VehicleRepository.Vehicles);
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.Services = ServiceRepository.Services;
            return View();
        }

        
        public ActionResult Edit(int id)
        {
            ViewBag.Services = ServiceRepository.Services;
            Vehicle selectedVehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == id);
            return View(selectedVehicle);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                using (var reader = new BinaryReader(ImageFile.InputStream))
                {
                    byte[] imageBytes = reader.ReadBytes(ImageFile.ContentLength);
                    vehicle.ImagePath = "data:image/jpeg;base64,"+ Convert.ToBase64String(imageBytes);
                }
            }

            

            VehicleRepository.Vehicles.Add(vehicle);
            return RedirectToAction("VehicleDriver", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle, HttpPostedFileBase imageFile)
        {
            var existing = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == vehicle.VehicleID);
            if (existing == null)
                return HttpNotFound();

            existing.Type = vehicle.Type;
            existing.RegistrationNumber = vehicle.RegistrationNumber;
            existing.ServiceID = vehicle.ServiceID;

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
                existing.ImagePath = vehicle.ImagePath;
            }

            return RedirectToAction("VehicleDriver", "Home");
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VehicleRepository.Vehicles.Remove(VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == id));
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                ModelState.AddModelError("", "An error occurred while trying to delete the driver: " + ex.Message);
            }
            return RedirectToAction("VehicleDriver", "Home");
        }

        [HttpPost]
        public ActionResult ExportToTextFile()
        {
            // Example: getting from a static repository (replace with DB fetch if needed)
            var vehicles = VehicleRepository.Vehicles;

            // Format each vehicle as a line
            var lines = vehicles.Select(v =>
                $"VehicleID: {v.VehicleID}, Type: {v.Type}, Registration: {v.RegistrationNumber}, ServiceID: {v.ServiceID}"
            );

            // Join all lines into one string
            var fileContent = string.Join(Environment.NewLine, lines);

            // Convert to byte array for file download
            var byteArray = System.Text.Encoding.UTF8.GetBytes(fileContent);
            var stream = new System.IO.MemoryStream(byteArray);

            // Return as downloadable file
            return File(stream, "text/plain", "VehicleList.txt");
        }



    }
}
