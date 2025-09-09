using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    [Route("api/v1/productivity/DataRecycleModel")]
    public partial class DataRecycleModelController : AbpController
    {
        private readonly IDataRecycleModelAppService _appService;
        public DataRecycleModelController(IDataRecycleModelAppService appService) { _appService = appService; }
    }
}