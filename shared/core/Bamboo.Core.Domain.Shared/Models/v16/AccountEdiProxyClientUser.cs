using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("account_edi_proxy_client_user")]
//[Index("EdiIdentification", "EdiFormatId", Name = "account_edi_proxy_client_user_unique_edi_identification_per_for", IsUnique = true)]
//[Index("IdClient", Name = "account_edi_proxy_client_user_unique_id_client", IsUnique = true)]
public partial class AccountEdiProxyClientUser: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("edi_format_id")]
    public Guid? EdiFormatId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("id_client")]
    public string? IdClient { get; set; }

    [Column("edi_identification")]
    public string? EdiIdentification { get; set; }

    [Column("refresh_token")]
    public string? RefreshToken { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("private_key")]
    public byte[]? PrivateKey { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountEdiProxyClientUser")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountEdiProxyClientUserCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EdiFormatId")]
    // [InverseProperty("AccountEdiProxyClientUser")] //Many2one
    public virtual AccountEdiFormat? EdiFormat { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountEdiProxyClientUserWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
