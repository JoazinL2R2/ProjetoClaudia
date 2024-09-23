namespace ProjetoClaudia.Models
{
    public class Carrinho
    {
        public Carrinho()
        {
            
        }
        public Usuario Usuario { get; set; } = new Usuario();
        public Produto Produto { get; set; } = new Produto();
    }
}
