using Microsoft.EntityFrameworkCore;

namespace zasylogicApi.Models
{
    public class AtencionClienteContext : DbContext
    {
        public AtencionClienteContext(DbContextOptions<AtencionClienteContext> options) : base(options)
        {

        }

        public DbSet<AtencionCliente> AtencionClientes { get; set; }
    }
}
