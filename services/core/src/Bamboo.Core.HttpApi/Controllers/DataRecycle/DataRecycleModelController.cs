using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    [Route("api/v1/productivity/DataRecycleModel")]
    public partial class DataRecycleModelController : AbpControllerBase
    {
        private readonly IDataRecycleModelAppService _appService;
        public DataRecycleModelController(IDataRecycleModelAppService appService) { _appService = appService; }
    }
}