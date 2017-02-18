using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ParkService.Models;

namespace ParkService.Controllers
{
    public class SlotsController : ApiController
    {
        private EasyParkServiceContext db = new EasyParkServiceContext();
       
        // GET: api/Slots/0
        public IQueryable<SlotDTO> GetSlots(int id)
        {
            var slots = from p in db.Slot.Where(p => p.ParkId.Equals(id))
                        select new SlotDTO()
                        {
                            Id = p.Id,
                            Status = p.Status,
                            ParkId = p.ParkId
                        };

            return slots;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)            
                db.Dispose();
                        
            base.Dispose(disposing);
        }
    }
}