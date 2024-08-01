using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.BookingCode;
using BookingSystem.DataModel.Master.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Master.Provider
{
    public class MstResourceProvider
    {
        private readonly BookingSystemContext _context;

        public MstResourceProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        public IQueryable<MstResource> AllResource()
        {
            return _context.MstResources.Where(a => !a.DelDate.HasValue);
        }
        public IQueryable<MstResourceCode> AllResourceCode()
        {
            return _context.MstResourceCodes.Where(a => !a.DelDate.HasValue);
        }

        private MstResource GetRes(int id)
        {
            return _context.MstResources.SingleOrDefault(a => a.Id == id);
        }
        private MstResourceCode GetResCod(int id)
        {
            return _context.MstResourceCodes.SingleOrDefault(a => a.Id == id);
        }
        public void InsertRes(MstCreateEditResVM model)
        {
            var res = new MstResource
            {
                Name = model.Name,
                Status = model.Status,
                Icon= model.Icon,
                CreateBy = 1,
                CreateDate = DateTime.Now
            };
            _context.MstResources.Add(res);
            _context.SaveChanges();
            foreach (var item in model.code)
            {
                if (item.ID > 0)
                {
                    UpdateResCod(item, model.ID);
                }
                else
                {
                    InsertResCod(item, model.ID);
                }
            }
        }

        public void UpdateRes(MstCreateEditResVM model)
        {
            var res = GetRes(model.ID);
            if (res != null)
            {
                res.Name = model.Name;
                res.Status = model.Status;
                res.Icon= model.Icon;
                res.UpdateBy = 2;
                res.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
            foreach (var item in model.code)
            {
                if (item.ID > 0)
                {
                    UpdateResCod(item, model.ID);
                }
                else
                {
                    InsertResCod(item, model.ID);
                }
            }
        }

        public void DeleteRes(int id)
        {
            var res = GetRes(id);
            if (res != null)
            {
                res.DelBy = 3;
                res.DelDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public MstIndexResVM GetIndexBC(int page)
        {
            var indexRes = new MstIndexResVM();
            var listRes = from a in AllResource()
                         select new MstListResVM
                         {
                             ID = a.Id,
                             Name = a.Name,
                             Status = a.Status,
                             Icon = a.Icon,
                         };
            if (page > 0)
            {
                listRes = listRes.Skip((page - 1) * 10).Take(10);
            }
            indexRes.list = listRes.ToList();
            return indexRes;
        }
        public MstCreateEditResVM GetOne(int id)
        {
            var getOne = GetRes(id);
            var res = new MstCreateEditResVM();
            res.Status = getOne.Status;
            res.Icon = getOne.Icon;
            res.Name = getOne.Name;
            res.ID = id;
            res.code = GetListResCode(res.ID);
            return res;
        }
        public List<MstCreateEditResCodMV> GetListResCode(int resourceId)
        {
            var list=from a in AllResourceCode()
                     where a.ResourceId==resourceId
                     select new MstCreateEditResCodMV
                     {
                         ID= a.Id,
                         IsActive=a.IsActive,
                         ResourceCode=a.ResourceCode
                     };
            return list.ToList();
        }
        public void InsertResCod(MstCreateEditResCodMV model,int resourceId) 
        {
            var resCod= new MstResourceCode
            {
                ResourceId=resourceId,
                ResourceCode= model.ResourceCode,
                IsActive= model.IsActive,
                CreateBy = 1,
                CreateDate = DateTime.Now
            };
            _context.MstResourceCodes.Add(resCod);
            _context.SaveChanges();
        }
        public void UpdateResCod(MstCreateEditResCodMV model,int resourceId)
        {
            var resCod = GetResCod(model.ID);
            if (resCod != null)
            {
                resCod.ResourceCode = model.ResourceCode;
                resCod.ResourceId = resourceId;
                resCod.IsActive = model.IsActive;
                resCod.UpdateBy = 2;
                resCod.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public void DeleteResCod(int id)
        {
            var resCod = GetResCod(id);
            if (resCod != null)
            {
                resCod.DelBy = 3;
                resCod.DelDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

    }
}
