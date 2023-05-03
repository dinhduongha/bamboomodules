
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
[ExposeServices(typeof(IFollowupPrintAppService), typeof(FollowupPrintClientProxy))]
public partial class FollowupPrintClientProxy : ClientProxyBase<IFollowupPrintAppService>, IFollowupPrintAppService
{
    //public virtual async Task<ListResultDto<FollowupPrint>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<FollowupPrint>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<FollowupPrint>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<FollowupPrint>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<FollowupPrint> GetAsync(Guid id)
    {
        return await RequestAsync<FollowupPrint>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<FollowupPrint> CreateAsync(FollowupPrint input)
    {
        return await RequestAsync<FollowupPrint>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FollowupPrint), input }
        });
    }

    public virtual async Task<FollowupPrint> UpdateAsync(Guid id, FollowupPrint input)
    {
        return await RequestAsync<FollowupPrint>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(FollowupPrint), input }
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
