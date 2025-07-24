namespace Bamboo.Core;
public interface IJunctionTableMetadataProvider
{
    JunctionTableConfiguration GetJunctionTable(string leftModel, string fieldName);
}
public class JunctionTableConfiguration
{
    public string TableName { get; set; }
    public string LeftModel { get; set; }
    public string RightModel { get; set; }
    public string LeftKey { get; set; }
    public string RightKey { get; set; }
}