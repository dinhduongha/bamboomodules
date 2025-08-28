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

//[Table("account_bank_statement_line")]
//[Index("MoveId", Name = "account_bank_statement_line__move_id_index")]
//[Index("InternalIndex", Name = "account_bank_statement_line_internal_index_index")]
//[Index("UniqueImportId", Name = "account_bank_statement_line_unique_import_id", IsUnique = true)]
public partial class AccountBankStatementLine
{
    [Column("unique_import_id")]
    public string? UniqueImportId { get; set; }
}
