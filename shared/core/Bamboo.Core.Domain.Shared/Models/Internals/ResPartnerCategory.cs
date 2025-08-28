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

[Table("res_partner_category")]
//[Index("ParentId", Name = "res_partner_category__parent_id_index")]
//[Index("ParentPath", Name = "res_partner_category__parent_path_index")]
public partial class ResPartnerCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PartnerCategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PartnerCategory")] // One2many
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<ResPartnerCategory> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual ResPartnerCategory? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerCategoryId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerCategory")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerCategoryId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerCategory")] //Many2many // Hidden
    public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizard { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerCategoryId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerCategory")] //Many2many // Hidden
    public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("CategoryId")] // Many2many // Normal
    // [InverseProperty("Category")] // Many2many // Normal
    public virtual ICollection<ResPartner> Partner { get; set; }
}
