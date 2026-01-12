using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Productivity/Data Cleaning, Module: data_recycle
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/DataRecycleModel")]
    public partial class DataRecycleModelController : AbpController
    {
        private readonly IDataRecycleModelAppService _appService;
        public DataRecycleModelController(IDataRecycleModelAppService appService) { _appService = appService; }
    }
}