using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class AccountSetupBankManualConfig
{
    [Column("num_journals_without_account_bank")]
    public long? NumJournalsWithoutAccountBank { get; set; }

    [Column("num_journals_without_account_credit")]
    public long? NumJournalsWithoutAccountCredit { get; set; }
}