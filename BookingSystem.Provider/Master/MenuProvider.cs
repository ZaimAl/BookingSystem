using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.Menu;
using BookingSystem.DataModel.Master.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Master.Provider
{
    public class MenuProvider
    {
        private readonly BookingSystemContext _context;

        public MenuProvider(BookingSystemContext context)
        {
            this._context = context;
        }
        public IQueryable<MstMenu> AllMenu()
        {
            return _context.MstMenus.Where(a => !a.DelDate.HasValue);
        }
        public List<IndexMenu> GetMenu()
        {
            var list = from a in AllMenu()
                            orderby a.Sequence, a.IsHeader descending
                            select new IndexMenu
                            {
                                ID=a.Id,
                                Name=a.Name,
                                Functions=a.Functions,
                                Sequence=a.Sequence,
                                IsHeader=a.IsHeader
                                };
            return list.ToList();
        }

    }
}
