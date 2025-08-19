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

[Table("hr_job")]
//[Index("IsPublished", Name = "hr_job__is_published_index")]
//[Index("WebsiteId", Name = "hr_job__website_id_index")]
//[Index("Name", "CompanyId", "DepartmentId", Name = "hr_job_name_company_uniq", IsUnique = true)]
public partial class HrJob: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("expected_employees")]
    public long? ExpectedEmployees { get; set; }

    [Column("no_of_employee")]
    public long? NoOfEmployee { get; set; }

    [Column("no_of_recruitment")]
    public long? NoOfRecruitment { get; set; }

    [Column("no_of_hired_employee")]
    public long? NoOfHiredEmployee { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("contract_type_id")]
    public Guid? ContractTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    // v16-Compat
    //[Column("description")]
    //public string? Description { get; set; }

    [Column("requirements")]
    public string? Requirements { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("hr_responsible_id")]
    public Guid? HrResponsibleId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("industry_id")]
    public Guid? IndustryId { get; set; }

    // [Column("no_of_hired_employee")]
    // public long? NoOfHiredEmployee { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [JsonField]
    [Column("job_properties", TypeName = "jsonb")]
    public string? JobProperties { get; set; }

    [JsonField]
    [Column("applicant_properties_definition", TypeName = "jsonb")]
    public string? ApplicantPropertiesDefinition { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("published_date")]
    public DateTime? PublishedDate { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [JsonField]
    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [JsonField]
    [Column("job_details", TypeName = "jsonb")]
    public string? JobDetails { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractTypeId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual HrContractType? ContractType { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrJobCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [One2many]
    [ForeignKey("JobId")]
    [InverseProperty("Job")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("JobId")]
    [InverseProperty("Job")]
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [ForeignKey("JobId")]
    [InverseProperty("Job")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [ForeignKey("JobId")]
    [InverseProperty("Job")]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSource { get; set; }

    // [Many2one]
    [ForeignKey("HrResponsibleId")]
    // [InverseProperty("HrJobHrResponsible")] //Many2one
    public virtual ResUsers? HrResponsible { get; set; }

    // [Many2one]
    [ForeignKey("IndustryId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual ResPartnerIndustry? Industry { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("SurveyId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual SurveySurvey? Survey { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrJobUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("HrJob")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrJobWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrJobId")]
    // [InverseProperty("HrJob")]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStage { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrJobId")] //Many2many
    // [InverseProperty("HrJob")] //Many2many
    public virtual ICollection<HrSkill> HrSkill { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrJobId")] //Many2many
    // [InverseProperty("HrJob")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrJobId")] //Many2many
    // [InverseProperty("HrJobNavigation")] //Many2many
    public virtual ICollection<ResUsers> ResUsersNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("JobId")] //Many2many
    // [InverseProperty("Job")] //Many2many
    public virtual ICollection<ResUsers> UserNavigation { get; set; }
}
