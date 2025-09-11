using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Productivity, Module: rating
    [Authorize]
    [Route("api/v1/productivity/RatingRating")]
    public partial class RatingRatingController : AbpController
    {
        private readonly IRatingRatingAppService _appService;
        public RatingRatingController(IRatingRatingAppService appService) { _appService = appService; }
    }
}