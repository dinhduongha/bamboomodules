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
    public interface IBarcodeNomenclatureAppService : IGenericApplicationService<BarcodeNomenclature>
    {
        Task<BarcodeNomenclature> Gs1DateToDateAsync(Guid id, BarcodeNomenclatureGs1DateToDateRequestDto input);
        Task<BarcodeNomenclature> Gs1DecomposeExtandedAsync(Guid id, BarcodeNomenclatureGs1DecomposeExtandedRequestDto input);
        Task<BarcodeNomenclature> MatchPatternAsync(Guid id, BarcodeNomenclatureMatchPatternRequestDto input);
        Task<BarcodeNomenclature> ParseBarcodeAsync(Guid id, BarcodeNomenclatureParseBarcodeRequestDto input);
        Task<BarcodeNomenclature> ParseGs1RulePatternAsync(Guid id, BarcodeNomenclatureParseGs1RulePatternRequestDto input);
        Task<BarcodeNomenclature> ParseNomenclatureBarcodeAsync(Guid id, BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input);
        Task<BarcodeNomenclature> ParseUriAsync(Guid id, BarcodeNomenclatureParseUriRequestDto input);
        Task<BarcodeNomenclature> SanitizeEanAsync(Guid id, BarcodeNomenclatureSanitizeEanRequestDto input);
        Task<BarcodeNomenclature> SanitizeUpcAsync(Guid id, BarcodeNomenclatureSanitizeUpcRequestDto input);
    }
}