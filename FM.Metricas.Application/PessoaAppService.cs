using FM.Metricas.Application.Input;
using FM.Metricas.Domain;

namespace FM.Metricas.Application
{
    public class PessoaAppService
    {
        public double VerificarSalario(PessoaInput obj)
        {
            var pessoa = new Pessoa()
            {
                Nome = obj.Nome,
                Sobrenome = obj.Sobrenome,
                Telefone = obj.Telefone,
                Salario = obj.Salario
            };

            pessoa.CalcularSalario();

            if (obj.Salario > 1000)
            {
                obj.Salario = 500;
            }

            return obj.Salario;
        }
    }
}
