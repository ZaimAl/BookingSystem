using BookingSystem.Provider.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingProvider BookProvider;
        public BookingController(BookingProvider BookProvider)
        {
            this.BookProvider = BookProvider;

        }
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            try
            {
                var data = BookProvider.GetIndexBook(page);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
