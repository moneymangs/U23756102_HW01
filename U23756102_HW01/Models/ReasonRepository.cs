using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U23756102_HW01.Models
{
    public class ReasonRepository
    {
        public static List<Reason> Reasons = new List<Reason>
{
    new Reason
    {
        ReasonID = 1,
        Description = "Severe Breathing Difficulty"
    },
    new Reason
    {
        ReasonID = 2,
        Description = "Road Traffic Collision"
    },
    new Reason
    {
        ReasonID = 3,
        Description = "Scheduled Hospital Discharge"
    },
    new Reason
    {
        ReasonID = 4,
        Description = "Psychiatric Evaluation Transport"
    },
    new Reason
    {
        ReasonID = 5,
        Description = "Inter-Facility Transfer"
    },
    new Reason
    {
        ReasonID = 6,
        Description = "Flood or Fire Evacuation"
    },
    new Reason
    {
        ReasonID = 7,
        Description = "Event Medical Coverage"
    },
    new Reason
    {
        ReasonID = 8,
        Description = "Support for Vulnerable Persons"
    },
    new Reason
    {
        ReasonID = 9,
        Description = "Critical Care Standby"
    },
};


    }
}