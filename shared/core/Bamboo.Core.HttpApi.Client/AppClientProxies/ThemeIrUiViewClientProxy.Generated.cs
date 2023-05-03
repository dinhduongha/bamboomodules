
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
[ExposeServices(typeof(IThemeIrUiViewAppService), typeof(ThemeIrUiViewClientProxy))]
public partial class ThemeIrUiViewClientProxy : ClientProxyBase<IThemeIrUiViewAppService>, IThemeIrUiViewAppService
{
    //public virtual async Task<ListResultDto<ThemeIrUiView>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ThemeIrUiView>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ThemeIrUiView>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ThemeIrUiView>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ThemeIrUiView> GetAsync(long id)
    {
        return await RequestAsync<ThemeIrUiView>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<ThemeIrUiView> CreateAsync(ThemeIrUiView input)
    {
        return await RequestAsync<ThemeIrUiView>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ThemeIrUiView), input }
        });
    }

    public virtual async Task<ThemeIrUiView> UpdateAsync(long id, ThemeIrUiView input)
    {
        return await RequestAsync<ThemeIrUiView>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(ThemeIrUiView), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}