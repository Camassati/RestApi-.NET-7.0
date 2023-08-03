using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSimples.DbSimple;
using RestSimples.Entities;

namespace RestSimples.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ResgisterDbContentext _context;
        public RegisterController (ResgisterDbContentext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var simple = _context.Registers.Where(d => !d.IsDeleted).ToList();
            return Ok(simple);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var simple = _context.Registers.SingleOrDefault(d => d.Id == id);
            if(simple == null)
            {
                return NotFound();
            }
            return Ok(simple);
        }
        [HttpPost]
        public IActionResult Post(Register register)
        {
            _context.Registers.Add(register);
            return CreatedAtAction(nameof(GetById), new {id = register.Id}, register);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Register input)
        {
            var simple = _context.Registers.SingleOrDefault(d => d.Id == id);
            if (simple == null)
            {
                return NotFound();
            }
            simple.Update(input.Idade, input.Nome);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            var simple = _context.Registers.SingleOrDefault(d => d.Id == id);
            if(simple == null)
            {
                return NotFound();
            }
            simple.Delete();
            return NoContent();

        }
    }
}
