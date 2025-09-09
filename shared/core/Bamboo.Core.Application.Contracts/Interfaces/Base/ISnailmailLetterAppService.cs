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
    public interface ISnailmailLetterAppService : IGenericApplicationService<SnailmailLetter>
    {
        Task<SnailmailLetter> CancelAsync(Guid id);
        Task<SnailmailLetter> SnailmailPrintAsync(Guid id);
    }
}