using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Transaction.Booking;
using BookingSystem.DataModel.Transaction.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider.Transaction
{
    public class TrsResourceProvider
    {
        private readonly BookingSystemContext _context;

        public TrsResourceProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        public IQueryable<TrsResource> AllTrsResource()
        {
            return _context.TrsResources.Where(a=>!a.DeletedDate.HasValue);
        }
        public TrsIndexResourceVm GetIndexBook(int page)
        {
            var indexRes = new TrsIndexResourceVm();
            var listRes = from a in AllTrsResource()
                          select new TrsListResourceVM
                          {
                              Id = a.Id,
                              ResourceName=a.ResCode.Resource.Name,
                              ResourceCode=a.ResCode.ResourceCode,
                              RoomName=a.Book.Room.Name,
                              RequestBy=a.Book.RequestBy,
                              TimeFrom=a.Book.TimeFrom,
                              TimeTo=a.Book.TimeTo,
                              Date=a.Book.Date,
                              Status=a.Book.Status

                          };
            if (page > 0)
            {
                listRes = listRes.Skip((page - 1) * 10).Take(10);
            }
            indexRes.List = listRes.ToList();
            return indexRes;
        }
    }
}
