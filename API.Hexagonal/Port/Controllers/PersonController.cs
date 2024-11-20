using API.Hexagonal.Application.Interfaces;
using API.Hexagonal.Port.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Hexagonal.Port.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController(IPersonService personService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Console.WriteLine($"Getting person with ID: {id}");
                var person = await personService.GetByIdAsync(id);
                return Ok(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "An error occurred while processing your request.");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await personService.GetAllAsync();
            
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCreateOrUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await personService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonCreateOrUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await personService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await personService.DeleteAsync(id);
            return NoContent();
        }
    }
}
