using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.BookingCode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Master.Provider
{
    public class BookingCodeProvider
    {
        private readonly BookingSystemContext _context;

        public BookingCodeProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        public IQueryable<MstBookCode> AllBookingCodes()
        {
            return _context.MstBookCodes.Where(a => !a.DelDate.HasValue);
        }

        private MstBookCode Get(int id)
        {
            return _context.MstBookCodes.SingleOrDefault(a => a.Id == id);
        }

        public void InsertBc(CreateEditBCVM model)
        {
            var newBc = new MstBookCode
            {
                BookingCode = model.BookingCode,
                IsActive = model.IsActive,
                CreateBy = 1,
                CreateDate = DateTime.Now
            };
            _context.MstBookCodes.Add(newBc);
            _context.SaveChanges();
        }

        public void UpdateBc(CreateEditBCVM model)
        {
            var bc = Get(model.ID);
            if (bc != null)
            {
                bc.IsActive = model.IsActive;
                bc.BookingCode = model.BookingCode;
                bc.UpdateBy = 2;
                bc.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void DeleteBC(int id)
        {
            var bc = Get(id);
            if (bc != null)
            {
                bc.DelBy = 3;
                bc.DelDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public IndexBCVM GetIndexBC(int page)
        {
            var indexBc = new IndexBCVM();
            var listBc = from a in AllBookingCodes()
                          select new ListBCVM
                          {
                              ID = a.Id,
                              BookingCode = a.BookingCode,
                              IsActive = a.IsActive
                          };
            if(page > 0)
            {
                listBc=listBc.Skip((page-1)*10).Take(10);
            }
            indexBc.list = listBc.ToList();
            return indexBc;
        }
        public CreateEditBCVM GetOne(int id)
        {
            var list = Get(id);
            var bc=new CreateEditBCVM();
            bc.IsActive = list.IsActive;
            bc.BookingCode = list.BookingCode;
            bc.ID = id;
            return bc;
        }
    }
}
