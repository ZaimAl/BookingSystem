using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.Room;
using BookingSystem.DataModel.Transaction.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider.Transaction
{
    public class BookingProvider
    {
        private readonly BookingSystemContext _context;

        public BookingProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        public IQueryable<TrsBooking> AllBooking()
        {
            return _context.TrsBookings;
        }
        public IndexBookVM GetIndexBook(int page)
        {
            var indexRes = new IndexBookVM();
            var listRes = from a in AllBooking()
                          select new ListBookVM 
                          {
                              Id = a.Id,
                              RoomName= a.Room.Name,
                              Necessity= a.Necessity,
                              RequestBy= a.RequestBy,
                              Date= a.Date,
                              TimeFrom= a.TimeFrom,
                              TimeTo=a.TimeTo,
                              BookCode= a.BookCode.BookingCode,
                              Status=a.Status,

                          };
            if (page > 0)
            {
                listRes = listRes.Skip((page - 1) * 10).Take(10);
            }
            indexRes.list = listRes.ToList();
            return indexRes;
        }


    }
}
