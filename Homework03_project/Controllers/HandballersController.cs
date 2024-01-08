using Homework03_project.Domain;
using Homework03_project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Homework03_project.Controllers
{
    [ApiController]
    public class HandballersController : Controller
    {
        private readonly IHandballerRepository _handballerRepository;

        public HandballersController(IHandballerRepository handballerRepository)
        {
            _handballerRepository = handballerRepository;
        }
        [HttpPost("/Players/New")]
        public IActionResult CreatePlayer([FromBody]Handballer player)
        {
            _handballerRepository.CreatePlayer(player);
            return Ok("Player created");
        }

        [HttpDelete("/Players/Delete/{id}")]
        public IActionResult DeletePlayer([FromRoute]int id)
        {
            bool succ = _handballerRepository.DeletePlayer(id);
            if (succ)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("/Players/Get/All")]
        public IActionResult GetPlayers()
        {
            IEnumerable<Handballer> allPlayers = _handballerRepository.GetAllPlayers();
            return Ok(allPlayers);
        }
        [HttpGet("/Players/Get/{id}")]
        public IActionResult GetPlayer([FromRoute]int id)
        {
            Handballer player = _handballerRepository.GetPlayer(id);
            if(player == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(player);
            }
        }
        [HttpPut("/Players/Update/{id}")]
        public IActionResult UpdatePlayer([FromRoute]int id, [FromQuery]string name)
        {
            bool succ = _handballerRepository.UpdatePlayer(id, name);
            if (succ)
            {
                return Ok($"Player with ID = {id} updated");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
