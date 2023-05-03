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

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IIdentityUserAppService), typeof(IdentityUserAppService), typeof(BambooIdentityUserAppService))]
public class BambooIdentityUserAppService : IdentityUserAppService
{
    protected IDataFilter _dataFilter;
    public BambooIdentityUserAppService(
        IDataFilter dataFilter,
        IdentityUserManager userManager,
        IIdentityUserRepository userRepository,
        IIdentityRoleRepository roleRepository,
        IOptions<IdentityOptions> identityOptions
    ) : base(
        userManager,
        userRepository,
        roleRepository,
        identityOptions)
    {
        _dataFilter = dataFilter;
    }

    public async override Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new AbpValidationException(
                "Tenant not allow to create new users!"
            );
        }
        if (input.PhoneNumber.IsNullOrWhiteSpace())
        {
            throw new AbpValidationException(
                "Phone number is required for new users!",
                new List<ValidationResult>
                {
                    new ValidationResult(
                        "Phone number can not be empty!",
                        new []{"PhoneNumber"}
                    )
                }
            );
        }
        if (!ValidationHelper.IsValidEmailAddress(input.Email))
        {
            throw new UserFriendlyException($"Email address is invalid !");
        }
        //using (_dataFilter.Disable<IMultiTenant>())
        //{
        //    var lst = await UserRepository.GetListAsync(filter: input.Email);
        //    if (lst.Count > 0)
        //    {
        //        var exist = lst.Where(x => x.Email == input.Email).FirstOrDefault();
        //        if (exist != null)
        //        {
        //            throw new AbpValidationException(
        //            "Email is used!",
        //            new List<ValidationResult>
        //            {
        //                                new ValidationResult(
        //                                    "Email already in used!",
        //                                    new []{"Email"}
        //                                )
        //            }
        //        );
        //        }
        //    }
        //}
        //input.UserName = input.Email;
        return await base.CreateAsync(input);
    }
}