using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
namespace Bamboo.Core.Models
{
    [Module("auth_ldap", Depends = new[] { "base", "base_setup" })]
    [Model("res.company.ldap", IsTransient = false)]
    [Table("res_company_ldap")]
    public partial class ResCompanyLdap : FullAuditedEntity<Guid>
    {

        //<editor-fold desc="ABP ENTITY PROPERTIES">
        [Key]
        public override Guid Id { get => base.Id; protected set => base.Id = value; }

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

        [Many2one(RelatedModel = "res.company")]
        [ForeignKey("TenantId")]
        public virtual ResCompany? Company { get; set; }
        //</editor-fold>

        [Column("create_user")]
        public bool? CreateUser { get; set; }

        [Required]
        [Column("ldap_base")]
        public string LdapBase { get; set; }

        [Column("ldap_binddn")]
        public string? LdapBinddn { get; set; }

        [Required]
        [Column("ldap_filter")]
        public string LdapFilter { get; set; }

        [Column("ldap_password")]
        public string? LdapPassword { get; set; }

        [Required]
        [Column("ldap_server")]
        public string LdapServer { get; set; }

        [Required]
        [Column("ldap_server_port")]
        public int LdapServerPort { get; set; }

        [Column("ldap_tls")]
        public bool? LdapTls { get; set; }

        [Column("sequence")]
        public int? Sequence { get; set; }

        [Column("user_id")] public Guid? UserId { get; set; }
        [Many2one(RelatedModel = "res.users")]
        [ForeignKey("UserId")]
        public virtual ResUsers? User { get; set; }
    }
}