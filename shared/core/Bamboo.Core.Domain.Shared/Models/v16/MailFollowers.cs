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

[Table("mail_followers")]
//[Index("PartnerId", Name = "mail_followers__partner_id_index")]
//[Index("ResId", Name = "mail_followers__res_id_index")]
//[Index("ResModel", Name = "mail_followers__res_model_index")]
//[Index("ResModel", "ResId", "PartnerId", Name = "mail_followers_mail_followers_res_partner_res_model_id_uniq", IsUnique = true)]
public partial class MailFollowers: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("MailFollowers")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailFollowersId")] //Many2many
    // [InverseProperty("MailFollowers")] //Many2many
    public virtual ICollection<MailMessageSubtype> MailMessageSubtype { get; set; }
}
