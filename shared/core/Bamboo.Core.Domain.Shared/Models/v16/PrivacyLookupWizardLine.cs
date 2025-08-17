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

[Table("privacy_lookup_wizard_line")]
public partial class PrivacyLookupWizardLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("res_name")]
    public string? ResName { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("execution_details")]
    public string? ExecutionDetails { get; set; }

    [Column("has_active")]
    public bool? HasActive { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("is_unlinked")]
    public bool? IsUnlinked { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PrivacyLookupWizardLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    // [InverseProperty("PrivacyLookupWizardLine")] //Many2one
    public virtual IrModel? ResModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("WizardId")]
    // [InverseProperty("PrivacyLookupWizardLine")] //Many2one
    public virtual PrivacyLookupWizard? Wizard { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PrivacyLookupWizardLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
