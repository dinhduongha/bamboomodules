
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
[ExposeServices(typeof(IIrExportAppService), typeof(IrExportClientProxy))]
public partial class IrExportClientProxy : ClientProxyBase<IIrExportAppService>, IIrExportAppService
{
    //public virtual async Task<ListResultDto<IrExport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrExport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrExport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrExport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrExport> GetAsync(Guid id)
    {
        return await RequestAsync<IrExport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrExport> CreateAsync(IrExport input)
    {
        return await RequestAsync<IrExport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrExport), input }
        });
    }

    public virtual async Task<IrExport> UpdateAsync(Guid id, IrExport input)
    {
        return await RequestAsync<IrExport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrExport), input }
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