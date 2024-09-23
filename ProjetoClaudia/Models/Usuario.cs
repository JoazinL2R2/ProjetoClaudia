using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoClaudia.Models
{
    public class Usuario
    {
        public Usuario(int id, string nome, string email, string senha, string cpf, bool genero)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            Genero = genero;
        }
        public Usuario()
        {
            
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column("TipoUsuarioId")]
        public int TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public bool Genero { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
