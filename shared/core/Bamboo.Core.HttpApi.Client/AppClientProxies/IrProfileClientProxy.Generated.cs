
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
[ExposeServices(typeof(IIrProfileAppService), typeof(IrProfileClientProxy))]
public partial class IrProfileClientProxy : ClientProxyBase<IIrProfileAppService>, IIrProfileAppService
{
    //public virtual async Task<ListResultDto<IrProfile>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrProfile>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrProfile>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrProfile>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrProfile> GetAsync(Guid id)
    {
        return await RequestAsync<IrProfile>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrProfile> CreateAsync(IrProfile input)
    {
        return await RequestAsync<IrProfile>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrProfile), input }
        });
    }

    public virtual async Task<IrProfile> UpdateAsync(Guid id, IrProfile input)
    {
        return await RequestAsync<IrProfile>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrProfile), input }
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
