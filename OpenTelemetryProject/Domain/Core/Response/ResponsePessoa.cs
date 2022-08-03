using OpenTelemetryProject.Domain.Core.Request;

namespace OpenTelemetryProject.Domain.Response
{
    public record ResponsePessoa
    {
        public string Nome { get; set; }
        public int idade { get; set; }


        public ResponsePessoa(RequestPessoa request)
        {
            this.Nome = request.nome;
            this.idade = request.idade;
        }
    }
}
