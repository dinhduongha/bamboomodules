
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
[ExposeServices(typeof(IMrpWorkcenterProductivityLossAppService), typeof(MrpWorkcenterProductivityLossClientProxy))]
public partial class MrpWorkcenterProductivityLossClientProxy : ClientProxyBase<IMrpWorkcenterProductivityLossAppService>, IMrpWorkcenterProductivityLossAppService
{
    //public virtual async Task<ListResultDto<MrpWorkcenterProductivityLoss>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpWorkcenterProductivityLoss>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpWorkcenterProductivityLoss>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpWorkcenterProductivityLoss>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpWorkcenterProductivityLoss> GetAsync(Guid id)
    {
        return await RequestAsync<MrpWorkcenterProductivityLoss>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpWorkcenterProductivityLoss> CreateAsync(MrpWorkcenterProductivityLoss input)
    {
        return await RequestAsync<MrpWorkcenterProductivityLoss>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpWorkcenterProductivityLoss), input }
        });
    }

    public virtual async Task<MrpWorkcenterProductivityLoss> UpdateAsync(Guid id, MrpWorkcenterProductivityLoss input)
    {
        return await RequestAsync<MrpWorkcenterProductivityLoss>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpWorkcenterProductivityLoss), input }
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
