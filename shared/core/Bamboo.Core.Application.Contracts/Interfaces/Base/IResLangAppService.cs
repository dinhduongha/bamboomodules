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
    public interface IResLangAppService : IGenericApplicationService<ResLang>
    {
        Task<ResLang> ActivateLangsAsync(Guid id);
        Task<object> CACHEDFIELDSAsync(Guid id);
        Task<ResLang> CopyDataAsync(Guid id, ResLangCopyDataRequestDto input);
        Task<string> FormatAsync(Guid id, ResLangFormatRequestDto input);
        Task<List<object>> GetInstalledAsync(Guid id);
        Task<ResLang> GetLocalesForSpreadsheetAsync(Guid id);
        Task<ResLang> InstallLangAsync(Guid id);
        Task<ResLang> ToggleActiveAsync(Guid id);
    }
}