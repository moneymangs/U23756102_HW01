using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U23756102_HW01.Models
{
    public class ServiceRepository
    {
        public static List<Service> Services = new List<Service>
    {
        new Service {
            ServiceID = 1,
            Name = "Advanced Life Support",
            Description = "Advanced Life Support (ALS) ambulances are staffed by highly trained paramedics and " +
            "equipped with advanced medical equipment to transport patients requiring a higher level of care. " +
            "These ambulances are ideal for emergencies where critical monitoring, intervention, and support are essential during transit.",
            ImagePath = "~/Content/Images/Services/advanced life support.png",
            Drivers = new List<Driver>(),
            Vehicles = new List<Vehicle>()
        },
        new Service {
            ServiceID = 2,
            Name = "Basic Life Support",
            Description = "Basic Life Support (BLS) ambulances provide safe and professional transport for patients in stable, non-life-threatening conditions." +
            " These units are equipped for essential medical monitoring and staffed by trained personnel to ensure comfort and care during transit.",
            ImagePath = "~/Content/Images/Services/basic life support.png",
            Drivers = new List<Driver>(),
            Vehicles = new List<Vehicle>()
        },
        new Service {
            ServiceID = 3,
            Name = "Patient Support",
            Description = "Patient Support services offer essential non-emergency transport for individuals requiring basic ambulatory assistance to and from medical facilities. " +
            "This service ensures patients travel safely and comfortably under professional supervision.",
            ImagePath = "~/Content/Images/Services/patient support.png",
            Drivers = new List<Driver>(){
                
            },
            
        },
        new Service {
            ServiceID = 4,
            Name = "Medical Utility Vehicle",
            Description = "Medical Utility Vehicles are specially equipped vans, both small and large, designed to facilitate the safe and efficient transport of patients or medical supplies. " +
            "These vehicles support non-emergency mobility while ensuring comfort, reliability, and adherence to healthcare standards",
            ImagePath = "~/Content/Images/Services/medical utility vehicle.png",
            Drivers = new List<Driver>(),
            Vehicles = new List<Vehicle>()
        },
        new Service {
            ServiceID = 5,
            Name = "Event Medical Ambulance",
            Description = "AEvent Medical Ambulances are strategically stationed at gatherings such as concerts, sports events, and festivals to ensure immediate medical assistance. " +
            "Staffed by qualified professionals, these ambulances offer on-site emergency care, promoting the safety and well-being of all attendees.",
            ImagePath = "~/Content/Images/Services/event.png",
            Drivers = new List<Driver>(),
            Vehicles = new List<Vehicle>()
        },
        new Service {
            ServiceID = 6,
            Name = "Air Ambulance",
            Description  = "Air Ambulance services provide rapid and reliable transportation for patients over long distances, " +
            "ensuring timely medical assistance in both emergency and non-emergency situations. Our trained medical personnel and well-equipped aircraft ensure safety, " +
            "comfort, and continuous care throughout the journey",

            ImagePath = "~/Content/Images/Services/air.png",
            Drivers = new List<Driver>(),
            Vehicles = new List<Vehicle>()
        }
    };

        public static List<Booking> Bookings = new List<Booking>();

        
        public static List<Reason> reasons = new List<Reason>
        {
            new Reason { ReasonID = 1, Description = "Medical Emergency" },
            new Reason { ReasonID = 2, Description = "Non-Medical Emergency" },
            new Reason { ReasonID = 3, Description = "Routine Checkup" },
            new Reason { ReasonID = 4, Description = "Other" }
        };

        
    }
}