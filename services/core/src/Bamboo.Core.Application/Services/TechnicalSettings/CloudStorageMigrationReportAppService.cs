using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("CloudStorageMigration", Category = "TechnicalSettings", Depends = new[] { "cloud_storage" })]
    public partial class CloudStorageMigrationReportAppService : GenericApplicationService<CloudStorageMigrationReport>, ICloudStorageMigrationReportAppService
    {

        public CloudStorageMigrationReportAppService(IRepository<CloudStorageMigrationReport, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<CloudStorageMigrationReport> ComputeAllToMigrateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def _compute_all_to_migrate(self):
            // model_names = self.env['ir.config_parameter'].sudo().get_param('cloud_storage_migration_all_models', '').split(',')
            // model_names = {m_ for m in model_names if (m_ := m.strip()) and m_ in self.env}
            // for record in self:
            //     record.all_to_migrate = record.res_model in model_names
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeHasAttachmentRelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def _compute_has_attachment_rel(self):
            // for record in self:
            //     model_cls = self.env.registry.get(record.res_model)
            //     record.has_attachment_rel = model_cls and any(
            //         f for f in model_cls._fields.values() if f.relational and f.comodel_name == 'ir.attachment')
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeMessageToMigrateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def _compute_message_to_migrate(self):
            // model_names = self.env['ir.config_parameter'].sudo().get_param('cloud_storage_migration_message_models', '').split(',')
            // model_names = {m_ for m in model_names if (m_ := m.strip()) and m_ in self.env}
            // for record in self:
            //     record.message_to_migrate = record.res_model in model_names
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeResModelNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def _compute_res_model_name(self):
            // model_names = self.env['ir.model'].search_fetch([('model', 'in', self.mapped('res_model'))], ['model', 'name'])
            // model_names = {model.model: model.name for model in model_names}
            // for record in self:
            //     record.res_model_name = f"{model_names.get(record.res_model, 'unknown')} ({record.res_model})"
            */
            return default;
        }

        public async Task<CloudStorageMigrationReport> GetProgressAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def get_progress(self):
            // max_attachment_id = int(self.env['ir.config_parameter'].get_param('cloud_storage_migration_max_attachment_id', 0)) or 1
            // self.env.cr.execute("SELECT value FROM ir_config_parameter WHERE key = 'cloud_storage_migration_min_attachment_id'")
            // min_attachment_id = int(self.env.cr.fetchone()[0]) if self.env.cr.rowcount else 0
            // return min_attachment_id * 100 // max(max_attachment_id, min_attachment_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CloudStorageMigrationReport> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py) ---
            // def init(self):
            // """Initialize the SQL view for the cloud storage migration report."""
            // tools.drop_view_if_exists(self.env.cr, self._table)
            // query = """
            //     CREATE OR REPLACE VIEW %s AS (
            //         SELECT
            //             im.id AS id,
            //             grouped.res_model AS res_model,
            //             grouped.all_sum_size AS all_sum_size,
            //             grouped.all_max_size AS all_max_size,
            //             grouped.all_count AS all_count,
            //             grouped.message_sum_size AS message_sum_size,
            //             grouped.message_max_size AS message_max_size,
            //             grouped.message_count AS message_count
            //         FROM (
            //             SELECT
            //                 ia.res_model,
            //                 SUM(ia.file_size) / 1000000 AS all_sum_size,
            //                 MAX(ia.file_size) / 1000000 AS all_max_size,
            //                 COUNT(ia.id) AS all_count,
            //                 SUM(CASE WHEN mar.attachment_id IS NOT NULL THEN ia.file_size ELSE 0 END) / 1000000 AS message_sum_size,
            //                 MAX(CASE WHEN mar.attachment_id IS NOT NULL THEN ia.file_size ELSE 0 END) / 1000000 AS message_max_size,
            //                 COUNT(mar.attachment_id) AS message_count
            //             FROM ir_attachment ia
            //             LEFT JOIN message_attachment_rel mar
            //                 ON mar.attachment_id = ia.id
            //             WHERE ia.res_field IS NULL
            //                 AND ia.res_id IS NOT NULL
            //                 AND ia.file_size IS NOT NULL
            //                 AND ia.res_model IS NOT NULL
            //                 AND ia.type = 'binary'
            //             GROUP BY ia.res_model
            //         ) AS grouped
            //         INNER JOIN ir_model im ON im.model = grouped.res_model
            //     )
            // """ % self._table
            // self.env.cr.execute(query)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}