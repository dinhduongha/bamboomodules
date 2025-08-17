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

[Table("auth_oauth_provider")]
public partial class AuthOauthProvider: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("client_id")]
    public string? ClientId { get; set; }

    [Column("auth_endpoint")]
    public string? AuthEndpoint { get; set; }

    [Column("scope")]
    public string? Scope { get; set; }

    [Column("validation_endpoint")]
    public string? ValidationEndpoint { get; set; }

    [Column("data_endpoint")]
    public string? DataEndpoint { get; set; }

    [Column("css_class")]
    public string? CssClass { get; set; }

    [JsonField]
    [Column("body", TypeName = "jsonb")]
    public string? Body { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AuthOauthProviderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("OauthProviderId")]
    [InverseProperty("OauthProvider")]
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AuthOauthProviderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
