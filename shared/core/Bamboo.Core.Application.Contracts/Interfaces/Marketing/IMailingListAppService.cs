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
    public interface IMailingListAppService : IGenericAppService<MailingList>
    {
        Task<MailingList> CopyDataAsync(MailingListCopyDataRequestDto input);
        Task<MailingList> MergeAsync(MailingListMergeRequestDto input);
        Task<MailingList> OpenImportAsync(Guid[] ids);
        Task<MailingList> SendMailingAsync(Guid[] ids);
        Task<MailingList> SendMailingSmsAsync(Guid[] ids);
        Task<MailingList> ViewContactsAsync(Guid[] ids);
        Task<MailingList> ViewContactsBlacklistedAsync(Guid[] ids);
        Task<MailingList> ViewContactsBouncingAsync(Guid[] ids);
        Task<MailingList> ViewContactsEmailAsync(Guid[] ids);
        Task<MailingList> ViewContactsOptOutAsync(Guid[] ids);
        Task<MailingList> ViewContactsSmsAsync(Guid[] ids);
        Task<MailingList> ViewMailingsAsync(Guid[] ids);
    }
}