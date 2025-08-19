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
public partial class MailAlias: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("alias_domain_id")]
    public Guid? AliasDomainId { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("alias_name")]
    public string? AliasName { get; set; }

    [Column("alias_full_name")]
    public string? AliasFullName { get; set; }

    [Column("alias_contact")]
    public string? AliasContact { get; set; }

    [Column("alias_status")]
    public string? AliasStatus { get; set; }

    [JsonField]
    [Column("alias_bounced_content", TypeName = "jsonb")]
    public string? AliasBouncedContent { get; set; }

    [Column("alias_defaults")]
    public string? AliasDefaults { get; set; }

    [Column("alias_incoming_local")]
    public bool? AliasIncomingLocal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2one]
    [ForeignKey("AliasDomainId")]
    // [InverseProperty("MailAlias")] //Many2one
    public virtual MailAliasDomain? AliasDomain { get; set; }

    // [Many2one]
    [ForeignKey("AliasModelId")]
    // [InverseProperty("MailAliasAliasModel")] //Many2one
    public virtual IrModel? AliasModel { get; set; }

    // [Many2one]
    [ForeignKey("AliasParentModelId")]
    // [InverseProperty("MailAliasAliasParentModel")] //Many2one
    public virtual IrModel? AliasParentModel { get; set; }

    // [Many2one]
    [ForeignKey("AliasUserId")]
    // [InverseProperty("MailAliasAliasUser")] //Many2one
    public virtual ResUsers? AliasUser { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailAliasCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<CrmTeam> CrmTeam { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSource { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<MailGroup> MailGroup { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategory { get; set; }

    // [One2many]
    [ForeignKey("AliasId")]
    [InverseProperty("Alias")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailAliasWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
