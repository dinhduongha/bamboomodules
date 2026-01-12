// using Volo.Abp.Domain.Entities;
// using System;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Collections.Generic;
// using Bamboo.Core.Models;
// using Bamboo.Core.Domain.Shared.Interfaces;
// using Bamboo.Core.Domain.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models
{
    [Module("website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    [Model("website.technical.page", IsTransient = false, IsAuto = false)]
    [Table("website_technical_page")]
    public partial class WebsiteTechnicalPage : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
    {

        //<editor-fold desc="ABP ENTITY PROPERTIES">
        [Key]
        public Guid Id { get => base.Id; set => base.Id = value; }

        [Column("company_id")]
        public Guid? TenantId { get; set; }

        [Column("create_date")]
        public override DateTime CreationTime { get => base.CreationTime; protected set => base.CreationTime = value; }

        [Column("create_uid")]
        public override Guid? CreatorId { get => base.CreatorId; protected set => base.CreatorId = value; }

        [Column("write_date")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }

        [Column("write_uid")]
        public override Guid? LastModifierId { get => base.LastModifierId; set => base.LastModifierId = value; }

        [ForeignKey(nameof(CreatorId))]
        public virtual ResUsers? Creator { get; protected set; }

        [ForeignKey(nameof(LastModifierId))]
        public virtual ResUsers? LastModifier { get; protected set; }
        //</editor-fold>

        [Column("name")]
        public string? Name { get; set; }

        [Column("website_url")]
        public string? WebsiteUrl { get; set; }
    }
}