using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Admin.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Admin;

/* Inherit your application services from this class.
 */
public abstract class AdminAppService : ApplicationService
{
    protected AdminAppService()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
