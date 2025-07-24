// IJunctionTableMetadataProvider.cs (tầng Data)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;

//using Bamboo.Core.EntityFrameworkCore;

namespace Bamboo.Core.EntityFrameworkCore
{
    // public interface IJunctionTableMetadataProvider
    // {
    //     JunctionTableConfiguration GetJunctionTable(string leftModel, string fieldName);
    // }

    // public class JunctionTableConfiguration
    // {
    //     public string TableName { get; set; }
    //     public string LeftModel { get; set; }
    //     public string RightModel { get; set; }
    //     public string LeftKey { get; set; }
    //     public string RightKey { get; set; }
    // }

    public class JunctionTableMetadataProvider : IJunctionTableMetadataProvider, ITransientDependency
    {
        private readonly CoreDbContext _dbContext;
        private readonly Dictionary<(string, string), JunctionTableConfiguration> _junctionTables;

        public JunctionTableMetadataProvider(CoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _junctionTables = BuildJunctionTableCache();
        }

        public JunctionTableConfiguration GetJunctionTable(string leftModel, string fieldName)
        {
            var rightModel = fieldName.Replace("_id", "").Replace("_ids", "");
            return _junctionTables.FirstOrDefault(kv => kv.Key.Item1 == leftModel && kv.Value.RightModel.Contains(rightModel)).Value;
        }

        private Dictionary<(string, string), JunctionTableConfiguration> BuildJunctionTableCache()
        {
            var junctionTables = new Dictionary<(string, string), JunctionTableConfiguration>();

            foreach (var entity in _dbContext.Model.GetEntityTypes())
            {
                foreach (var skipNavigation in entity.GetSkipNavigations())
                {
                    var junctionType = skipNavigation.JoinEntityType;
                    var tableName = junctionType.GetTableName();
                    var foreignKeys = junctionType.GetForeignKeys().ToList();

                    if (foreignKeys.Count == 2)
                    {
                        var leftEntity = foreignKeys[0].PrincipalEntityType;
                        var rightEntity = foreignKeys[1].PrincipalEntityType;
                        var leftKey = foreignKeys[0].Properties[0].Name;
                        var rightKey = foreignKeys[1].Properties[0].Name;

                        var leftModel = leftEntity.Name.Replace("_", ".").ToLower();
                        var rightModel = rightEntity.Name.Replace("_", ".").ToLower();

                        var config = new JunctionTableConfiguration
                        {
                            TableName = tableName,
                            LeftModel = leftModel,
                            RightModel = rightModel,
                            LeftKey = leftKey,
                            RightKey = rightKey
                        };

                        junctionTables[(leftModel, rightModel)] = config;
                        junctionTables[(rightModel, leftModel)] = new JunctionTableConfiguration
                        {
                            TableName = tableName,
                            LeftModel = rightModel,
                            RightModel = leftModel,
                            LeftKey = rightKey,
                            RightKey = leftKey
                        };
                    }
                }
            }

            return junctionTables;
        }
    }
}
/*
namespace YourNamespace.Data
{
    // public interface IJunctionTableMetadataProvider
    // {
    //     IEnumerable<JunctionTableConfiguration> GetJunctionTables();
    // }

    // public class JunctionTableConfiguration
    // {
    //     public string TableName { get; set; }
    //     public string LeftModel { get; set; }
    //     public string RightModel { get; set; }
    //     public string LeftKey { get; set; }
    //     public string RightKey { get; set; }
    // }

    public class JunctionTableMetadataProvider : IJunctionTableMetadataProvider, ITransientDependency
    {
        private readonly DbContext _dbContext;

        public JunctionTableMetadataProvider(DbContext dbContext) // Inject YourAppDbContext
        {
            _dbContext = dbContext;
        }

        public IEnumerable<JunctionTableConfiguration> GetJunctionTables()
        {
            var junctionTables = new List<JunctionTableConfiguration>();

            foreach (var entity in _dbContext.Model.GetEntityTypes())
            {
                foreach (var skipNavigation in entity.GetSkipNavigations())
                {
                    var junctionType = skipNavigation.JoinEntityType;
                    var tableName = junctionType.GetTableName();
                    var foreignKeys = junctionType.GetForeignKeys().ToList();

                    if (foreignKeys.Count == 2)
                    {
                        var leftEntity = foreignKeys[0].PrincipalEntityType;
                        var rightEntity = foreignKeys[1].PrincipalEntityType;
                        var leftKey = foreignKeys[0].Properties[0].Name;
                        var rightKey = foreignKeys[1].Properties[0].Name;

                        var leftModel = leftEntity.Name.Replace("_", ".").ToLower();
                        var rightModel = rightEntity.Name.Replace("_", ".").ToLower();

                        junctionTables.Add(new JunctionTableConfiguration
                        {
                            TableName = tableName,
                            LeftModel = leftModel,
                            RightModel = rightModel,
                            LeftKey = leftKey,
                            RightKey = rightKey
                        });
                    }
                }
            }

            return junctionTables;
        }
    }
}
*/