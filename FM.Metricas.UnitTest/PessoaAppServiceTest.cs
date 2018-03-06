using FM.Metricas.Application;
using FM.Metricas.Application.Input;
using Xunit;

namespace FM.Metricas.UnitTest
{
    public class PessoaAppServiceTest
    {
        private PessoaAppService _appService;
        public PessoaAppServiceTest()
        {
            _appService = new PessoaAppService();
        }

        [Fact]
        public void Deve_Ter_Salario_500()
        {
            var input = new PessoaInput();

            input.Nome = "Neymar";
            input.Sobrenome = "Junior";
            input.Telefone = "123456789";
            input.Salario = 20000.00;

            var retornoSalario = _appService.VerificarSalario(input);

            Assert.Equal(500, retornoSalario);
        }

        [Fact]
        public void Deve_Manter_Salario()
        {
            var input = new PessoaInput();

            input.Nome = "Fernando";
            input.Sobrenome = "Mendes";
            input.Telefone = "123456789";
            input.Salario = 800.00;

            var retornoSalario = _appService.VerificarSalario(input);

            Assert.Equal(800, retornoSalario);
        }
    }
}
