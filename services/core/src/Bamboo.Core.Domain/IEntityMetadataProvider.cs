using System.Collections.Generic;

namespace Bamboo.Core;

public interface IEntityMetadataProvider
{
    JunctionTableConfiguration GetJunctionTable(string leftModel, string fieldName);
    List<RelationConfiguration> GetRelations(string model);
}
public class JunctionTableConfiguration
{
    public string? TableName { get; set; }
    public string LeftModel { get; set; }
    public string RightModel { get; set; }
    public string LeftKey { get; set; }
    public string RightKey { get; set; }
}

public class RelationConfiguration
{
    public string RelationType { get; set; }
    public string? RelationModel { get; set; }
    public string? RelationField { get; set; }
    public JunctionTableConfiguration? Many2Many { get; set; }
}