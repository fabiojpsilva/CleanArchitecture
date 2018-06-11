namespace CleanDemo.UseCases
{
    public class CadastrarTurmaOutput
    {
        public bool Sucesso { get; set; }
        public int Status { get; set; }
        public string Mensagem { get; set; }
        public int TurmaId { get; set; }
    }
}