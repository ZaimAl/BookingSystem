using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataModel.Transaction.Resource
{
    public class TrsListResourceVM
    {
        public int Id { get; set; }

        public string ResourceName { get; set; }

        public string ResourceCode { get; set; }

        public string RoomName { get; set; }

        public string RequestBy { get; set; }

        public TimeOnly TimeFrom { get; set; }

        public TimeOnly? TimeTo { get; set; }

        public DateOnly Date { get; set; }

        public string Status { get; set; }

    }
}
