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
public partial class CertificateKey: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }


    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("PrivateKey") //Many2many
    public virtual ICollection<CertificateCertificate> CertificateCertificatePrivateKeys { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("PublicKey") //Many2many
    public virtual ICollection<CertificateCertificate> CertificateCertificatePublicKeys { get; set; } = null;

    [ForeignKey("TenantId")]
    //[InverseProperty("CertificateKeys")] //Many2One
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CertificateKeyCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CertificateKeyWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
