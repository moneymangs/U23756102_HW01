using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;

namespace U23756102_HW01.Models
{
    public class VehicleRepository
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>()
{
    new Vehicle {
        VehicleID = 1,
        Type = "Rapid Response Unit",
        RegistrationNumber = "YTG-783",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/V1.png"),
        ServiceID = 1
    },
    new Vehicle {
        VehicleID = 2,
        Type = "Medical Van",
        RegistrationNumber = "HJS-374",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/V2.png"),
        ServiceID = 2
    },
    new Vehicle {
        VehicleID = 3,
        Type = "Wheelchair Transport",
        RegistrationNumber = "ODK-039",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v3.png"),
        ServiceID = 4
    },
    new Vehicle {
        VehicleID = 4,
        Type = "Stretcher Transport",
        RegistrationNumber = "NFN-272",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v4.png"),
        ServiceID = 3
    },
    new Vehicle {
        VehicleID = 5,
        Type = "Supply Vehicle",
        RegistrationNumber = "XBS-927",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v5.png"),
        ServiceID = 4
    },
    new Vehicle {
        VehicleID = 6,
        Type = "Critical Care Ambulance",
        RegistrationNumber = "WXZ-928",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v6.png"),
        ServiceID = 1
    },
    new Vehicle {
        VehicleID = 7,
        Type = "High-Risk Evacuation",
        RegistrationNumber = "BFJ-405",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v7.png"),
        ServiceID = 2
    },
    new Vehicle {
        VehicleID = 8,
        Type = "Fire Medical Unit",
        RegistrationNumber = "HYB-427",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v8.png"),
        ServiceID = 3
    },
    new Vehicle {
        VehicleID = 9,
        Type = "Mobile Health Bus",
        RegistrationNumber = "WKL-938",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v9.png"),
        ServiceID = 4
    },
    new Vehicle {
        VehicleID = 10,
        Type = "Equipment Transporter",
        RegistrationNumber = "JDJ-999",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Vehicles/v10.png"),
        ServiceID = 2
    },
};


        public static class ImageHelper
        {
            public static string ImageToBase64(string relativePath)
            {
                var absolutePath = HostingEnvironment.MapPath(relativePath);
                if (absolutePath == null || !File.Exists(absolutePath))
                    return null;

                byte[] imageBytes = File.ReadAllBytes(absolutePath);
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}