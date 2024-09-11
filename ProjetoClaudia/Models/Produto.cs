namespace ProjetoClaudia.Models
{
    public class Produto
    {
        public Produto(int id, string nome, int quantidade, bool flg_Inativo, string valor)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Flg_Inativo = flg_Inativo;
            Valor = valor;
        }
        public Produto()
        {
            
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public bool Flg_Inativo { get; set; }
        public string Valor { get; set; }
    }
}
