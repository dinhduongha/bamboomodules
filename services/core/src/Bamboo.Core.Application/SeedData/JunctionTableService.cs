using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Domain.Repositories;
using Bamboo.Core.Models;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Bamboo.Core.Application
{
    public class JunctionTableService : ApplicationService, IJunctionTableService, ITransientDependency
    {
        private readonly IJunctionTableRepository _junctionTableRepository;
        private readonly IJunctionTableMetadataProvider _junctionTableMetadataProvider;
        private readonly IRepository<IrModelField, Guid> _irModelFieldRepository;
        private readonly bool _useIrModelField;

        public JunctionTableService(
            IJunctionTableRepository junctionTableRepository,
            IJunctionTableMetadataProvider junctionTableMetadataProvider,
            IRepository<IrModelField, Guid> irModelFieldRepository,
            IConfiguration configuration)
        {
            _junctionTableRepository = junctionTableRepository;
            _junctionTableMetadataProvider = junctionTableMetadataProvider;
            _irModelFieldRepository = irModelFieldRepository;
            _useIrModelField = configuration.GetValue<bool>("Odoo:UseIrModelField", false);
        }

        public async Task<bool> IsMany2ManyRelationAsync(string model, string fieldName)
        {
            if (_useIrModelField)
            {
                var field = await _irModelFieldRepository
                    .FirstOrDefaultAsync(f => f.Model == model && f.Name == fieldName);
                return field != null && field.Ttype == "many2many";
            }

            var junctionTable = _junctionTableMetadataProvider.GetJunctionTable(model, fieldName);
            return junctionTable != null;
        }

        public async Task InsertJunctionRecordsAsync(string model, string fieldName, Guid recordId, List<Guid> relatedIds, Guid? tenantId)
        {
            JunctionTableConfiguration junctionTable;

            if (_useIrModelField)
            {
                var field = await _irModelFieldRepository
                    .FirstOrDefaultAsync(f => f.Model == model && f.Name == fieldName && f.Ttype == "many2many");
                if (field == null || string.IsNullOrEmpty(field.RelationTable))
                {
                    return;
                }

                junctionTable = new JunctionTableConfiguration
                {
                    TableName = field.RelationTable,
                    LeftModel = model,
                    RightModel = field.Relation,
                    LeftKey = field.Column1 ?? $"{model.Replace(".", "_")}_id",
                    RightKey = field.Column2 ?? $"{field.Relation.Replace(".", "_")}_id"
                };
            }
            else
            {
                junctionTable = _junctionTableMetadataProvider.GetJunctionTable(model, fieldName);
                if (junctionTable == null)
                {
                    return;
                }
            }

            await _junctionTableRepository.InsertJunctionRecordsAsync(
                junctionTable.TableName,
                junctionTable.LeftModel == model ? junctionTable.LeftKey : junctionTable.RightKey,
                junctionTable.LeftModel == model ? recordId : relatedIds.FirstOrDefault(),
                junctionTable.LeftModel == model ? junctionTable.RightKey : junctionTable.LeftKey,
                junctionTable.LeftModel == model ? relatedIds : new List<Guid> { recordId },
                tenantId);
        }
    }
}
/*
namespace Bamboo.Core.Application
{
    public class JunctionTableService : ApplicationService, IJunctionTableService, ITransientDependency
    {
        private readonly IJunctionTableRepository _junctionTableRepository;
        private readonly IJunctionTableMetadataProvider _junctionTableMetadataProvider;
        private readonly IRepository<IrModelField, Guid> _irModelFieldRepository;
        private readonly bool _useIrModelField;

        public JunctionTableService(
            IJunctionTableRepository junctionTableRepository,
            IJunctionTableMetadataProvider junctionTableMetadataProvider,
            IRepository<IrModelField, Guid> irModelFieldRepository,
            IConfiguration configuration)
        {
            _junctionTableRepository = junctionTableRepository;
            _junctionTableMetadataProvider = junctionTableMetadataProvider;
            _irModelFieldRepository = irModelFieldRepository;
            _useIrModelField = configuration.GetValue<bool>("Odoo:UseIrModelField", false);
        }

        public async Task<bool> IsMany2ManyRelationAsync(string model, string fieldName)
        {
            if (_useIrModelField)
            {
                var field = await _irModelFieldRepository
                    .FirstOrDefaultAsync(f => f.Model == model && f.Name == fieldName);
                return field != null && field.Ttype == "many2many";
            }

            var junctionTable = _junctionTableMetadataProvider.GetJunctionTable(model, fieldName);
            return junctionTable != null;
        }

        public async Task InsertJunctionRecordsAsync(string model, string fieldName, Guid recordId, List<Guid> relatedIds, Guid? tenantId)
        {
            JunctionTableConfiguration junctionTable;

            if (_useIrModelField)
            {
                var field = await _irModelFieldRepository
                    .FirstOrDefaultAsync(f => f.Model == model && f.Name == fieldName && f.Ttype == "many2many");
                if (field == null || string.IsNullOrEmpty(field.RelationTable))
                {
                    return;
                }

                junctionTable = new JunctionTableConfiguration
                {
                    TableName = field.RelationTable,
                    LeftModel = model,
                    RightModel = field.Relation,
                    LeftKey = $"{model.Replace(".", "_")}_id",
                    RightKey = $"{field.Relation.Replace(".", "_")}_id"
                };
            }
            else
            {
                junctionTable = _junctionTableMetadataProvider.GetJunctionTable(model, fieldName);
                if (junctionTable == null)
                {
                    return;
                }
            }

            await _junctionTableRepository.InsertJunctionRecordsAsync(
                junctionTable.TableName,
                junctionTable.LeftModel == model ? junctionTable.LeftKey : junctionTable.RightKey,
                junctionTable.LeftModel == model ? recordId : relatedIds.FirstOrDefault(),
                junctionTable.LeftModel == model ? junctionTable.RightKey : junctionTable.LeftKey,
                junctionTable.LeftModel == model ? relatedIds : new List<Guid> { recordId },
                tenantId);
        }
    }
}
*/