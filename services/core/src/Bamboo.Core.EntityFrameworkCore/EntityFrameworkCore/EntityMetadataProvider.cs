// IEntityMetadataProvider.cs (tầng Data)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.EntityFrameworkCore;
public class EntityMetadataProvider : IEntityMetadataProvider, ITransientDependency
{
    private readonly CoreDbContext _dbContext;
    private readonly Dictionary<(string, string), JunctionTableConfiguration> _junctionTables;
    private readonly Dictionary<(string, string), RelationConfiguration> _relationTables;

    public EntityMetadataProvider(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
        _relationTables = BuildMetadataCache();
        // Tạo dictionary mới bằng LINQ
        _junctionTables = _relationTables
            .Where(pair => pair.Value.Many2Many != null) // 1. Lọc các item có Many2Many khác null
            .ToDictionary(
                pair => pair.Key,                         // 2. Lấy key từ item gốc
                pair => pair.Value.Many2Many!             // 3. Lấy giá trị Many2Many từ item gốc
            );
        if (_junctionTables.Count != 0)
        { 

        }
    }

    public JunctionTableConfiguration GetJunctionTable(string leftModel, string fieldName)
    {
        var rightModel = fieldName.Replace("_id", "").Replace("_ids", "");
        return _junctionTables.FirstOrDefault(kv => kv.Key.Item1 == leftModel && kv.Value.RightModel.Contains(rightModel)).Value;
    }

    public List<RelationConfiguration> GetRelations(string model)
    { 
        return _relationTables.Where(kv => kv.Key.Item1 == model).Select(kv => kv.Value).ToList();
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

    private Dictionary<(string, string), RelationConfiguration> BuildMetadataCache()
    {
        var junctionTables = new Dictionary<(string, string), JunctionTableConfiguration>();
        var relationTables = new Dictionary<(string, string), RelationConfiguration>();

        foreach (var entityType in _dbContext.Model.GetEntityTypes())
        {
            // Dùng reflection để lấy tất cả các property của class
            foreach (PropertyInfo prop in entityType.GetProperties())
            {
                var relationInfo = new RelationConfiguration();

                string propName = prop.Name;
                string propType;

                // Dùng metadata của EF để xác định loại trường
                ISkipNavigation? skipNav = entityType.FindSkipNavigation(propName);
                INavigation? nav = entityType.FindNavigation(propName);
                IProperty? property = entityType.FindProperty(propName);

                if (skipNav != null)
                {
                    // 1. Quan hệ Nhiều - Nhiều
                    propType = "Quan hệ Nhiều - Nhiều (ICollection<" + skipNav.TargetEntityType.ClrType.Name + ">)";
                    var junctionType = skipNav.JoinEntityType;
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
                        relationInfo.RelationType = "many2many";
                        relationInfo.Many2Many = junctionTables[(rightModel, leftModel)];
                    }
                    if (skipNav.Inverse != null)
                    {
                        relationInfo.RelationField = skipNav.Inverse.Name;
                        Console.WriteLine($"   -> Tên trường đối diện: {skipNav.Inverse.Name}");
                    }
                }
                else if (nav != null)
                {
                    if (nav.IsCollection)
                    {
                        // 2. Quan hệ Một - Nhiều
                        propType = "Quan hệ Một - Nhiều (ICollection<" + nav.TargetEntityType.ClrType.Name + ">)";
                        relationInfo.RelationType = "one2many";
                        relationInfo.RelationModel = nav.TargetEntityType.ClrType.Name;
                    }
                    else
                    {
                        if (nav.ForeignKey.IsUnique)
                        {
                            // 3. Quan hệ Một - Một
                            propType = "Quan hệ Một - Một (với " + nav.TargetEntityType.ClrType.Name + ")";
                            relationInfo.RelationType = "one2one";
                            relationInfo.RelationModel = nav.TargetEntityType.ClrType.Name;
                        }
                        else
                        {
                            relationInfo.RelationType = "one2one";
                            relationInfo.RelationModel = nav.TargetEntityType.ClrType.Name;
                            // 4. Quan hệ Nhiều - Một
                            propType = "Quan hệ Nhiều - Một (với " + nav.TargetEntityType.ClrType.Name + ")";
                        }
                    }
                    // Lấy tên trường đối diện
                    if (nav.Inverse != null)
                    {
                        relationInfo.RelationField = nav.Inverse.Name;
                        Console.WriteLine($"   -> Tên trường đối diện: {nav.Inverse.Name}");
                    }
                }
                else if (property != null)
                {
                    // Là một cột trong CSDL, kiểm tra xem có phải cột tính toán không
                    if (Attribute.IsDefined(prop, typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute)))
                    {
                        relationInfo.RelationType = "compute";
                        // 5. Cột tính toán (phía C#)
                        propType = "Cột tính toán (C# - [NotMapped])";
                    }
                    else
                    {
                        relationInfo.RelationType = "column";
                        // 6. Cột bình thường
                        propType = "Cột bình thường (Kiểu CSDL: " + property.GetColumnType() + ")";
                    }
                }
                else
                {
                    relationInfo.RelationType = "none";
                    // Trường hợp này thường là các property không được EF ánh xạ và không có attribute [NotMapped]
                    propType = "Không được ánh xạ (Bỏ qua bởi EF)";
                }

                Console.WriteLine($"- {propName}: {propType}");
                relationTables[(entityType.Name, propName)] = relationInfo;
            }
        }
        //_relationTables = relationTables;
        return _relationTables;
    }
}

/*
namespace YourNamespace.Data
{
    // public interface IEntityMetadataProvider
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

    public class EntityMetadataProvider : IEntityMetadataProvider, ITransientDependency
    {
        private readonly DbContext _dbContext;

        public EntityMetadataProvider(DbContext dbContext) // Inject YourAppDbContext
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