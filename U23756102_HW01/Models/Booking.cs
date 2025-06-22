using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U23756102_HW01.Models
{
    public class Booking
    {
        public Guid BookingID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PickupTime { get; set; }
        public string PickupAddress { get; set; }
        public bool isSOS { get; set; }
        public DateTime BookingDate { get; set; }
        public int DriverID { get; set; }
        public int VehicleID { get; set; }
        public int ServiceID { get; set; }
        public int ReasonID { get; set; }

    }
}