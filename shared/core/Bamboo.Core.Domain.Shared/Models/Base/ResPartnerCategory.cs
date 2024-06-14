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
public partial class ResPartnerCategory: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    /// TODO: DISABLE INVERSE
    //[InverseProperty("PartnerCategory")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> InverseParent { get; } = new List<ResPartnerCategory>();

    [ForeignKey("ResPartnerCategoryId")]
    //[InverseProperty("ResPartnerCategories")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; } = new List<AccountReconcileModelTemplate>();

    [ForeignKey("ResPartnerCategoryId")]
    //[InverseProperty("ResPartnerCategories")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; } = new List<AccountReconcileModel>();

    [ForeignKey("CategoryId")]
    //[InverseProperty("Categories")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; } = new List<ResPartner>();
}
