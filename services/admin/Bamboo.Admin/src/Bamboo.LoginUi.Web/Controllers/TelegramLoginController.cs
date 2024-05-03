using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;

using Telegram.Bot.Extensions.LoginWidget;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Bamboo.LoginUiWeb.Controllers;

[Route("api/telegram")]
public class TelegramLoginController : AbpControllerBase
{
    // https://stackoverflow.com/questions/68157777/implementing-telegram-loginwidget-with-signinmanager
    
    private readonly IConfiguration configuration;
    //private readonly SignInManager<ApplicationUser> _signInManager;
    //private readonly UserManager<ApplicationUser> _userManager;

    public TelegramLoginController(IConfiguration config)
    {
        //_httpClientFactory = httpFactory;
        configuration = config;
    }

    [HttpGet]
    [Route("callback")]
    public async Task<IActionResult> Tgcallback(
        string id,
        string first_name,
        string last_name,
        string username,
        string photo_url,
        string auth_date,
        string hash)
    {
        // attempt to authenticate the login
        var token = configuration["TelegramBot"];
        var loginWidget = new LoginWidget(token);
        var auth = loginWidget.CheckAuthorization(new SortedDictionary<string, string>()
        {
            {"id",id},
            {"first_name", first_name},
            {"last_name", last_name},
            {"username", username},
            {"photo_url", photo_url},
            {"auth_date", auth_date},
            {"hash", hash}
        });

        // if the authorization was successful, create the user (if not exist) and sign in
        if (auth == Authorization.Valid)
        {
            //var user = await _userManager.FindByNameAsync($"tg{id}");
            //if (null == user)
            //{
            //    user = new ApplicationUser()
            //    {
            //        UserName = $"tg{id}",

            //        TelegramNativeId = long.Parse(id),
            //        TelegramUserName = username,
            //        FirstName = first_name,
            //        PhotoUrl = photo_url
            //    };

            //    var result = await _userManager.CreateAsync(user);
            //    if (!result.Succeeded)
            //    {
            //        ViewBag.ErrorTitle = "Internal error";
            //        ViewBag.ErrorMessage = $"Failed to create user tg{id}";
            //        return View("Error");
            //    }

            //    user = await _userManager.FindByNameAsync($"tg{id}");
            //    if (null == user)
            //    {
            //        ViewBag.ErrorTitle = "Internal error";
            //        ViewBag.ErrorMessage = $"Failed to create user tg{id}";
            //        return View("Error");
            //    }
            //}

            //await _signInManager.SignInAsync(user, true);
        }

        // return him back to home/index where he will be redirected to login,
        // if the login was unsuccessful
        //return RedirectToAction("index", "home");
        await Task.CompletedTask;
        return Ok();
    }
}
