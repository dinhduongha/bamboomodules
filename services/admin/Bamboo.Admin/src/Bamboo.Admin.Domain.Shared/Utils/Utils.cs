using System;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Volo.Abp.Threading;

public partial class Utils
{
    private const long UNIXEPOCHMICROSECONDS = 62135596800000000;
    private static readonly DateTimeOffset EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    //private static readonly IUlidRng DEFAULTRNG = new CSUlidRng();
    private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

    public static Guid NewGuid(DateTime timePart, long randPart)
    {
        var d = DateTimeOffsetToByteArray(timePart);
        var randomPart = BitConverter.GetBytes(randPart);
        byte[] bytes = new byte[] { d[3], d[2], d[1], d[0], d[5], d[4], d[7], d[6],
                                    randomPart[0], randomPart[1], randomPart[2], randomPart[3],
                                    randomPart[4], randomPart[5], randomPart[6], randomPart[7]};
        return new Guid(bytes);
    }

    public static Guid NewGuid(DateTime timePart, byte[] randomPart)
    {
        var d = DateTimeOffsetToByteArray(timePart);
        byte[] bytes = new byte[] { d[3], d[2], d[1], d[0], d[5], d[4], d[7], d[6],
                                    randomPart[0], randomPart[1], randomPart[2], randomPart[3],
                                    randomPart[4], randomPart[5], randomPart[6], randomPart[7]};
        return new Guid(bytes);
    }

    public static Guid NewGuid()
    {
        var timePart = DateTime.Now;
        var randomBytes = new byte[10];
        //Rng.Locking(r => r.GetBytes(randomBytes));
        //var randomPart = Rng.GetBytes(10);
        //var randomPart = randomBytes;
        var randomPart = new byte[10];
        Rng.GetBytes(randomPart);
        var d = DateTimeOffsetToByteArray(timePart);
        byte[] bytes = new byte[] { d[3], d[2], d[1], d[0], d[5], d[4], d[7], d[6],
                                    randomPart[0], randomPart[1], randomPart[2], randomPart[3],
                                    randomPart[4], randomPart[5], randomPart[6], randomPart[7]};
        return new Guid(bytes);
        //return new byte[] { _d, _c, _b, _a, _f, _e, _h, _g, _i, _j, _k, _l, _m, _n, _o, _p };
    }
    private static byte[] DateTimeOffsetToByteArray(DateTime value)
    {
        var micros = (value.Ticks / 10) - UNIXEPOCHMICROSECONDS;
        var mc = BitConverter.GetBytes(micros / 1000);
        var mx = new[] { mc[7], mc[6], mc[5], mc[4], mc[3], mc[2], mc[1], mc[0] };
        var mb = BitConverter.GetBytes(micros / 1000);
        var mm = BitConverter.GetBytes(micros % 1000);
        var ret = new[] { mb[5], mb[4], mb[3], mb[2], mb[1], mb[0], mm[1], mm[0] };                                  // Drop byte 6 & 7
        return ret;
    }

    public static TDestination JsonMap<TSource, TDestination>(TSource source)
    {
        var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(source);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<TDestination>(serialized);
    }
}
