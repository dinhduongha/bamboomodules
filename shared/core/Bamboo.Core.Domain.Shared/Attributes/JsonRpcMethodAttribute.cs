using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class JsonRpcMethodAttribute : Attribute
{
    public string? RpcName { get; }  // optional: nếu khác tên method

    public JsonRpcMethodAttribute(string? rpcName = null)
    {
        RpcName = rpcName;
    }
}