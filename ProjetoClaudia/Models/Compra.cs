namespace ProjetoClaudia.Models
{
    public class Compra
    {
        public Compra(int id, DateTime dataCompra, string valor, int idUsuario,int idProduto)
        {
            Id = id;
            DataCompra = dataCompra;
            Valor = valor;
            Id_Usuario = idUsuario;
            Id_Produto = idProduto;
        }
        public Compra()
        {
            
        }
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Valor { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Produto { get; set; }

        public Usuario Usuario { get; set; } = new Usuario();
        public Produto Produto { get; set; } = new Produto();
    }
}
