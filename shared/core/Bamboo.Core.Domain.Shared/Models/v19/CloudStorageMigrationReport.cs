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
    [Module("cloud_storage_migration", Depends = new[] { "cloud_storage" })]
    [Model("cloud.storage.migration.report", IsTransient = false, IsAuto = false)]
    [Table("cloud_storage_migration_report")]
    public partial class CloudStorageMigrationReport : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

        [Column("all_count")]
        public int? AllCount { get; set; }

        [Column("all_max_size")]
        public int? AllMaxSize { get; set; }

        [Column("all_sum_size")]
        public int? AllSumSize { get; set; }

        [Column("message_count")]
        public int? MessageCount { get; set; }

        [Column("message_max_size")]
        public int? MessageMaxSize { get; set; }

        [Column("message_sum_size")]
        public int? MessageSumSize { get; set; }

        [Column("res_model")]
        public string? ResModel { get; set; }
    }
}