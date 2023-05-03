
// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;

using Bamboo.Core.Models;
using Bamboo.Core.Services;

// ReSharper disable once CheckNamespace
namespace Bamboo.Core.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IMrpImmediateProductionLineAppService), typeof(MrpImmediateProductionLineClientProxy))]
public partial class MrpImmediateProductionLineClientProxy : ClientProxyBase<IMrpImmediateProductionLineAppService>, IMrpImmediateProductionLineAppService
{
    //public virtual async Task<ListResultDto<MrpImmediateProductionLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpImmediateProductionLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpImmediateProductionLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpImmediateProductionLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpImmediateProductionLine> GetAsync(Guid id)
    {
        return await RequestAsync<MrpImmediateProductionLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpImmediateProductionLine> CreateAsync(MrpImmediateProductionLine input)
    {
        return await RequestAsync<MrpImmediateProductionLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpImmediateProductionLine), input }
        });
    }

    public virtual async Task<MrpImmediateProductionLine> UpdateAsync(Guid id, MrpImmediateProductionLine input)
    {
        return await RequestAsync<MrpImmediateProductionLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpImmediateProductionLine), input }
        });
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }
}
