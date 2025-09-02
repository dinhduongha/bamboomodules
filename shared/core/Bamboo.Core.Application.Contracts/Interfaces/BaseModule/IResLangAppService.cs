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