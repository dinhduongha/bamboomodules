using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;

namespace Bamboo.Abp.LoginUi.Web
{
    // Attribute này bảo ABP: "Hãy dùng class của tôi thay thế cho cái mặc định"
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(ISecurityStampValidator))]
    public class SwitchTenantSecurityStampValidator : AbpSecurityStampValidator
    {
        public SwitchTenantSecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
        SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
        ILoggerFactory loggerFactory,
        ITenantConfigurationProvider tenantConfigurationProvider,
        ICurrentTenant currentTenant)
            : base(options, signInManager, loggerFactory, tenantConfigurationProvider, currentTenant)
        {
        }

        public override async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            // 1. Kiểm tra xem User này có phải đang Switch Tenant không?
            // Dựa vào Claim đặc biệt mà ta đã nhúng ở Controller
            var isSwitchUser = context.Principal.FindFirst("OriginalHostUserId") != null;

            if (isSwitchUser)
            {
                // 2. NẾU ĐÚNG: BỎ QUA MỌI KIỂM TRA DB
                // Không gọi base.ValidateAsync() -> Đồng nghĩa với việc chấp nhận Cookie hợp lệ.
                return;
            }

            // 3. NẾU SAI (User thường): Chạy logic chuẩn của ABP (Check DB, Check SecurityStamp...)
            await base.ValidateAsync(context);
        }
    }
}