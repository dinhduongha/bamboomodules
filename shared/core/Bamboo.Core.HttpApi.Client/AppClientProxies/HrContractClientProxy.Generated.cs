
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
[ExposeServices(typeof(IHrContractAppService), typeof(HrContractClientProxy))]
public partial class HrContractClientProxy : ClientProxyBase<IHrContractAppService>, IHrContractAppService
{
    //public virtual async Task<ListResultDto<HrContract>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrContract>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrContract>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrContract>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrContract> GetAsync(Guid id)
    {
        return await RequestAsync<HrContract>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrContract> CreateAsync(HrContract input)
    {
        return await RequestAsync<HrContract>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrContract), input }
        });
    }

    public virtual async Task<HrContract> UpdateAsync(Guid id, HrContract input)
    {
        return await RequestAsync<HrContract>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrContract), input }
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
