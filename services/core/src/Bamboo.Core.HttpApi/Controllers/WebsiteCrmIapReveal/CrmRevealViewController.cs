using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCrmIapReveal
{
    [Route("api/v1/sales/CrmRevealView")]
    public partial class CrmRevealViewController : AbpControllerBase
    {
        private readonly ICrmRevealViewAppService _appService;
        public CrmRevealViewController(ICrmRevealViewAppService appService) { _appService = appService; }
    }
}