using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("account_edi_proxy_client_user")]
//[Index("EdiIdentification", "EdiFormatId", Name = "account_edi_proxy_client_user_unique_edi_identification_per_for", IsUnique = true)]
//[Index("IdClient", Name = "account_edi_proxy_client_user_unique_id_client", IsUnique = true)]
public partial class AccountEdiProxyClientUser
{
    [Column("edi_format_id")]
    public Guid? EdiFormatId { get; set; }

    //[JsonIgnore]
    //[Column("private_key")]
    //public byte[]? PrivateKey { get; set; }

    // [Many2one]
    [ForeignKey("EdiFormatId")]
    public virtual AccountEdiFormat? EdiFormat { get; set; }
}
