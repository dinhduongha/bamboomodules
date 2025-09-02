using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMailingContactAppService : IGenericApplicationService<MailingContact>
    {
        Task<MailingContact> AddToListAsync(Guid id, MailingContactAddToListRequestDto input);
        Task<MailingContact> AddToMailingListAsync(Guid id);
        Task<MailingContact> GetImportTemplatesAsync(Guid id);
        Task<MailingContact> ImportAsync(Guid id);
    }
}