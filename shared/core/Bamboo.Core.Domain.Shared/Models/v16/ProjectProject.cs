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

[Table("project_project")]
//[Index("AccountId", Name = "project_project__account_id_index")]
//[Index("Date", Name = "project_project__date_index")]
//[Index("StageId", Name = "project_project__stage_id_index")]
public partial class ProjectProject: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("last_update_id")]
    public Guid? LastUpdateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("privacy_visibility")]
    public string? PrivacyVisibility { get; set; }

    [Column("rating_status")]
    public string? RatingStatus { get; set; }

    [Column("rating_status_period")]
    public string? RatingStatusPeriod { get; set; }

    [Column("last_update_status")]
    public string? LastUpdateStatus { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("label_tasks", TypeName = "jsonb")]
    public string? LabelTasks { get; set; }

    [JsonField]
    [Column("task_properties_definition", TypeName = "jsonb")]
    public string? TaskPropertiesDefinition { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_subtasks")]
    public bool? AllowSubtasks { get; set; }

    [Column("allow_recurring_tasks")]
    public bool? AllowRecurringTasks { get; set; }

    [Column("allow_task_dependencies")]
    public bool? AllowTaskDependencies { get; set; }

    [Column("allow_milestones")]
    public bool? AllowMilestones { get; set; }

    [Column("rating_active")]
    public bool? RatingActive { get; set; }

    [Column("rating_request_deadline", TypeName = "timestamp without time zone")]
    public DateTime? RatingRequestDeadline { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("x_plan2_id")]
    public Guid? XPlan2Id { get; set; }

    [Column("x_plan3_id")]
    public Guid? XPlan3Id { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("reinvoiced_sale_order_id")]
    public Guid? ReinvoicedSaleOrderId { get; set; }

    [Column("allow_billable")]
    public bool? AllowBillable { get; set; }

    [Column("allow_timesheets")]
    public bool? AllowTimesheets { get; set; }

    [Column("allocated_hours")]
    public double? AllocatedHours { get; set; }

    [Column("timesheet_product_id")]
    public Guid? TimesheetProductId { get; set; }

    [Column("billing_type")]
    public string? BillingType { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("ProjectProjectAccount")] //Many2one
    public virtual AccountAnalyticAccount? Account { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProjectProjectCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("TimesheetProjectId")]
    [InverseProperty("TimesheetProject")]
    public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [Many2one]
    [ForeignKey("LastUpdateId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual ProjectUpdate? LastUpdate { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectCollaborator> ProjectCollaborator { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectCreateInvoice> ProjectCreateInvoice { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [One2many]
    [ForeignKey("DisplayProjectId")]
    [InverseProperty("DisplayProject")]
    public virtual ICollection<ProjectTask> ProjectTaskDisplayProject { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectTask> ProjectTaskProject { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<ProjectUpdate> ProjectUpdate { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [Many2one]
    [ForeignKey("ReinvoicedSaleOrderId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual SaleOrder? ReinvoicedSaleOrder { get; set; }

    // [One2many]
    [ForeignKey("InternalProjectId")]
    [InverseProperty("InternalProject")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("SaleLineId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual ProjectProjectStage? Stage { get; set; }

    // [One2many]
    [ForeignKey("ProjectId")]
    [InverseProperty("Project")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetProductId")]
    // [InverseProperty("ProjectProject")] //Many2one
    public virtual ProductProduct? TimesheetProduct { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ProjectProjectUserNavigation")] //Many2one
    public virtual ResUsers? UserNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProjectProjectWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2one]
    [ForeignKey("XPlan2Id")]
    // [InverseProperty("ProjectProjectXPlan2")] //Many2one
    public virtual AccountAnalyticAccount? XPlan2 { get; set; }

    // [Many2one]
    [ForeignKey("XPlan3Id")]
    // [InverseProperty("ProjectProjectXPlan3")] //Many2one
    public virtual AccountAnalyticAccount? XPlan3 { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProjectProjectId")] //Many2many
    // [InverseProperty("ProjectProject")] //Many2many
    public virtual ICollection<ProjectTags> ProjectTags { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectProjectId")]
    // [InverseProperty("ProjectProject")]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizard { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProjectId")] //Many2many
    // [InverseProperty("Project")] //Many2many
    public virtual ICollection<ProjectTaskType> Type { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectId")]
    // [InverseProperty("Project")]
    //public virtual ICollection<ProjectTaskType> Type { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProjectId")] //Many2many
    // [InverseProperty("Project")] //Many2many
    public virtual ICollection<ResUsers> User { get; set; }
}
