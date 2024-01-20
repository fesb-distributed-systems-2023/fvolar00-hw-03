using Homework03_project.Controllers.DTO;
using Homework03_project.Domain;
using Homework03_project.Logic;
using Microsoft.AspNetCore.Mvc;
using Homework03_project.Filters;

namespace Homework03_project.Controllers
{
    [ErrorFilter]
    [ApiController]
    public class HandballersController : Controller
    {
        private readonly IHandballerLogic _handballerLogic;

        public HandballersController(IHandballerLogic handballerLogic)
        {
            _handballerLogic = handballerLogic;
        }
        [HttpPost("/Players/New")]
        public IActionResult CreatePlayer([FromBody]HandballerDTO player)
        {
            try
            {
                _handballerLogic.CreatePlayer(player.ToModel());
                return Ok("Player created");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Players/Delete/{id}")]
        public IActionResult DeletePlayer([FromRoute]int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("ID cannot be empty");
                }
                _handballerLogic.DeletePlayer(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("/Players/Get/All")]
        public IActionResult GetPlayers()
        {
            try
            {
                var allPlayers = _handballerLogic.GetAllPlayers().Select(x => HandballerDTO.FromModel(x));
                return Ok(allPlayers);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("/Players/Get/{id}")]
        public IActionResult GetPlayer([FromRoute]int id)
        {
            var player = _handballerLogic.GetPlayer(id);
            if(player == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(HandballerDTO.FromModel(player));
            }
        }
        [HttpPut("/Players/Update/{id}")]
        public IActionResult UpdatePlayer([FromRoute]int id, [FromQuery]string name)
        {
            try
            {
                _handballerLogic.UpdatePlayer(id, name);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
