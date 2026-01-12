using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Barcodes", Category = "Supply Chain", Depends = new[] { "web" })]
    public class BarcodeNomenclatureAppService : GenericApplicationService<BarcodeNomenclature>, IBarcodeNomenclatureAppService
    {

        public BarcodeNomenclatureAppService(IRepository<BarcodeNomenclature, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<BarcodeNomenclature> CheckPatternInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def _check_pattern(self):
            // for nom in self:
            //     if nom.is_gs1_nomenclature and nom.gs1_separator_fnc1:
            //         try:
            //             re.compile("(?:%s)?" % nom.gs1_separator_fnc1)
            //         except re.error as error:
            //             raise ValidationError(_("The FNC1 Separator Alternative is not a valid Regex: %(error)s", error))
            */
            return default;
        }

        protected async Task<BarcodeNomenclature> ConvertUriGtinDataIntoTrackingNumberInternalAsync(object base_code, object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def _convert_uri_gtin_data_into_tracking_number(self, base_code, data):
            // gs1_company_prefix, item_ref_and_indicator, tracking_number = data
            // indicator = item_ref_and_indicator[0]
            // item_ref = item_ref_and_indicator[1:]
            // product_barcode = indicator + gs1_company_prefix + item_ref
            // product_barcode += str(get_barcode_check_digit(product_barcode + '0'))
            // return [
            //     {
            //         'base_code': base_code,
            //         'code': product_barcode,
            //         'encoding': '',
            //         'type': 'product',
            //         'value': product_barcode,
            //     },
            //     {
            //         'base_code': base_code,
            //         'code': tracking_number,
            //         'encoding': '',
            //         'type': 'lot',
            //         'value': tracking_number,
            //     },
            // ]
            */
            return default;
        }

        protected async Task<BarcodeNomenclature> ConvertUriSsccDataIntoPackageInternalAsync(object base_code, object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def _convert_uri_sscc_data_into_package(self, base_code, data):
            // gs1_company_prefix, serial_reference = data
            // extension = serial_reference[0]
            // serial_ref = serial_reference[1:]
            // sscc = extension + gs1_company_prefix + serial_ref
            // sscc += str(get_barcode_check_digit(sscc + '0'))
            // return [{
            //     'base_code': base_code,
            //     'code': sscc,
            //     'encoding': '',
            //     'type': 'package',
            //     'value': sscc,
            // }]
            */
            return default;
        }

        public async Task<BarcodeNomenclature> Gs1DateToDateAsync(Guid id, BarcodeNomenclatureGs1DateToDateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def gs1_date_to_date(self, gs1_date):
            // """ Converts a GS1 date into a datetime.date.
            // 
            // :param gs1_date: A year formated as yymmdd
            // :type gs1_date: str
            // :return: converted date
            // :rtype: datetime.date
            // """
            // # See 7.12 Determination of century in dates:
            // # https://www.gs1.org/sites/default/files/docs/barcodes/GS1_General_Specifications.pdf
            // now = datetime.date.today()
            // current_century = now.year // 100
            // substract_year = int(gs1_date[0:2]) - (now.year % 100)
            // century = (51 <= substract_year <= 99 and current_century - 1) or\
            //     (-99 <= substract_year <= -50 and current_century + 1) or\
            //     current_century
            // year = century * 100 + int(gs1_date[0:2])
            // 
            // if gs1_date[-2:] == '00':  # Day is not mandatory, when not set -> last day of the month
            //     date = datetime.datetime.strptime(str(year) + gs1_date[2:4], '%Y%m')
            //     date = date.replace(day=calendar.monthrange(year, int(gs1_date[2:4]))[1])
            // else:
            //     date = datetime.datetime.strptime(str(year) + gs1_date[2:], '%Y%m%d')
            // return date.date()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> Gs1DecomposeExtandedAsync(Guid id, BarcodeNomenclatureGs1DecomposeExtandedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def gs1_decompose_extanded(self, barcode):
            // """Try to decompose the gs1 extanded barcode into several unit of information using gs1 rules.
            // 
            // Return a ordered list of dict
            // """
            // self.ensure_one()
            // separator_group = FNC1_CHAR + "?"
            // if self.gs1_separator_fnc1:
            //     separator_group = "(?:%s)?" % self.gs1_separator_fnc1
            // # zxing-library patch, removing GS1 identifiers
            // for identifier in [']C1', ']e0', ']d2', ']Q3', ']J1', FNC1_CHAR]:
            //     if barcode.startswith(identifier):
            //         barcode = barcode.replace(identifier, '', 1)
            //         break
            // results = []
            // gs1_rules = self.rule_ids.filtered(lambda r: r.encoding == 'gs1-128')
            // 
            // def find_next_rule(remaining_barcode):
            //     for rule in gs1_rules:
            //         match = re.search("^" + rule.pattern + separator_group, remaining_barcode)
            //         # If match and contains 2 groups at minimun, the first one need to be the AI and the second the value
            //         # We can't use regex nammed group because in JS, it is not the same regex syntax (and not compatible in all browser)
            //         if match and len(match.groups()) >= 2:
            //             res = self.parse_gs1_rule_pattern(match, rule)
            //             if res:
            //                 return res, remaining_barcode[match.end():]
            //     return None
            // 
            // while len(barcode) > 0:
            //     res_bar = find_next_rule(barcode)
            //     # Cannot continue -> Fail to decompose gs1 and return
            //     if not res_bar or res_bar[1] == barcode:
            //         return None
            //     barcode = res_bar[1]
            //     results.append(res_bar[0])
            // 
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> MatchPatternAsync(Guid id, BarcodeNomenclatureMatchPatternRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def match_pattern(self, barcode, pattern):
            // """Checks barcode matches the pattern and retrieves the optional numeric value in barcode.
            // 
            // :param barcode:
            // :type barcode: str
            // :param pattern:
            // :type pattern: str
            // :return: an object containing:
            //     - value: the numerical value encoded in the barcode (0 if no value encoded)
            //     - base_code: the barcode in which numerical content is replaced by 0's
            //     - match: boolean
            // :rtype: dict
            // """
            // match = {
            //     'value': 0,
            //     'base_code': barcode,
            //     'match': False,
            // }
            // 
            // barcode = barcode.replace('\\', '\\\\').replace('{', '\\{').replace('}', '\\}').replace('.', '\\.')
            // numerical_content = re.search("[{][N]*[D]*[}]", pattern)  # look for numerical content in pattern
            // 
            // if numerical_content:  # the pattern encodes a numerical content
            //     num_start = numerical_content.start()  # start index of numerical content
            //     num_end = numerical_content.end()  # end index of numerical content
            //     value_string = barcode[num_start:num_end - 2]  # numerical content in barcode
            // 
            //     whole_part_match = re.search("[{][N]*[D}]", numerical_content.group())  # looks for whole part of numerical content
            //     decimal_part_match = re.search("[{N][D]*[}]", numerical_content.group())  # looks for decimal part
            //     whole_part = value_string[:whole_part_match.end() - 2]  # retrieve whole part of numerical content in barcode
            //     decimal_part = "0." + value_string[decimal_part_match.start():decimal_part_match.end() - 1]  # retrieve decimal part
            //     if whole_part == '':
            //         whole_part = '0'
            //     if whole_part.isdigit():
            //         match['value'] = int(whole_part) + float(decimal_part)
            // 
            //         match['base_code'] = barcode[:num_start] + (num_end - num_start - 2) * "0" + barcode[num_end - 2:]  # replace numerical content by 0's in barcode
            //         match['base_code'] = match['base_code'].replace("\\\\", "\\").replace("\\{", "{").replace("\\}", "}").replace("\\.", ".")
            //         pattern = pattern[:num_start] + (num_end - num_start - 2) * "0" + pattern[num_end:]  # replace numerical content by 0's in pattern to match
            // match['match'] = re.match(pattern, match['base_code'][:len(pattern)])
            // 
            // return match
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> ParseBarcodeAsync(Guid id, BarcodeNomenclatureParseBarcodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def parse_barcode(self, barcode):
            // if re.match(r'^urn:', barcode):
            //     return self.parse_uri(barcode)
            // return self.parse_nomenclature_barcode(barcode)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> ParseGs1RulePatternAsync(Guid id, BarcodeNomenclatureParseGs1RulePatternRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def parse_gs1_rule_pattern(self, match, rule):
            // result = {
            //     'rule': rule,
            //     'type': rule.type,
            //     'ai': match.group(1),
            //     'string_value': match.group(2),
            // }
            // if rule.gs1_content_type == 'measure':
            //     try:
            //         decimal_position = 0  # Decimal position begins at the end, 0 means no decimal.
            //         if rule.gs1_decimal_usage:
            //             decimal_position = int(match.group(1)[-1])
            //         if decimal_position > 0:
            //             result['value'] = float(match.group(2)[:-decimal_position] + "." + match.group(2)[-decimal_position:])
            //         else:
            //             result['value'] = int(match.group(2))
            //     except Exception:
            //         raise ValidationError(_(
            //             "There is something wrong with the barcode rule \"%s\" pattern.\n"
            //             "If this rule uses decimal, check it can't get sometime else than a digit as last char for the Application Identifier.\n"
            //             "Check also the possible matched values can only be digits, otherwise the value can't be casted as a measure.",
            //             rule.name))
            // elif rule.gs1_content_type == 'identifier':
            //     # Check digit and remove it of the value
            //     if match.group(2)[-1] != str(get_barcode_check_digit("0" * (18 - len(match.group(2))) + match.group(2))):
            //         return None
            //     result['value'] = match.group(2)
            // elif rule.gs1_content_type == 'date':
            //     if len(match.group(2)) != 6:
            //         return None
            //     result['value'] = self.gs1_date_to_date(match.group(2))
            // else:  # when gs1_content_type == 'alpha':
            //     result['value'] = match.group(2)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> ParseNomenclatureBarcodeAsync(Guid id, BarcodeNomenclatureParseNomenclatureBarcodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def parse_nomenclature_barcode(self, barcode):
            // """ Attempts to interpret and parse a barcode.
            // 
            // :param barcode:
            // :type barcode: str
            // :return: A object containing various information about the barcode, like as:
            //     - code: the barcode
            //     - type: the barcode's type
            //     - value: if the id encodes a numerical value, it will be put there
            //     - base_code: the barcode code with all the encoding parts set to
            //       zero; the one put on the product in the backend
            // :rtype: dict
            // """
            // parsed_result = {
            //     'encoding': '',
            //     'type': 'error',
            //     'code': barcode,
            //     'base_code': barcode,
            //     'value': 0,
            // }
            // 
            // for rule in self.rule_ids:
            //     cur_barcode = barcode
            //     if rule.encoding == 'ean13' and check_barcode_encoding(barcode, 'upca') and self.upc_ean_conv in ['upc2ean', 'always']:
            //         cur_barcode = '0' + cur_barcode
            //     elif rule.encoding == 'upca' and check_barcode_encoding(barcode, 'ean13') and barcode[0] == '0' and self.upc_ean_conv in ['ean2upc', 'always']:
            //         cur_barcode = cur_barcode[1:]
            // 
            //     if not check_barcode_encoding(barcode, rule.encoding):
            //         continue
            // 
            //     match = self.match_pattern(cur_barcode, rule.pattern)
            //     if match['match']:
            //         if rule.type == 'alias':
            //             barcode = rule.alias
            //             parsed_result['code'] = barcode
            //         else:
            //             parsed_result['encoding'] = rule.encoding
            //             parsed_result['type'] = rule.type
            //             parsed_result['value'] = match['value']
            //             parsed_result['code'] = cur_barcode
            //             if rule.encoding == "ean13":
            //                 parsed_result['base_code'] = self.sanitize_ean(match['base_code'])
            //             elif rule.encoding == "upca":
            //                 parsed_result['base_code'] = self.sanitize_upc(match['base_code'])
            //             else:
            //                 parsed_result['base_code'] = match['base_code']
            //             return parsed_result
            // 
            // return parsed_result
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def parse_nomenclature_barcode(self, barcode):
            // if self.is_gs1_nomenclature:
            //     return self.gs1_decompose_extanded(barcode)
            // return super().parse_nomenclature_barcode(barcode)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> ParseUriAsync(Guid id, BarcodeNomenclatureParseUriRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def parse_uri(self, barcode):
            // """ Convert supported URI format (lgtin, sgtin, sgtin-96, sgtin-198,
            // sscc and ssacc-96) into a GS1 barcode.
            // :param barcode str: the URI as a string.
            // :rtype: str
            // """
            // if not re.match(r'^urn:', barcode):
            //     return barcode
            // identifier, data = (bc_part.strip() for bc_part in re.split(':', barcode)[-2:])
            // data = re.split(r'\.', data)
            // match identifier:
            //     case 'lgtin' | 'sgtin':
            //         barcode = self._convert_uri_gtin_data_into_tracking_number(barcode, data)
            //     case 'sgtin-96' | 'sgtin-198':
            //         # Same as SGTIN but we have to remove the filter.
            //         barcode = self._convert_uri_gtin_data_into_tracking_number(barcode, data[1:])
            //     case 'sscc':
            //         barcode = self._convert_uri_sscc_data_into_package(barcode, data)
            //     case 'sscc-96':
            //         # Same as SSCC but we have to remove the filter.
            //         barcode = self._convert_uri_sscc_data_into_package(barcode, data[1:])
            // return barcode
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BarcodeNomenclature> PreprocessGs1SearchArgsInternalAsync(object args, object barcode_types, object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: barcode_nomenclature.py) ---
            // def _preprocess_gs1_search_args(self, args, barcode_types, field='barcode'):
            // """Helper method to preprocess 'args' in _search method to add support to
            // search with GS1 barcode result.
            // Cut off the padding if using GS1 and searching on barcode. If the barcode
            // is only digits to keep the original barcode part only.
            // """
            // nomenclature = self.env.company.nomenclature_id
            // if nomenclature.is_gs1_nomenclature:
            //     for i, arg in enumerate(args):
            //         if not isinstance(arg, (list, tuple)) or len(arg) != 3:
            //             continue
            //         field_name, operator, value = arg
            //         if field_name != field or operator not in ['ilike', 'not ilike', '=', '!='] or value is False:
            //             continue
            // 
            //         parsed_data = []
            //         try:
            //             parsed_data += nomenclature.parse_barcode(value) or []
            //         except (ValidationError, ValueError):
            //             pass
            // 
            //         replacing_operator = 'ilike' if operator in ['ilike', '='] else 'not ilike'
            //         for data in parsed_data:
            //             data_type = data['type']
            //             value = data['value']
            //             if data_type in barcode_types:
            //                 if data_type == 'lot':
            //                     args[i] = (field_name, operator, value)
            //                     break
            //                 match = re.match('0*([0-9]+)$', str(value))
            //                 if match:
            //                     unpadded_barcode = match.groups()[0]
            //                     args[i] = (field_name, replacing_operator, unpadded_barcode)
            //                 break
            // 
            //         # The barcode isn't a valid GS1 barcode, checks if it can be unpadded.
            //         if not parsed_data:
            //             match = re.match('0+([0-9]+)$', value)
            //             if match:
            //                 args[i] = (field_name, replacing_operator, match.groups()[0])
            // return args
            */
            return default;
        }

        public async Task<BarcodeNomenclature> SanitizeEanAsync(Guid id, BarcodeNomenclatureSanitizeEanRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def sanitize_ean(self, ean):
            // """ Returns a valid zero padded EAN-13 from an EAN prefix.
            // 
            // :type ean: str
            // """
            // ean = ean[0:13].zfill(13)
            // return ean[0:-1] + str(get_barcode_check_digit(ean))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BarcodeNomenclature> SanitizeUpcAsync(Guid id, BarcodeNomenclatureSanitizeUpcRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_nomenclature.py) ---
            // def sanitize_upc(self, upc):
            // """ Returns a valid zero padded UPC-A from a UPC-A prefix.
            // 
            // :type upc: str
            // """
            // return self.sanitize_ean('0' + upc)[1:]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}