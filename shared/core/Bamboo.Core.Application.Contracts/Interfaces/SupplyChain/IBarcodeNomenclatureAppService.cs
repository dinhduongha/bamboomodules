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
    public interface IBarcodeNomenclatureAppService : IGenericApplicationService<BarcodeNomenclature>
    {
        Task<BarcodeNomenclature> Gs1DateToDateAsync(BarcodeNomenclatureGs1DateToDateRequestDto input);
        Task<BarcodeNomenclature> Gs1DecomposeExtendedAsync(BarcodeNomenclatureGs1DecomposeExtendedRequestDto input);
        Task<BarcodeNomenclature> MatchPatternAsync(BarcodeNomenclatureMatchPatternRequestDto input);
        Task<BarcodeNomenclature> ParseBarcodeAsync(BarcodeNomenclatureParseBarcodeRequestDto input);
        Task<BarcodeNomenclature> ParseGs1RulePatternAsync(BarcodeNomenclatureParseGs1RulePatternRequestDto input);
        Task<BarcodeNomenclature> ParseNomenclatureBarcodeAsync(BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input);
        Task<BarcodeNomenclature> ParseUriAsync(BarcodeNomenclatureParseUriRequestDto input);
        Task<BarcodeNomenclature> SanitizeEanAsync(BarcodeNomenclatureSanitizeEanRequestDto input);
        Task<BarcodeNomenclature> SanitizeUpcAsync(BarcodeNomenclatureSanitizeUpcRequestDto input);
    }
}