
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
[ExposeServices(typeof(ICalendarRecurrenceAppService), typeof(CalendarRecurrenceClientProxy))]
public partial class CalendarRecurrenceClientProxy : ClientProxyBase<ICalendarRecurrenceAppService>, ICalendarRecurrenceAppService
{
    //public virtual async Task<ListResultDto<CalendarRecurrence>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<CalendarRecurrence>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<CalendarRecurrence>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<CalendarRecurrence>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<CalendarRecurrence> GetAsync(Guid id)
    {
        return await RequestAsync<CalendarRecurrence>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<CalendarRecurrence> CreateAsync(CalendarRecurrence input)
    {
        return await RequestAsync<CalendarRecurrence>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(CalendarRecurrence), input }
        });
    }

    public virtual async Task<CalendarRecurrence> UpdateAsync(Guid id, CalendarRecurrence input)
    {
        return await RequestAsync<CalendarRecurrence>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(CalendarRecurrence), input }
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