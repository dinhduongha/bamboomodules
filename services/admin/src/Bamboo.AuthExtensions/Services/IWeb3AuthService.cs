using System.Threading.Tasks;

namespace Bamboo.Abp.LoginUi.Services
{
    public interface IWeb3AuthService
    {
        bool IsEvm(string network);

        /// <summary>
        /// Sinh Nonce ngẫu nhiên và lưu vào MemoryCache trong 5 phút.
        /// Trả về Handle (Key) để Client lưu giữ reference.
        /// </summary>
        (string Handle, string Nonce) GenerateAndCacheNonce();

        /// <summary>
        /// Xác thực toàn bộ quy trình: Cache -> Signature -> OnChain
        /// </summary>
        Task<Web3AuthResult> VerifyLoginAsync(string handle, string message, string signature, string address, string network, string publicKey = null);
    }

    public class Web3AuthResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}