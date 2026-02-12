using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class EventMeetingRoomAppService
    {

        protected async Task<EventMeetingRoom> ArchiveMeetingRoomsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: _archive_meeting_rooms) ---
            */
            return default;
        }

        protected async Task<EventMeetingRoom> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: _compute_website_url) ---
            */
            return default;
        }
    }
}