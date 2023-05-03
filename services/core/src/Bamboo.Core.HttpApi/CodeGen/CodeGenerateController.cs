using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Bamboo.CodeGenerators;

namespace Bamboo.Core.Controllers;

[Area(CoreRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CoreRemoteServiceConsts.RemoteServiceName)]
[Route("api/v1/core/CodeGenerate")]
public class CodeGeneratorController : CoreController
{
    public CodeGeneratorController()
    {
    }

    [HttpGet]
    //[Authorize]
    public async Task GetAsync()
    {
        var genCode = new CodeGenerator();
        genCode.Init();
        genCode.GenCode();
        await Task.CompletedTask;
    }
}

