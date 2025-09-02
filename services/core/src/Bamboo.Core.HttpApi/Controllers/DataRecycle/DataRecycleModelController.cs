using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    [Route("api/v1/productivity/DataRecycleModel")]
    public partial class DataRecycleModelController : AbpControllerBase
    {
        private readonly IDataRecycleModelAppService _appService;
        public DataRecycleModelController(IDataRecycleModelAppService appService) { _appService = appService; }
    }
}