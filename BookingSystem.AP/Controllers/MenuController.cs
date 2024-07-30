using BookingSystem.DataAccsess.Models;
using BookingSystem.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuProvider _menuProvider;

        public MenuController(MenuProvider menuProvider)
        {
            _menuProvider = menuProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var data = _menuProvider.GetMenu();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
