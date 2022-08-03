using OpenTelemetryProject.Domain.Core.Request;
using OpenTelemetryProject.Domain.Response;

namespace OpenTelemetryProject.Domain.Application
{
    public interface IuserCasePessoa
    {
        public Task<ResponsePessoa> UsercasePessoa(RequestPessoa request);
    }

    public class UserCasePessoa : IuserCasePessoa
    {
        public async Task<ResponsePessoa> UsercasePessoa(RequestPessoa request)
        {
            var mock = new RequestPessoa()
            {
                nome = request.nome,
                idade = request.idade,

            };
            var result = new ResponsePessoa(mock);
            return result;
        }
    }
}
