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

[Table("mail_alias")]
//[Index("AliasName", Name = "mail_alias_alias_unique", IsUnique = true)]
public partial class MailAlias: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("alias_model_id")]
    public Guid? AliasModelId { get; set; }

    [Column("alias_user_id")]
    public Guid? AliasUserId { get; set; }

    [Column("alias_force_thread_id")]
    public Guid? AliasForceThreadId { get; set; }

    [Column("alias_parent_model_id")]
    public Guid? AliasParentModelId { get; set; }

    [Column("alias_parent_thread_id")]
    public Guid? AliasParentThreadId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("alias_name")]
    public string? AliasName { get; set; }

    [Column("alias_contact")]
    public string? AliasContact { get; set; }

    [Column("alias_bounced_content", TypeName = "jsonb")]
    public string? AliasBouncedContent { get; set; }

    [Column("alias_defaults")]
    public string? AliasDefaults { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AliasModelId")]
    //[InverseProperty("MailAliasAliasModels")]
    [NotMapped]
    public virtual IrModel? AliasModel { get; set; }

    [ForeignKey("AliasParentModelId")]
    //[InverseProperty("MailAliasAliasParentModels")]
    [NotMapped]
    public virtual IrModel? AliasParentModel { get; set; }

    [ForeignKey("AliasUserId")]
    //[InverseProperty("MailAliasAliasUsers")]
    [NotMapped]
    public virtual ResUser? AliasUser { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailAliasCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailAliasWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; } = new List<CrmTeam>();

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSources { get; } = new List<HrRecruitmentSource>();

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("Alias")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

}
