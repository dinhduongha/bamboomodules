using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCrmIapReveal
{
    [Route("api/v1/sales/CrmRevealView")]
    public partial class CrmRevealViewController : AbpController
    {
        private readonly ICrmRevealViewAppService _appService;
        public CrmRevealViewController(ICrmRevealViewAppService appService) { _appService = appService; }
    }
}