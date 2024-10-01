namespace ProjetoClaudia.Models
{
    public class Carrinho
    {
        public Carrinho()
        {
            
        }
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public Produto Produto { get; set; } = new Produto();
        public bool Flg_Inativo { get; set; }
    }
}
