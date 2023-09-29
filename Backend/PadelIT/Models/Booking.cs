using System;
using System.Collections.Generic;

namespace PadelIT.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int PlayerId { get; set; }

    public int Week { get; set; }

    public int Year { get; set; }

}
