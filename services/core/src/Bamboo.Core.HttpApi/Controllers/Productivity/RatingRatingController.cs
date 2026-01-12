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
    // Category: Productivity, Module: rating
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/RatingRating")]
    public partial class RatingRatingController : AbpController
    {
        private readonly IRatingRatingAppService _appService;
        public RatingRatingController(IRatingRatingAppService appService) { _appService = appService; }
    }
}