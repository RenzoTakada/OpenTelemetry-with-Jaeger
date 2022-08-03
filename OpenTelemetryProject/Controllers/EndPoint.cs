using Microsoft.AspNetCore.Mvc;
using OpenTelemetryProject.Domain.Application;
using OpenTelemetryProject.Domain.Core.Request;
using OpenTelemetryProject.Domain.Response;
using System.Collections.Generic;

namespace OpenTelemetryProject.Controllers
{
    [Route("api/OpentelemetryTeste")]
    [ApiController]
    public class EndPoint : ControllerBase
    {

        public readonly IuserCasePessoa _iUserCasePessoa;
        public EndPoint(IuserCasePessoa service)
        {
            _iUserCasePessoa = service;
        }
        [HttpPost]
        public async Task<ResponsePessoa> Pessoa(RequestPessoa request)
        {

            return await _iUserCasePessoa.UsercasePessoa(request);
        }


    }
}
