using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.BookingCode;
using BookingSystem.DataModel.Master.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider
{
    public class LocationProvider
    {
        private BookingSystemContext _context;
        public LocationProvider(BookingSystemContext context)
        {
            this._context = context;
        }
        public IQueryable AllBookingCode()
        {
            return _context.MstLocations.Where(a => !a.DelDate.HasValue);
        }
        private MstLocation Get(int Id)
        {
            return _context.MstLocations.SingleOrDefault(a => a.Id == Id);
        }
        public void InsertLoc(CreatEditLVM model)
        {
            var newLoc = new MstLocation();
            newLoc.Name = model.Name;
            newLoc.CreateBy = 1;
            newLoc.CreateDate = DateTime.Now;
            _context.MstLocations.Add(newLoc);
            _context.SaveChanges();
        }

        public void UpdateLoc(CreatEditLVM model)
        {
            var loc = Get(model.ID);
            loc.Name = model.Name;
            loc.Name = model.Name;
            loc.UpdateBy = 2;
            loc.UpdateDate = DateTime.Now;
            _context.SaveChanges();
        }
        public void DeleteLoc(int Id)
        {
            var loc = Get(Id);
            loc.DelBy = 3;
            loc.DelDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
