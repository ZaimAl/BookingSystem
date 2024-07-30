using BookingSystem.DataAccsess.Models;
using BookingSystem.DataModel.Master.Resource;
using BookingSystem.DataModel.Master.Room;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Provider
{
    public class RoomProvider
    {
        private readonly BookingSystemContext _context;

        public RoomProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        public IQueryable<MstRoom> AllRoom()
        {
            return _context.MstRooms.Where(a => !a.DelDate.HasValue);
        }
        public IQueryable<MstResource> AllResource()
        {
            return _context.MstResources.Where(a => !a.DelDate.HasValue);
        }
        public IQueryable<MstRoomResource> AllRoomResource()
        {
            return _context.MstRoomResources.Where(a => !a.DelDate.HasValue);
        }

        private MstRoom Get(int id)
        {
            return _context.MstRooms.SingleOrDefault(a => a.Id == id);
        }
        private MstRoomResource GetRoomRes(int id)
        {
            return _context.MstRoomResources.SingleOrDefault(a => a.Id == id);
        }
        public void InsertRoom(CreateEditRoomVM model)
        {
            var room = new MstRoom
            {
                Name = model.Name,
                Capasity = model.Capasity,
                Description = model.Description,
                LocationId=model.LocationID,
                Floor=model.Floor,
                RoomColor=model.ColorRoom,
                CreateBy = 1,
                CreateDate = DateTime.Now
            };
            _context.MstRooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(CreateEditRoomVM model)
        {
            var room = Get(model.ID);
            if (room != null)
            {
                room.Name = model.Name;
                room.Capasity = model.Capasity;
                room.Description = model.Description;
                room.LocationId = model.LocationID;
                room.Floor = model.Floor;
                room.RoomColor = model.ColorRoom;
                room.UpdateBy = 2;
                room.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public void InsertRoomRes(CreateEditRoomResVM model,int roomId)
        {
            var room = new MstRoomResource
            {
                ResourceId=model.ResourceId,
                RoomId = roomId,
                CreateBy = 1,
                CreateDate = DateTime.Now
            };
            _context.MstRoomResources.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoomRes(CreateEditRoomResVM model,int roomId)
        {
            var roomRes = GetRoomRes(model.ID);
            if (roomRes != null)
            {
                roomRes.ResourceId= model.ResourceId;
                roomRes.RoomId = roomId;
                roomRes.UpdateBy = 2;
                roomRes.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public void DeleteRoom(int id)
        {
            var room = Get(id);
            if (room != null)
            {
                room.DelBy = 3;
                room.DelDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public IndexRoomVM GetIndexBC(int page)
        {
            var indexRes = new IndexRoomVM();
            var listRes = from a in AllRoom()
                          select new ListRoomVM
                          {
                              ID = a.Id,
                              Name = a.Name,
                              Description = a.Description,
                              Capasity= a.Capasity,
                              ColorRoom=a.RoomColor,
                              LocationID=a.LocationId.Value,
                              Floor=a.Floor.Value,

                          };
            if (page > 0)
            {
                listRes = listRes.Skip((page - 1) * 10).Take(10);
            }
            indexRes.list = listRes.ToList();
            return indexRes;
        }
        public CreateEditRoomVM GetOne(int id)
        {

            var room = new CreateEditRoomVM();
            if (id > 0) 
            {
                var list = Get(id);
                room.ID = list.Id;
                room.LocationID = list.LocationId;
                room.Floor = list.Floor;
                room.Name = list.Name;
                room.Description = list.Description;
                room.Capasity = list.Capasity;
                room.ColorRoom = list.RoomColor;
            }
            room.RoomRes = GetResource(room.ID);
            return room;
        }
        public List<CreateEditRoomResVM> GetResource(int roomId)
        {
            var listRes = (from a in AllResource()
                           select new CreateEditRoomResVM
                           {
                               ResourceId = a.Id,
                               ResourceName = a.Name,
                           }).ToList();

            foreach (var item in listRes)
            {
                GetRoomResource(item, roomId);
            }

            return listRes;
        }

        public void GetRoomResource(CreateEditRoomResVM model, int roomId)
        {
            var resource = (from a in AllRoomResource()
                            where a.RoomId == roomId && a.ResourceId == model.ResourceId
                            select a).FirstOrDefault();

            if (resource != null)
            {
                model.ID = resource.Id;
                model.IsHave = true;
            }
            else
            {
                model.ID = 0;
                model.IsHave = false;
            }
        }

    }
}
