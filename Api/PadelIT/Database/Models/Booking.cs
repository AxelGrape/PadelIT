using System;
using System.Collections.Generic;

namespace PadelIT.Database.Models;

public class Booking
{
    public int BookingId { get; set; }

    public int PlayerId { get; set; }

    public DateTime Datetime { get; set; } = DateTime.MinValue;

    //public int Week { get; set; }

    //public int Year { get; set; }

}
