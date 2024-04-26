using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Telegram.Bot.Exceptions;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bot.Types.InlineQueryResults;
//using Telegram.Bot.Types.ReplyMarkups;

//namespace Telegram.Bot.Services;

namespace Bamboo.LoginUiWeb;

public class UpdateHandlers : ITransientDependency
{
    IConfiguration _configuration;
    public UpdateHandlers(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<UpdateHandlers> _logger;

    public UpdateHandlers(ITelegramBotClient botClient, ILogger<UpdateHandlers> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }
}