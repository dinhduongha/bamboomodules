
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
[ExposeServices(typeof(IHrHolidaysCancelLeaveAppService), typeof(HrHolidaysCancelLeaveClientProxy))]
public partial class HrHolidaysCancelLeaveClientProxy : ClientProxyBase<IHrHolidaysCancelLeaveAppService>, IHrHolidaysCancelLeaveAppService
{
    //public virtual async Task<ListResultDto<HrHolidaysCancelLeave>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrHolidaysCancelLeave>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrHolidaysCancelLeave>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrHolidaysCancelLeave>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrHolidaysCancelLeave> GetAsync(Guid id)
    {
        return await RequestAsync<HrHolidaysCancelLeave>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrHolidaysCancelLeave> CreateAsync(HrHolidaysCancelLeave input)
    {
        return await RequestAsync<HrHolidaysCancelLeave>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrHolidaysCancelLeave), input }
        });
    }

    public virtual async Task<HrHolidaysCancelLeave> UpdateAsync(Guid id, HrHolidaysCancelLeave input)
    {
        return await RequestAsync<HrHolidaysCancelLeave>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrHolidaysCancelLeave), input }
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
