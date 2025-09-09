using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IWebsiteVisitorAppService : IGenericApplicationService<WebsiteVisitor>
    {
        Task<WebsiteVisitor> SendChatRequestAsync(Guid id);
        Task<WebsiteVisitor> SendMailAsync(Guid id);
        Task<WebsiteVisitor> SendSmsAsync(Guid id);
    }
}