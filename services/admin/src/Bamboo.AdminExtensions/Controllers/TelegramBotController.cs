using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;

using Telegram.Bot.Filters;
using Telegram.Bot.Services;
using Telegram.Bot.Types;

namespace Bamboo.AdminExtensions.Controllers;

[Route("api/telegrambot")]
[AllowAnonymous]
public class TelegramBotController : AbpControllerBase
{    
    private readonly IConfiguration _configuration;
    protected string? _token;
    IHttpClientFactory _httpClientFactory;
    //private readonly SignInManager<ApplicationUser> _signInManager;
    //private readonly UserManager<ApplicationUser> _userManager;

    public TelegramBotController(IConfiguration config, IHttpClientFactory httpFactory)
    {
        _httpClientFactory = httpFactory;
        _configuration = config;
        _token = _configuration["Telegram:Key"];
    }


    [HttpPost]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    [ValidateTelegramBot]
    public async Task<IActionResult> Post( string token,
        [FromBody] Update update,
        [FromServices] UpdateHandlers handleUpdateService,
        CancellationToken cancellationToken)
    {
        if (_token == null || token != _token) {
            return Forbid();
        }
        await handleUpdateService.HandleUpdateAsync(update, cancellationToken);
        return Ok();
    }

}
