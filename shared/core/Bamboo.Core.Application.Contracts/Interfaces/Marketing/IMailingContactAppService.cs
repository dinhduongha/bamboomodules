using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMailingContactAppService : IGenericAppService<MailingContact>
    {
        Task<MailingContact> AddToListAsync(MailingContactAddToListRequestDto input);
        Task<MailingContact> AddToMailingListAsync(Guid[] ids);
        Task<MailingContact> GetImportTemplatesAsync(Guid[] ids);
        Task<MailingContact> ImportAsync(Guid[] ids);
    }
}