namespace FM.Metricas.Domain
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public double Salario { get; set; }


        public void CalcularSalario()
        {
            this.Salario = this.Salario * 0.10;
        }
    }

}
