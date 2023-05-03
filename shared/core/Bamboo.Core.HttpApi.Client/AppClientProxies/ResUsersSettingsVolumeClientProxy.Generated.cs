
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
[ExposeServices(typeof(IResUsersSettingsVolumeAppService), typeof(ResUsersSettingsVolumeClientProxy))]
public partial class ResUsersSettingsVolumeClientProxy : ClientProxyBase<IResUsersSettingsVolumeAppService>, IResUsersSettingsVolumeAppService
{
    //public virtual async Task<ListResultDto<ResUsersSettingsVolume>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ResUsersSettingsVolume>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ResUsersSettingsVolume>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ResUsersSettingsVolume>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ResUsersSettingsVolume> GetAsync(Guid id)
    {
        return await RequestAsync<ResUsersSettingsVolume>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ResUsersSettingsVolume> CreateAsync(ResUsersSettingsVolume input)
    {
        return await RequestAsync<ResUsersSettingsVolume>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ResUsersSettingsVolume), input }
        });
    }

    public virtual async Task<ResUsersSettingsVolume> UpdateAsync(Guid id, ResUsersSettingsVolume input)
    {
        return await RequestAsync<ResUsersSettingsVolume>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ResUsersSettingsVolume), input }
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