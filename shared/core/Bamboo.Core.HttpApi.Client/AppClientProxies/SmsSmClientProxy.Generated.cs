
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
[ExposeServices(typeof(ISmsSmAppService), typeof(SmsSmClientProxy))]
public partial class SmsSmClientProxy : ClientProxyBase<ISmsSmAppService>, ISmsSmAppService
{
    //public virtual async Task<ListResultDto<SmsSm>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SmsSm>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SmsSm>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SmsSm>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SmsSm> GetAsync(Guid id)
    {
        return await RequestAsync<SmsSm>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SmsSm> CreateAsync(SmsSm input)
    {
        return await RequestAsync<SmsSm>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SmsSm), input }
        });
    }

    public virtual async Task<SmsSm> UpdateAsync(Guid id, SmsSm input)
    {
        return await RequestAsync<SmsSm>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SmsSm), input }
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
