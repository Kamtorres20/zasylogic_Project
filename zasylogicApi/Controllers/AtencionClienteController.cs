using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zasylogicApi.Models;

namespace zasylogicApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AtencionClienteController : ControllerBase
    {
        private readonly AtencionClienteContext _context;

        public AtencionClienteController(AtencionClienteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtencionCliente>>> GetAtencionCliente()
        {
            return await _context.AtencionClientes.ToListAsync();

        }       

        [HttpPost]
        public async Task<ActionResult<AtencionCliente>> PostAtencionCliente(AtencionCliente atencionCliente)
        {

            _context.AtencionClientes.Add(atencionCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtencionCliente", new { id = atencionCliente.AtencionClienteId }, atencionCliente);
        }

    }
}
