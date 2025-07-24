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
//[Index("ParentId", Name = "res_partner_category_parent_id_index")]
//[Index("ParentPath", Name = "res_partner_category_parent_path_index")]
public partial class ResPartnerCategory : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResPartnerCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual ResPartnerCategory? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResPartnerCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("PartnerCategory")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> InverseParent { get; set; } = new List<ResPartnerCategory>();

    // v16-Compat
    [ForeignKey("ResPartnerCategoryId")]
    //[InverseProperty("ResPartnerCategories")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; set; } = new List<AccountReconcileModelTemplate>();

    [ForeignKey("ResPartnerCategoryId")]
    //[InverseProperty("ResPartnerCategories")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } = new List<AccountReconcileModel>();

    [ForeignKey("ResPartnerCategoryId")]
    //[InverseProperty("ResPartnerCategories")]
    [NotMapped]
    public virtual ICollection<MailingContact> MailingContacts { get; set; } = new List<MailingContact>();

    [ForeignKey("CategoryId")]
    //[InverseProperty("Categories")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; set; } = new List<ResPartner>();

}
