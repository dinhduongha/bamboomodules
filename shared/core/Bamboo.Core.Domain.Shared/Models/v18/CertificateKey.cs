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

[Table("certificate_key")]
public partial class CertificateKey: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("loading_error")]
    public string? LoadingError { get; set; }

    [Column("public")]
    public bool? Public { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PrivateKeyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PrivateKey")] // One2many
    public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUser { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PrivateKeyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PrivateKey")] // One2many
    public virtual ICollection<CertificateCertificate> CertificateCertificatePrivateKey { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PublicKeyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PublicKey")] // One2many
    public virtual ICollection<CertificateCertificate> CertificateCertificatePublicKey { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
