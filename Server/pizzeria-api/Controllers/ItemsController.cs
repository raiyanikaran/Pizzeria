using Microsoft.AspNetCore.Mvc;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces;
using pizzeria_api.Interfaces.Items;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzeria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;
        public ItemsController(IItemService _itemService)
        {
            itemService = _itemService;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public ActionResult<AllItems> GetAllItems()
        {
            try
            {
                var allItems = itemService.GetAllItems();
                if (allItems != null) return Ok(allItems);
                else return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
