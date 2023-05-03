
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
[ExposeServices(typeof(IIrModelConstraintAppService), typeof(IrModelConstraintClientProxy))]
public partial class IrModelConstraintClientProxy : ClientProxyBase<IIrModelConstraintAppService>, IIrModelConstraintAppService
{
    //public virtual async Task<ListResultDto<IrModelConstraint>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrModelConstraint>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrModelConstraint>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrModelConstraint>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrModelConstraint> GetAsync(Guid id)
    {
        return await RequestAsync<IrModelConstraint>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrModelConstraint> CreateAsync(IrModelConstraint input)
    {
        return await RequestAsync<IrModelConstraint>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrModelConstraint), input }
        });
    }

    public virtual async Task<IrModelConstraint> UpdateAsync(Guid id, IrModelConstraint input)
    {
        return await RequestAsync<IrModelConstraint>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrModelConstraint), input }
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