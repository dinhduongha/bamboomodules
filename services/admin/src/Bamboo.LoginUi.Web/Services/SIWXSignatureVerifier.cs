using Nethereum.Signer;
using StellarDotnetSdk;
using NaCl;
using System.Text;
using System.Threading.Tasks;
using System;
using Nethereum.Util;

public interface ISIWXSignatureVerifier
{
    Task<bool> VerifySignature(string blockchain, string address, string message, string signature);
}

public class SIWXSignatureVerifier : ISIWXSignatureVerifier
{
    public async Task<bool> VerifySignature(string blockchain, string address, string message, string signature)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        var signatureBytes = Convert.FromBase64String(signature);

        switch (blockchain.ToLower())
        {
            case "ethereum":
            case "bnbchain":
                var signer = new EthereumMessageSigner();
                var recoveredAddress = signer.EcRecover(Sha3Keccack.Current.CalculateHash(messageBytes), signature);
                return recoveredAddress.Equals(address, StringComparison.OrdinalIgnoreCase);

            case "stellar":
                var publicKey = StellarDotnetSdk.Accounts.KeyPair.FromAccountId(address);
                return publicKey.Verify(messageBytes, signatureBytes);

            case "solana":
            case "sui":
                //return NaCl.Sign.Verify(messageBytes, signatureBytes, Convert.FromBase64String(address));
                return true;

            case "polkadot":
            case "ton":
            case "cosmos":
                // Placeholder: Thêm logic xác minh cho Polkadot (Sr25519), TON (Ed25519), Cosmos (Secp256k1)
                return true; // Cần triển khai cụ thể

            default:
                return false;
        }
    }
}