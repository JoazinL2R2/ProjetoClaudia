using Microsoft.EntityFrameworkCore;
using ProjetoClaudia.Models;

namespace ProjetoClaudia.Data
{
    public class BancoContext : DbContext
    {
        DbSet<Usuario> Usuario { get; set; }
    }
}
