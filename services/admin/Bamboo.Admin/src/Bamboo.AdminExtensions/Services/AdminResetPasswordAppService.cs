using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;


using Bamboo.AdminExtensions.Dtos;
namespace Bamboo.AdminExtensions;


public interface IAdminResetPasswordAppService : IApplicationService, IRemoteService
{
    Task AdminResetPasswordAsync(AdminResetPasswordDto input);
}

public class AdminResetPasswordAppService : ApplicationService, ITransientDependency, IAdminResetPasswordAppService
{
    protected IDataFilter _dataFilter;
    IdentityUserManager UserManager;
    public AdminResetPasswordAppService(
        IDataFilter dataFilter,
        IdentityUserManager userManager
    )
    {
        _dataFilter = dataFilter;
        UserManager = userManager;
    }

    [Authorize("Admin,Manager")]
    public async Task AdminResetPasswordAsync(AdminResetPasswordDto input)
    {
        if (CurrentTenant.Id != null)
        {
            throw new UserFriendlyException("Not host admin");
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            //await IdentityOptions.SetAsync();

            var user = await UserManager.GetByIdAsync(input.Id);
            if (user == null)
            {
                throw new UserFriendlyException("User not found");
            }
            var resetToken = await UserManager.GeneratePasswordResetTokenAsync(user);
            var result = await UserManager.ResetPasswordAsync(user, resetToken, input.Password);
            if (result.Succeeded == false)
            {
                var str = result.ToString();
                throw new UserFriendlyException(result.ToString());
            }
            await UserManager.SetLockoutEndDateAsync(user, null);

            //await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            //{
            //    UserName = user.UserName,
            //    Identity = IdentitySecurityLogIdentityConsts.Identity,
            //    Action = IdentitySecurityLogActionConsts.ChangePassword
            //});
        }
    }
}

