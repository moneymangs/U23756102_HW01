using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static U23756102_HW01.Models.VehicleRepository;

namespace U23756102_HW01.Models
{
    public class DriverRepository
    {
        public static List<Driver> Drivers = new List<Driver>
{
    new Driver
    {
        DriverID = 1,
        FirstName = "Jacob",
        LastName = "Smith",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv1.png"),
        PhoneNumber = "+21 3700 900 101",
        ServiceID = 1
    },
    new Driver
    {
        DriverID = 2,
        FirstName = "Camelia",
        LastName = "Ronda",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv2.png"),
        PhoneNumber = "+21 4700 900 102",
        ServiceID = 2
    },
    new Driver
    {
        DriverID = 3,
        FirstName = "Jake",
        LastName = "Black",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv3.png"),
        PhoneNumber = "+21 7700 900 103",
        ServiceID = 3
    },
    new Driver
    {
        DriverID = 4,
        FirstName = "Taylor",
        LastName = "Smith",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv4.png"),
        PhoneNumber = "+21 7700 900 104",
        ServiceID = 4
    },
    new Driver
    {
        DriverID = 5,
        FirstName = "Akhona",
        LastName = "Radebe",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv5.png"),
        PhoneNumber = "+21 7300 900 105",
        ServiceID = 5
    },
    new Driver
    {
        DriverID = 6,
        FirstName = "Mikayla",
        LastName = "Brown",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv6.png"),
        PhoneNumber = "+21 1700 900 106",
        ServiceID = 1
    },
    new Driver
    {
        DriverID = 7,
        FirstName = "Author",
        LastName = "Prinsloo",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv7.png"),
        PhoneNumber = "+21 4700 900 107",
        ServiceID = 2
    },
    new Driver
    {
        DriverID = 8,
        FirstName = "Ryan",
        LastName = "MCarthy",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv1.png"),
        PhoneNumber = "+21 4700 900 108",
        ServiceID = 3
    },
    new Driver
    {
        DriverID = 9,
        FirstName = "Alfred",
        LastName = "Smith",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv3.png"),
        PhoneNumber = "+21 7700 900 109",
        ServiceID = 4
    },
    new Driver
    {
        DriverID = 10,
        FirstName = "Lily",
        LastName = "Jones",
        ImagePath = "data:image/jpeg;base64," + ImageHelper.ImageToBase64("~/Content/Images/Drivers/dv4.png"),
        PhoneNumber = "+21 7700 900 110",
        ServiceID = 5
    },
};



    }
}