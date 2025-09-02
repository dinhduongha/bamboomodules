using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base")]
    public class ResUsersApikeysShowAppService : ApplicationService, IResUsersApikeysShowAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ResUsersApikeysShowAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }
    }
}