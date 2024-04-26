using System;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;

using Telegram.Bot.Filters;
using Telegram.Bot.Services;
using Telegram.Bot.Types;
using System.Threading;

namespace Bamboo.LoginUiWeb.Controllers;

[Route("api/twilio")]
public class TelegramBotController : AbpControllerBase
{
    protected IDataSeeder _dataSeeder { get; }

    IHttpClientFactory _httpClientFactory;

    public TelegramBotController(IHttpClientFactory httpFactory)
    {        
        _httpClientFactory = httpFactory;        
    }


    [HttpPost]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    [ValidateTelegramBot]
    public async Task<IActionResult> Post(
        [FromBody] Update update,
        [FromServices] UpdateHandlers handleUpdateService,
        CancellationToken cancellationToken)
    {
        await handleUpdateService.HandleUpdateAsync(update, cancellationToken);
        return Ok();
    }
}
