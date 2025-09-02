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
    public interface IMailingListAppService : IGenericApplicationService<MailingList>
    {
        Task<MailingList> CloseDialogAsync(Guid id);
        Task<MailingList> CopyDataAsync(Guid id, MailingListCopyDataRequestDto input);
        Task<MailingList> MergeAsync(Guid id, MailingListMergeRequestDto input);
        Task<MailingList> OpenImportAsync(Guid id);
        Task<MailingList> SendMailingAsync(Guid id);
        Task<MailingList> SendMailingSmsAsync(Guid id);
        Task<MailingList> ViewContactsAsync(Guid id);
        Task<MailingList> ViewContactsBlacklistedAsync(Guid id);
        Task<MailingList> ViewContactsBouncingAsync(Guid id);
        Task<MailingList> ViewContactsEmailAsync(Guid id);
        Task<MailingList> ViewContactsOptOutAsync(Guid id);
        Task<MailingList> ViewContactsSmsAsync(Guid id);
        Task<MailingList> ViewMailingsAsync(Guid id);
    }
}