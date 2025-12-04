using System.Text;
using System.Text.Json.Serialization; // Để map với JSON từ JS

public class SiwxMessageDto
{
    // Map với thuộc tính camelCase từ JS
    [JsonPropertyName("domain")]
    public string Domain { get; set; } = "";

    [JsonPropertyName("address")]
    public string Address { get; set; } = "";

    [JsonPropertyName("statement")]
    public string? Statement { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = "";

    [JsonPropertyName("version")]
    public string Version { get; set; } = "";

    [JsonPropertyName("chainId")]
    public object? ChainId { get; set; }

    [JsonPropertyName("nonce")]
    public string Nonce { get; set; } = "";

    [JsonPropertyName("issuedAt")]
    public string IssuedAt { get; set; } = "";

    [JsonPropertyName("expirationTime")]
    public string? ExpirationTime { get; set; }

    // Các trường optional khác của chuẩn SIWE
    [JsonPropertyName("notBefore")]
    public string? NotBefore { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("resources")]
    public string[]? Resources { get; set; }

    /// <summary>
    /// Tái tạo chuỗi message chuẩn EIP-4361 (Bắt buộc dùng \n)
    /// </summary>
    public string ToSiweString(bool eth = true)
    {
        var sb = new StringBuilder();

        // Header
        if (eth)
        {
            sb.Append($"{Domain} wants you to sign in with your Ethereum account:\n");
        }
        else
        {
            sb.Append($"{Domain} wants you to sign in with your account:\n");
        }
        sb.Append($"{Address}\n\n");

        // Statement (Nếu có)
        if (!string.IsNullOrEmpty(Statement))
        {
            sb.Append($"{Statement}\n\n");
        }

        // Các trường bắt buộc
        sb.Append($"URI: {Uri}\n");
        sb.Append($"Version: {Version}\n");
        sb.Append($"Chain ID: {ChainId}\n");
        sb.Append($"Nonce: {Nonce}\n");
        sb.Append($"Issued At: {IssuedAt}"); // Lưu ý: Dòng cuối này chưa xuống dòng vội

        // Các trường Optional (Nếu có thì mới thêm xuống dòng trước nó)
        if (!string.IsNullOrEmpty(ExpirationTime))
        {
            sb.Append($"\nExpiration Time: {ExpirationTime}");
        }

        if (!string.IsNullOrEmpty(NotBefore))
        {
            sb.Append($"\nNot Before: {NotBefore}");
        }

        if (!string.IsNullOrEmpty(RequestId))
        {
            sb.Append($"\nRequest ID: {RequestId}");
        }

        if (Resources != null && Resources.Length > 0)
        {
            sb.Append($"\nResources:");
            foreach (var res in Resources)
            {
                sb.Append($"\n- {res}");
            }
        }

        return sb.ToString();
    }
}
public class WalletConnectChainDto
{
    [JsonPropertyName("chainId")]
    public int ChainId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("explorerUrl")]
    public string ExplorerUrl { get; set; }

    [JsonPropertyName("rpcUrl")]
    public string RpcUrl { get; set; }
}