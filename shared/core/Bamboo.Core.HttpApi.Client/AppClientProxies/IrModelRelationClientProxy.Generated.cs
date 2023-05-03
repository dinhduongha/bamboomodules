
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
[ExposeServices(typeof(IIrModelRelationAppService), typeof(IrModelRelationClientProxy))]
public partial class IrModelRelationClientProxy : ClientProxyBase<IIrModelRelationAppService>, IIrModelRelationAppService
{
    //public virtual async Task<ListResultDto<IrModelRelation>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrModelRelation>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrModelRelation>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrModelRelation>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrModelRelation> GetAsync(Guid id)
    {
        return await RequestAsync<IrModelRelation>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrModelRelation> CreateAsync(IrModelRelation input)
    {
        return await RequestAsync<IrModelRelation>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrModelRelation), input }
        });
    }

    public virtual async Task<IrModelRelation> UpdateAsync(Guid id, IrModelRelation input)
    {
        return await RequestAsync<IrModelRelation>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrModelRelation), input }
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
