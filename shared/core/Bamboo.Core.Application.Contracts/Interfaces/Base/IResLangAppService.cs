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
    public interface IResLangAppService : IGenericAppService<ResLang>
    {
        Task<ResLang> ActivateLangsAsync(Guid[] ids);
        Task<object> CACHEDFIELDSAsync(Guid[] ids);
        Task<ResLang> CopyDataAsync(ResLangCopyDataRequestDto input);
        Task<string> FormatAsync(ResLangFormatRequestDto input);
        Task<List<object>> GetInstalledAsync(Guid[] ids);
        Task<ResLang> GetLocalesForSpreadsheetAsync(Guid[] ids);
        Task<ResLang> InstallLangAsync(Guid[] ids);
        Task<ResLang> UnarchiveAsync(Guid[] ids);
    }
}