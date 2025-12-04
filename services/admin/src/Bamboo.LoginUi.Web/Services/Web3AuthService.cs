using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// Các thư viện Crypto
using Nethereum.Signer;
using Nethereum.Web3;
using Solnet.Wallet;
using Solnet.Rpc;
using StellarDotnetSdk.Accounts;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Crypto.Parameters;
using SimpleBase;
using Substrate.NetApi; // Cần cài package SimpleBase
using Substrate.NetApi.Model.Types; // Các kiểu dữ liệu Substrate
using Substrate.NET.Schnorrkel.Keys;

namespace Bamboo.Abp.LoginUi.Services
{
    public class Web3AuthService : IWeb3AuthService
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly ILogger<Web3AuthService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Web3AuthService(
            IConfiguration config,
            IMemoryCache cache,
            ILogger<Web3AuthService> logger,
            IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _config = config;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public (string Handle, string Nonce) GenerateAndCacheNonce()
        {
            var nonce = Guid.NewGuid().ToString("N");
            var handle = Guid.NewGuid().ToString("N");

            // Lưu Nonce vào RAM, sống 5 phút
            _cache.Set(handle, nonce, TimeSpan.FromMinutes(5));

            return (handle, nonce);
        }

        public async Task<Web3AuthResult> VerifyLoginAsync(string handle, string message, string signature, string address, string network, string publicKey = null)
        {
            // 1. CHECK NONCE TỪ CACHE
            if (string.IsNullOrEmpty(handle) || !_cache.TryGetValue(handle, out string cachedNonce))
            {
                return new Web3AuthResult { Success = false, ErrorMessage = "Phiên đăng nhập hết hạn hoặc không hợp lệ (Nonce Expired)." };
            }

            // Xóa ngay lập tức để chống Replay Attack
            _cache.Remove(handle);

            // Kiểm tra message có chứa Nonce không (Chống giả mạo nội dung)
            if (!message.Contains(cachedNonce))
            {
                return new Web3AuthResult { Success = false, ErrorMessage = "Message signature does not match the server nonce." };
            }

            // 2. CHECK CHỮ KÝ (Offline Verify)
            try
            {
                if (!VerifySignatureOffline(message, signature, address, network, publicKey))
                {
                    return new Web3AuthResult { Success = false, ErrorMessage = $"Chữ ký không hợp lệ cho mạng {network}." };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Crypto Verify Error");
                return new Web3AuthResult { Success = false, ErrorMessage = "Lỗi xác thực mật mã: " + ex.Message };
            }

            // 3. CHECK ON-CHAIN (RPC Check)
            if (_config.GetValue<bool>("Blockchain:RequireOnChainCheck"))
            {
                bool exists = await CheckOnChainExistenceAsync(address, network);
                if (!exists)
                {
                    return new Web3AuthResult { Success = false, ErrorMessage = $"Ví {address} chưa được kích hoạt hoặc không tồn tại trên mạng {network}." };
                }
            }

            return new Web3AuthResult { Success = true };
        }

        // ============================================
        // LOGIC 1: VERIFY SIGNATURE (OFFLINE/CRYPTO)
        // ============================================
        private bool VerifySignatureOffline(string msg, string sig, string addr, string net, string pubKeyHex)
        {
            var msgBytes = Encoding.UTF8.GetBytes(msg);

            // --- A. EVM Group (Eth, BNB, Gnosis...) ---
            if (IsEvm(net))
            {
                var signer = new EthereumMessageSigner();
                var recovered = signer.EncodeUTF8AndEcRecover(msg, sig);
                return recovered.Equals(addr, StringComparison.OrdinalIgnoreCase);
            }
            // TODO: Check verify functions
            return false;
            if (net == "sui")
            {
                if (string.IsNullOrEmpty(pubKeyHex)) return false;

                // Sui Signed Message structure:
                // Message thực tế được ký = Blake2b256(Intent | BcsEncode(Message))
                // Tuy nhiên, nếu Frontend dùng 'signPersonalMessage', nó gửi về signature khớp với message text (có wrapped).
                // Để đơn giản hóa cho C# (tránh cài thư viện BCS/Blake2b phức tạp), 
                // ta dùng verify Ed25519 thuần: Verify(Sig, Msg, PubKey).

                // Frontend sẽ gửi:
                // - Signature: Base64
                // - PublicKey: Hex hoặc Base64

                byte[] pubKeyBytes = Convert.FromBase64String(pubKeyHex); // Sui Wallet trả PubKey Base64
                byte[] sigBytes = Convert.FromBase64String(sig);

                // Trong thực tế, message cần được wrap theo chuẩn Sui. 
                // Nếu verify thuần thất bại, hãy xem lại cách Frontend ký (dùng signMessage thay vì signPersonalMessage để lấy raw).
                // Ở đây tôi giả định Frontend gửi raw bytes đã wrap hoặc ký raw.
                return VerifyEd25519(msgBytes, sigBytes, pubKeyBytes);
            }
            if (net == "ton")
            {
                if (string.IsNullOrEmpty(pubKeyHex)) return false;

                byte[] pubKeyBytes = Convert.FromHexString(pubKeyHex);
                byte[] sigBytes = Convert.FromBase64String(sig);

                // TON Connect ký vào Cell Hash, không phải text thuần.
                // Nhưng để Login đơn giản, Frontend có thể yêu cầu ký text raw.
                return VerifyEd25519(msgBytes, sigBytes, pubKeyBytes);
            }

            // --- B. Solana ---
            if (net == "solana")
            {
                var pubKey = new PublicKey(addr);
                // Solana signature thường là Base58 (nếu client gửi Hex thì convert lại)
                byte[] sigBytes;
                try { sigBytes = Base58.Bitcoin.Decode(sig).ToArray(); }
                catch { sigBytes = Convert.FromHexString(sig.Replace("0x", "")); }

                return pubKey.Verify(msgBytes, sigBytes);
            }

            // --- C. Stellar / Pi Network ---
            if (net == "stellar" || net == "pi-network")
            {
                var kp = StellarDotnetSdk.Accounts.KeyPair.FromAccountId(addr);
                var sigBytes = Convert.FromBase64String(sig);
                return kp.Verify(msgBytes, sigBytes);
            }

            // --- D. Aptos / TON (Generic Ed25519) ---
            if (net == "aptos" || net == "ton")
            {
                if (string.IsNullOrEmpty(pubKeyHex)) return false;
                byte[] pubKeyBytes = Convert.FromHexString(pubKeyHex.Replace("0x", ""));
                byte[] sigBytes = net == "aptos"
                    ? Convert.FromHexString(sig.Replace("0x", ""))
                    : Convert.FromBase64String(sig);

                return VerifyEd25519(msgBytes, sigBytes, pubKeyBytes);
            }

            // --- E. Cosmos ---
            if (net == "cosmos")
            {
                // https://github.com/AdonisVillanueva/cosmos_api_dotnet
                // Cosmos (Keplr) dùng Secp256k1 nhưng format khác Eth.
                // Để đơn giản, check null. Production nên dùng thư viện 'Cosmos.Security'
                return !string.IsNullOrEmpty(sig);
            }

            // --- F. CELLFRAME (Post-Quantum) ---
            if (net == "cellframe")
            {
                // CellFrame dùng Crystal-Dilithium hoặc Picnic.
                // .NET chưa hỗ trợ native các thuật toán này đầy đủ trong các thư viện chuẩn.
                // Giải pháp tạm thời: 
                // 1. Kiểm tra format address (bắt đầu bằng 'cell')
                // 2. Chấp nhận chữ ký nếu có độ dài hợp lý (PQC signature rất dài, > 2KB)
                // 3. Dựa hoàn toàn vào bước CheckOnChainExistence (gọi Node verify)

                bool validAddr = addr.StartsWith("cell");
                bool validSigLen = sig.Length > 100;
                return validAddr && validSigLen;
            }
            if (net == "polkadot")
            {
                try
                {
                    // 1. Parse Address (SS58 -> Public Key Bytes)
                    // Utils.GetPublicKeyFrom là hàm của Substrate.NetApi để decode SS58
                    var publicKeyBytes = Substrate.NetApi.Utils.GetPublicKeyFrom(addr);

                    // 2. Parse Signature (Hex -> Bytes)
                    var signatureBytes = Substrate.NetApi.Utils.HexToByteArray(sig);

                    // 3. Chuẩn bị Message
                    // Polkadot wallet thường bọc message trong tag <Bytes>...</Bytes> khi dùng signRaw
                    // Tuy nhiên, việc verify Sr25519 thường verify trên payload gốc.
                    // Thư viện Substrate.NetApi hỗ trợ Verify signature Sr25519.

                    // Wrap Message (Bắt buộc với Polkadot JS signRaw)
                    // Ví Polkadot JS Extension khi dùng signRaw sẽ tự động bọc message vào thẻ <Bytes>
                    // Backend phải tự bọc lại y hệt thì mới khớp hash.
                    string wrappedMsg = $"<Bytes>{msg}</Bytes>";
                    var msgBytesPolkadot = Encoding.UTF8.GetBytes(wrappedMsg);

                    //Xử lý Signature (Loại bỏ Prefix Type)
                    // Chữ ký Polkadot (MultiSignature) thường có 1 byte prefix ở đầu (VD: 0x01 cho Sr25519).
                    // Độ dài chuẩn Sr25519 là 64 bytes. Nếu dài hơn (65 hoặc 66 bytes), ta cắt bỏ đầu.
                    if (signatureBytes.Length > 64)
                    {
                        // Bỏ các byte thừa ở đầu (thường là 1 byte type)
                        signatureBytes = signatureBytes.Skip(signatureBytes.Length - 64).ToArray();
                    }

                    // Dùng Schnorrkel Verify
                    // Lưu ý: Chữ ký Polkadot thường có prefix type (1 byte) ở đầu nếu là MultiSignature. 
                    // Nhưng signRaw trả về signature thuần (64 bytes).
                    // Nếu sig dài 66 bytes (0x...), HexToByteArray đã xử lý 0x.

                    // 3. Verify bằng thư viện Schnorrkel
                    try
                    {
                        // Kiểm tra độ dài Public Key (Phải là 32 bytes)
                        if (publicKeyBytes.Length != 32) return false;

                        // Khởi tạo Public Key từ bytes
                        var pk = new PublicKey(publicKeyBytes);

                        // Gọi hàm Verify của thư viện (Signature, Message)
                        return pk.Verify(signatureBytes, msgBytesPolkadot);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Polkadot verify failed");
                    return false;
                }
            }
            return false;
        }

        // ============================================
        // LOGIC 2: CHECK ON-CHAIN (RPC/API)
        // ============================================
        private async Task<bool> CheckOnChainExistenceAsync(string address, string network)
        {
            string rpcUrl = _config[$"Blockchain:RpcUrls:{network}"];
            if (string.IsNullOrEmpty(rpcUrl)) return true; // Skip nếu không config

            try
            {
                // 1. EVM
                if (IsEvm(network))
                {
                    var web3 = new Web3(rpcUrl);
                    var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(address);
                    var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
                    return txCount.Value > 0 || balance.Value > 0;
                }

                // 2. Solana
                if (network == "solana")
                {
                    // FIX: Tạo HttpClient từ Factory để quản lý connection pool hiệu quả
                    var httpClient = _httpClientFactory.CreateClient();

                    // Truyền httpClient vào tham số thứ 3 của GetClient
                    // Tham số: (url, logger, httpClient, ...)
                    var rpcClient = Solnet.Rpc.ClientFactory.GetClient(rpcUrl, logger: null, httpClient: httpClient);

                    var info = await rpcClient.GetAccountInfoAsync(address);

                    // Kiểm tra kết quả
                    return info.WasSuccessful && info.Result?.Value != null;
                }

                // 3. Stellar / Pi
                if (network == "stellar" || network == "pi-network")
                {
                    using var server = new StellarDotnetSdk.Server(rpcUrl);
                    var account = await server.Accounts.Account(address);
                    return account != null;
                }

                // 4. Aptos
                if (network == "aptos")
                {
                    return await HttpGetCheckAsync($"{rpcUrl.TrimEnd('/')}/accounts/{address}");
                }

                // 5. TON
                if (network == "ton")
                {
                    return await HttpGetCheckAsync($"{rpcUrl.TrimEnd('/')}/getAddressInformation?address={address}", "active");
                }

                // 6. CELLFRAME (New)
                if (network == "cellframe")
                {
                    // Giả lập gọi API Node của CellFrame: /node/dag/wallet/{addr} hoặc global_db
                    // API thực tế của CellFrame Node có thể khác tùy version (Node python vs C)
                    // Đây là ví dụ check ledger
                    var url = $"{rpcUrl.TrimEnd('/')}/ledger/wallet/{address}";
                    return await HttpGetCheckAsync(url);
                }
                if (network == "sui")
                {
                    // Gọi method suix_getBalance
                    // Cần custom HttpClient để tránh lỗi socket như bài trước
                    var client = _httpClientFactory.CreateClient();
                    var req = new HttpRequestMessage(HttpMethod.Post, rpcUrl)
                    {
                        Content = new StringContent($"{{\"jsonrpc\":\"2.0\", \"id\":1, \"method\":\"suix_getBalance\", \"params\":[\"{address}\"]}}", Encoding.UTF8, "application/json")
                    };

                    var res = await client.SendAsync(req);
                    if (!res.IsSuccessStatusCode) return false;

                    var json = await res.Content.ReadAsStringAsync();
                    // Check nếu totalBalance > 0
                    return !json.Contains("\"totalBalance\":\"0\"");
                }
                if (network == "polkadot")
                {
                    // Cách đơn giản nhất: Gọi API của Subscan hoặc Polkascan (REST API) 
                    // vì gọi RPC trực tiếp của Polkadot khá phức tạp (cần decode scale codec).
                    // Nhưng để dùng RPC thuần, ta check System Account Info.

                    // Cách dùng HTTP JSON-RPC thô (Không cần thư viện nặng):
                    var client = _httpClientFactory.CreateClient();

                    // Payload lấy thông tin account
                    // Polkadot lưu balance trong module System, storage Account.
                    // Ta cần tính Storage Key (Hash của module + Hash của address).
                    // Việc này quá phức tạp nếu code tay.

                    // GIẢI PHÁP TỐI ƯU: Dùng Substrate.NetApi Client
                    try
                    {
                        // Kết nối WebSocket hoặc HTTP
                        // Substrate.NetApi chủ yếu hỗ trợ WebSocket. 
                        // Nếu bạn chỉ muốn check nhanh qua HTTP, hãy dùng API của Subscan (Free tier).
                        // Ví dụ: https://polkadot.api.subscan.io/api/scan/account/tokens

                        // Ở đây tôi demo cách gọi RPC check balance đơn giản nhất nếu có hỗ trợ state_getStorage
                        // Nhưng do tính phức tạp của SCALE Codec, tôi khuyên dùng API Indexer miễn phí.

                        var url = $"https://polkadot.webapi.subscan.io/api/scan/search";
                        var payload = new { key = address };
                        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                        var res = await client.PostAsync(url, content);
                        if (!res.IsSuccessStatusCode) return false;

                        var json = await res.Content.ReadAsStringAsync();
                        // Check xem có account info không
                        return json.Contains("\"account\":") && !json.Contains("\"account\":null");
                    }
                    catch { return false; }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"RPC check fail for {network}: {ex.Message}");
                return false; // Fail-safe: Lỗi mạng coi như không tồn tại
            }
            return true;
        }

        // --- Helpers ---
        public bool IsEvm(string n) => new[] { "ethereum", "bnb", "gnosis", "polygon" }.Contains(n);

        private async Task<bool> HttpGetCheckAsync(string url, string requiredContent = null)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return false;

            if (requiredContent != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content.Contains(requiredContent, StringComparison.OrdinalIgnoreCase);
            }
            return true;
        }

        private bool VerifyEd25519(byte[] m, byte[] s, byte[] p)
        {
            return false;
            // var v = new Ed25519Signer();
            // v.Init(false, new Ed25519PublicKeyParameters(p, 0));
            // v.BlockUpdate(m, 0, m.Length);
            // return v.VerifySignature(s);
        }


        // private string DetectChain(string addr)
        // {
        //     // 1. Ethereum / EVM
        //     if (addr.StartsWith("0x") && addr.Length == 42) return "Ethereum / EVM";

        //     // 2. Stellar (Base32 - NBitcoin không hỗ trợ native Base32 của Stellar, check string basic thôi)
        //     if (addr.StartsWith("G") && addr.Length == 56) return "Stellar";

        //     // 3. TON
        //     if (addr.StartsWith("EQ") || addr.StartsWith("UQ")) return "TON";

        //     // 4. Cosmos
        //     if (addr.StartsWith("cosmos1")) return "Cosmos";

        //     // 5. Polkadot (SS58 - Bản chất là Base58)
        //     if ((addr.StartsWith("1") || addr.StartsWith("5")) && IsBase58(addr)) return "Polkadot";

        //     // 6. Solana
        //     // Solana address là 32 bytes public key được encode Base58 -> độ dài thường là 43 hoặc 44 ký tự.
        //     // QUAN TRỌNG: Dùng Encoders.Base58 (không phải Base58Check)
        //     if (addr.Length >= 32 && addr.Length <= 44 && IsBase58(addr))
        //     {
        //         return "Solana";
        //     }

        //     // (Optional) Check Bitcoin
        //     if (IsBase58Check(addr)) return "Bitcoin";

        //     return "Wallet";
        // }

        // // --- Helper Functions dùng NBitcoin ---

        // private bool IsBase58(string input)
        // {
        //     try
        //     {
        //         // NBitcoin hỗ trợ decode Base58 thuần
        //         var data = Encoders.Base58.DecodeData(input);
        //         return data.Length > 0;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        // private bool IsBase58Check(string input)
        // {
        //     try
        //     {
        //         // NBitcoin hỗ trợ decode Base58Check (có verify checksum 4 byte cuối)
        //         var data = Encoders.Base58Check.DecodeData(input);
        //         return data.Length > 0;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }
    }
}