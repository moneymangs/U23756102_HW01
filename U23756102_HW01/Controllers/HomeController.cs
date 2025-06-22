using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using U23756102_HW01.Models;

namespace U23756102_HW01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View(ServiceRepository.Services);
        }

        public ActionResult VehicleDriver()
        {
            ViewBag.Services = ServiceRepository.Services;
            return View(
                new VehicleDriverViewModel
                {
                    Vehicles = VehicleRepository.Vehicles,
                    Drivers = DriverRepository.Drivers
                }
            );
        }

        public ActionResult Book(int id)
        {
            ViewBag.ServiceID = id;
            List<Vehicle> vehicles = VehicleRepository.Vehicles.Where(v => v.ServiceID == id).ToList();
            ViewBag.Vehicles = vehicles;
            List<Driver> drivers = DriverRepository.Drivers.Where(d => d.ServiceID == id).ToList();
            List<Reason> reasons = ReasonRepository.Reasons;
            ViewBag.Reasons = reasons;
            ViewBag.Drivers = drivers;

            return View();
        }

        public ActionResult SOSBooking()
        {
            Random random = new Random();
            Booking booking = new Booking
            {
                BookingID = Guid.NewGuid(),
                isSOS = true,
                BookingDate = DateTime.Now,
                PickupTime = DateTime.Now,
                PhoneNumber = "9999999999", // Default phone number for SOS booking
                FullName = "SOS Booking",
                DriverID = random.Next(1, DriverRepository.Drivers.Count + 1),
                VehicleID = random.Next(1, VehicleRepository.Vehicles.Count + 1),
                ReasonID = ReasonRepository.Reasons.FirstOrDefault()?.ReasonID ?? 1,
                PickupAddress = "Emergency Location",
                ServiceID = 1
            };

            Driver driver = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == booking.DriverID);
            if (driver == null)
            {
                booking.DriverID = DriverRepository.Drivers.FirstOrDefault().DriverID;
            }
            Vehicle vehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == booking.VehicleID);

            if (vehicle == null)
            {
                booking.VehicleID = VehicleRepository.Vehicles.FirstOrDefault().VehicleID;
            }
            BookingRepository.Bookings.Add(booking);
            BookingConfirmedViewModel model = new BookingConfirmedViewModel
            {
                Booking = booking,
                Driver = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == booking.DriverID),
                Vehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == booking.VehicleID)
            };
            return View("BookingConfirmed", model);
        }

        public ActionResult CreateBooking(Booking booking)
        {
            if (booking == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Booking data is missing.");
            }

            booking.BookingID = Guid.NewGuid();
            BookingRepository.Bookings.Add(booking);
            booking.isSOS = false;
            BookingConfirmedViewModel model = new BookingConfirmedViewModel
            {
                Booking = booking,
                Driver = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == booking.DriverID),
                Vehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == booking.VehicleID)
            };

            if (model.Driver == null)
            {
                model.Driver = new Driver
                {
                    FirstName = "",
                    LastName = "",
                    PhoneNumber = "",
                    ImagePath = "~/Content/Images/Drivers/default.png"
                };
            }
            if (model.Vehicle == null)
            {
                model.Vehicle = new Vehicle
                {
                    Type = "Unknown",
                    RegistrationNumber = "Unknown",
                    ImagePath = "~/Content/Images/Vehicles/default.png"
                };
            }
            return View("BookingConfirmed", model);
        }

        public ActionResult BookingConfirmed(BookingConfirmedViewModel model)
        {
            return View(model);
        }

        public ActionResult BookingConfirmed2(Guid BookingID)
        {
            Booking booking = BookingRepository.Bookings.FirstOrDefault(b => b.BookingID.Equals(BookingID));
            if (booking == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Booking not found.");
            }
            BookingConfirmedViewModel model = new BookingConfirmedViewModel
            {
                Booking = booking,
                Driver = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == booking.DriverID),
                Vehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == booking.VehicleID)
            };
            if (model.Driver == null)
            {
                model.Driver = new Driver
                {
                    FirstName = "",
                    LastName = "",
                    PhoneNumber = "",
                    ImagePath = "~/Content/Images/Drivers/default.png"
                };
            }
            if (model.Vehicle == null)
            {
                model.Vehicle = new Vehicle
                {
                    Type = "Unknown",
                    RegistrationNumber = "Unknown",
                    ImagePath = "~/Content/Images/Vehicles/default.png"
                };
            }
            return View("BookingConfirmed", model);
        }

        public ActionResult RideHistory()
        {
            List<BookingConfirmedViewModel> bookings = BookingRepository.Bookings
                .Select(b => new BookingConfirmedViewModel
                {
                    Booking = b,
                    Driver = DriverRepository.Drivers.FirstOrDefault(d => d.DriverID == b.DriverID) ?? new Driver
                    {
                        FirstName = "",
                        LastName = "",
                        PhoneNumber = "",
                        ImagePath = "~/Content/Images/Drivers/default.png"
                    },
                    Vehicle = VehicleRepository.Vehicles.FirstOrDefault(v => v.VehicleID == b.VehicleID) ?? new Vehicle
                    {
                        Type = "Unknown",
                        RegistrationNumber = "Unknown",
                        ImagePath = "~/Content/Images/Vehicles/default.png"
                    }
                }).ToList();

            return View(bookings);
        }
    }

}