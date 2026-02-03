using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResOrganizationAppService : IGenericAppService<ResOrganization>
    {
        //Task<Guid> CreateTeamAsync(string code, string name, Guid? organizationId, Guid? supervisorId);
        //Task AddMemberToTeamAsync(Guid teamId, Guid userId);
    }
}
namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain")]
    public class ResOrganizationAppService : GenericAppService<ResOrganization>, IResOrganizationAppService
    {
        public ResOrganizationAppService(
            IRepository<ResOrganization, Guid> repository,
            IServiceProvider serviceProvider,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IDistributedCache cache,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
        }

        // public async Task<Guid> CreateTeamAsync(string code, string name, Guid? organizationId, Guid? supervisorId)
        // {
        //     var team = new ResTeam
        //     {
        //         TeamCode = code,
        //         TeamName = name,
        //         OrganizationId = organizationId,
        //         SupervisorId = supervisorId,
        //         IsActive = true
        //     };
        //     await Repository.InsertAsync(team);
        //     return team.Id;
        // }

        // public async Task AddMemberToTeamAsync(Guid teamId, Guid userId)
        // {
        //     var team = await Repository.GetAsync(teamId);
        //     // Logic thêm user vào team (có thể dùng ABP UserManager hoặc custom)
        //     // Ví dụ: user.TeamId = teamId; await userRepository.UpdateAsync(user);
        // }
    }
}