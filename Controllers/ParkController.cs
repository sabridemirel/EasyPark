using ParkService.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ParkService.Controllers
{
    public class ParksController : ApiController
    {
        private EasyParkServiceContext db = new EasyParkServiceContext();

        // GET: api/Parks
        public IQueryable<ParkDTO> GetParks()
        {
            var parks = from p in db.Park
                        select new ParkDTO()
                        {
                            Id = p.Id,
                            Capacity = p.Capacity,
                            Latitude = p.Latitude,
                            Longitude = p.Longitude,
                            Name = p.Name,
                            ReservationCount = p.ReservationCount,
                            Status = p.Status
                        };

            return parks;
        }

        // GET: api/Parks/0
        [ResponseType(typeof(Park))]
        public async Task<IHttpActionResult> GetPark(int id)
        {
            Park park = await db.Park.FindAsync(id);

            if (park == null)            
                return NotFound();
            
            return Ok(park);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)            
                db.Dispose();  
                      
            base.Dispose(disposing);
        }
    }
}