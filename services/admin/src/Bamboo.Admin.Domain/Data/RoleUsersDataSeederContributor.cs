using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Bamboo.Admin.Data
{
    /* 
    * Creates initial roles/users that is needed to property run the application    
    */
    public class RoleUsersDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IdentityRoleManager _identityRoleManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;
        public RoleUsersDataSeederContributor(
            IConfiguration configuration,
            IdentityUserManager identityUserManager,
            IdentityRoleManager identityRoleManager,
            ICurrentTenant currentTenant, IGuidGenerator guidGenerator)
        {
            _configuration = configuration;
            _identityUserManager = identityUserManager;
            _identityRoleManager = identityRoleManager;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var configurationSection = _configuration.GetSection("App");
            var domain = configurationSection["Domain"]??"bamboo.io";
            var rolesName = configurationSection.GetSection("StaticRole").Get<List<string>>();
            rolesName = new List<string>()
            {
                "admin",
                "owner",
                "manager",
                "guest",
                "administration.administrator",
                "administration.settings",
                "sales.administrator",
                "sales.user",
                "sales.user_owner_only",
                "brand.administrator",
                "brand.user",
                "pos.cashier",
                "pos.administrator",
                "pos.user",
                "inventory.administrator",
                "inventory.user",
                "purchase.administrator",
                "purchase.user",
                "accounting.administrator",
                "accounting.advisor",
                "accounting.accountant",
                "accounting.billing",
                "accounting.auditor",
                "project.administrator",
                "project.user",
                "crm.administrator",
                "crm.officer",
                "crm.user",
                "crm.user_owner_only",
                "manufacture.administrator",
                "manufacture.user",
                "hr.lunch.administrator",
                "hr.lunch.user",
                "hr.fleet.administrator",
                "hr.fleet.user",
                "hr.employee.administrator",
                "hr.employee.officer",
                "hr.employee.user",
                "hr.timeoff.administrator",
                "hr.timeoff.officer",
                "hr.contract.administrator",
                "hr.recruitment.administrator",
                "hr.recruitment.officer",
                "hr.expenses.administrator",
                "hr.expenses.all_approver",
                "hr.expenses.team_approver",
                "hr.attendances.administrator",
                "hr.attendances.officer",
                "hr.attendances.user"
            };
            if (rolesName != null)
            {
                foreach (var r in rolesName)
                {
                    if (!r.IsNullOrEmpty())
                    {
                        IdentityRole role = await _identityRoleManager.FindByNameAsync(r);
                        if (role == null)
                        {
                            role = new IdentityRole(_guidGenerator.Create(), r, _currentTenant.Id)
                            {
                                IsStatic = true,
                                IsPublic = true
                            };
                            try
                            {
                                await _identityRoleManager.CreateAsync(role);
                                //IdentityUser identityUser = new IdentityUser(_guidGenerator.Create(), r, $"{r}@{domain}", _currentTenant.Id);
                                //await _identityUserManager.CreateAsync(identityUser, _guidGenerator.Create().ToString());
                                //await _identityUserManager.AddToRoleAsync(identityUser, r);
                            }
                            catch (Exception e)
                            {
                                var str = e.Message;
                            }
                        }
                    }
                }
            }
        }
    }
}

