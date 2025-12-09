using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Bamboo.Admin.Localization;
using Bamboo.Abp.LoginUi.Services;
using System.Threading.Tasks;
using System;

namespace Bamboo.Admin.Controllers;

[AllowAnonymous]
[IgnoreAntiforgeryToken]
public class NonceController : AbpController
{
    protected readonly IWeb3AuthService _web3AuthService;
    public NonceController(IWeb3AuthService web3AuthService)
    : base()
    {
        _web3AuthService = web3AuthService;
    }

    // User có thể dùng nonce này để login với grant type là siwx theo flow openiddict
    [HttpGet]
    [Route("/connect/nonce")]
    public async Task<NonceDto> GetNonceAsync()
    {
        var result = _web3AuthService.GenerateAndCacheNonce();
        return new NonceDto
        {
            Nonce = result.Nonce,
            Iss = DateTimeOffset.UtcNow,
            Exp = 300
        };
    }
}

public class NonceDto
{
    public string Nonce { get; set; }
    public DateTimeOffset Iss { get; set; }
    public long Exp { get; set; }
}