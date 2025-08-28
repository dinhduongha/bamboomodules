using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_package_type")]
//[Index("CompanyId", Name = "stock_package_type__company_id_index")]
//[Index("Barcode", Name = "stock_package_type_barcode_uniq", IsUnique = true)]
public partial class StockPackageType
{
}
