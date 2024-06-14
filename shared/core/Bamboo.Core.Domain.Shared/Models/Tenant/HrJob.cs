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
//[Index("IsPublished", Name = "hr_job_is_published_index")]
//[Index("Name", "TenantId", "DepartmentId", Name = "hr_job_name_company_uniq", IsUnique = true)]
//[Index("WebsiteId", Name = "hr_job_website_id_index")]
public partial class HrJob: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

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

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("contract_type_id")]
    public long? ContractTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("requirements")]
    public string? Requirements { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [Column("job_details", TypeName = "jsonb")]
    public string? JobDetails { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [ForeignKey("AddressId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual ResPartner? Address { get; set; }

    [ForeignKey("AliasId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ContractTypeId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual HrContractType? ContractType { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrJobCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("HrResponsibleId")]
    //[InverseProperty("HrJobHrResponsibles")]
    [NotMapped]
    public virtual ResUser? HrResponsible { get; set; }

    [ForeignKey("ManagerId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual HrEmployee? Manager { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("HrJobUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrJobWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Job")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("Job")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //[InverseProperty("Job")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("Job")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSources { get; } = new List<HrRecruitmentSource>();

    [ForeignKey("HrJobId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStages { get; } = new List<HrRecruitmentStage>();

    //[ForeignKey("HrJobId")]
    //[InverseProperty("HrJobs")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();

    //[ForeignKey("HrJobId")]
    //[InverseProperty("HrJobsNavigation")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsersNavigation { get; } = new List<ResUser>();

    [ForeignKey("JobId")]
    //[InverseProperty("Jobs")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; } = new List<ResUser>();
}
