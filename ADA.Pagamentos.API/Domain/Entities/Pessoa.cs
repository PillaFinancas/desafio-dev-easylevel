namespace ADA.Pagamentos.API.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double SalarioAtual { get; set; }

        public double SalarioAnterior { get; set; }
    }
}
