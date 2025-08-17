using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("test_mass_mailing", Depends = new[] { "mass_mailing", "mass_mailing_sms", "test_mail", "test_mail_sms" })]
    public class UtmTestSourceMixinAppService : ApplicationService, IUtmTestSourceMixinAppService
    {

        public UtmTestSourceMixinAppService() 
        {

        }
    }
}