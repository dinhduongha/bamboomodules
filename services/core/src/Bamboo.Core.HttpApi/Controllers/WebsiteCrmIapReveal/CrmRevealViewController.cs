using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCrmIapReveal
{
    [Route("api/v1/sales/CrmRevealView")]
    public partial class CrmRevealViewController : AbpControllerBase
    {
        private readonly ICrmRevealViewAppService _appService;
        public CrmRevealViewController(ICrmRevealViewAppService appService) { _appService = appService; }
    }
}