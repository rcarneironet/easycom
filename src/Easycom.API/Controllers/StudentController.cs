using Easycom.Core.DTO;
using Easycom.Core.Entities;
using Easycom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easycom.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Student), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] StudentDTO student)
        {
            var data = await _service.AddAsync(student);
            return Created(nameof(Get), data);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var data = await _service.ListAsync(0, 100); //sample for pagination
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student), 202)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] StudentDTO dto)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            await _service.UpdateAsync(id, dto);

            return Accepted();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student), 202)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}