using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataModel.Transaction.Booking
{
    public class ListBookVM
    {
        public int Id { get; set; }

        public string RoomName { get; set; }

        public string Necessity { get; set; } = null!;

        public string RequestBy { get; set; } = null!;

        public DateOnly Date { get; set; }

        public TimeOnly TimeFrom { get; set; }

        public string EmailPic { get; set; } = null!;

        public bool IsAllDay { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CancelledDate { get; set; }

        public int? CancelledBy { get; set; }

        public bool? IsRecurring { get; set; }

        public string? RecurringPattern { get; set; }

        public string BookCode { get; set; }

        public string? Status { get; set; }


        public TimeOnly? TimeTo { get; set; }

    }

}
