using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Snailmail
{
    [Route("api/v1/snailmail/SnailmailLetter")]
    public partial class SnailmailLetterController : AbpControllerBase
    {
        private readonly ISnailmailLetterAppService _appService;
        public SnailmailLetterController(ISnailmailLetterAppService appService) { _appService = appService; }
    }
}