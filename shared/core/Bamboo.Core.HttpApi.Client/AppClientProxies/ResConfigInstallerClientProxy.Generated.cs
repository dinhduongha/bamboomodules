
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
[ExposeServices(typeof(IResConfigInstallerAppService), typeof(ResConfigInstallerClientProxy))]
public partial class ResConfigInstallerClientProxy : ClientProxyBase<IResConfigInstallerAppService>, IResConfigInstallerAppService
{
    //public virtual async Task<ListResultDto<ResConfigInstaller>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ResConfigInstaller>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ResConfigInstaller>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ResConfigInstaller>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ResConfigInstaller> GetAsync(Guid id)
    {
        return await RequestAsync<ResConfigInstaller>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ResConfigInstaller> CreateAsync(ResConfigInstaller input)
    {
        return await RequestAsync<ResConfigInstaller>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ResConfigInstaller), input }
        });
    }

    public virtual async Task<ResConfigInstaller> UpdateAsync(Guid id, ResConfigInstaller input)
    {
        return await RequestAsync<ResConfigInstaller>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ResConfigInstaller), input }
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
