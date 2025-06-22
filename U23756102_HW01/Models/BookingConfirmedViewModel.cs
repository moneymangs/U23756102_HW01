using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U23756102_HW01.Models
{
    public class BookingConfirmedViewModel
    {
        public Booking Booking { get; set; }
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}