﻿using System;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Threading;

/// <summary>
/// Implements <see cref="IGuidGenerator"/> by creating sequential Guids.
/// This code is taken from https://github.com/jhtodd/SequentialGuid/blob/master/SequentialGuid/Classes/SequentialGuid.cs
/// </summary>
public class MySequentialGuidGenerator : IGuidGenerator, ITransientDependency
{
    /// <summary>
    /// Gets the singleton <see cref="SequentialGuidGenerator"/> instance.
    /// </summary>
    //public static MySequentialGuidGenerator Instance { get; } = new MySequentialGuidGenerator();

    private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();
    private const long UNIXEPOCHMICROSECONDS = 62135596800000000;
    public AbpSequentialGuidGeneratorOptions Options { get; }
    public SequentialGuidDatabaseType DatabaseType { get; set; }

    public MySequentialGuidGenerator()
    {
        DatabaseType = SequentialGuidDatabaseType.PostgreSql;
    }
    /// <summary>
    /// Prevents a default instance of the <see cref="SequentialGuidGenerator"/> class from being created.
    /// Use <see cref="Instance"/>.
    /// </summary>
    private MySequentialGuidGenerator(IOptions<AbpSequentialGuidGeneratorOptions> options)
    {
        Options = options.Value;
        DatabaseType = SequentialGuidDatabaseType.PostgreSql;
    }

    public Guid Create()
    {
        //return Create(Options.GetDefaultSequentialGuidType());
        return Create(DatabaseType);
    }

    public Guid Create(SequentialGuidDatabaseType databaseType)
    {
        switch (databaseType)
        {
            case SequentialGuidDatabaseType.SqlServer:
                return Create(SequentialGuidType.SequentialAtEnd);
            case SequentialGuidDatabaseType.Oracle:
                return Create(SequentialGuidType.SequentialAsBinary);
            case SequentialGuidDatabaseType.MySql:
                return Create(SequentialGuidType.SequentialAsString);
            case SequentialGuidDatabaseType.PostgreSql:
                return Create(SequentialGuidType.SequentialAsString);
            default:
                throw new InvalidOperationException();
        }
    }

    public Guid Create(SequentialGuidType guidType)
    {
        // We start with 16 bytes of cryptographically strong random data.
        var randomBytes = new byte[10];
        Rng.Locking(r => r.GetBytes(randomBytes));

        // An alternate method: use a normally-created GUID to get our initial
        // random data:
        // byte[] randomBytes = Guid.NewGuid().ToByteArray();
        // This is faster than using RNGCryptoServiceProvider, but I don't
        // recommend it because the .NET Framework makes no guarantee of the
        // randomness of GUID data, and future versions (or different
        // implementations like Mono) might use a different method.

        // Now we have the random basis for our GUID.  Next, we need to
        // create the six-byte block which will be our timestamp.

        // We start with the number of milliseconds that have elapsed since
        // DateTime.MinValue.  This will form the timestamp.  There's no use
        // being more specific than milliseconds, since DateTime.Now has
        // limited resolution.

        // Using millisecond resolution for our 48-bit timestamp gives us
        // about 5900 years before the timestamp overflows and cycles.
        // Hopefully this should be sufficient for most purposes. :)
        long timestamp = DateTime.UtcNow.Ticks / 10L - UNIXEPOCHMICROSECONDS;
        //long timestamp = DateTime.UtcNow.Ticks / 10000L;

        // Then get the bytes
        byte[] timestampBytes = BitConverter.GetBytes(timestamp / 1000);
        byte[] microsecBytes = BitConverter.GetBytes(timestamp % 1000);
        // Since we're converting from an Int64, we have to reverse on
        // little-endian systems.
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timestampBytes);
            Array.Reverse(microsecBytes);
        }           

        byte[] guidBytes = new byte[16];

        switch (guidType)
        {
            case SequentialGuidType.SequentialAsString:
            case SequentialGuidType.SequentialAsBinary:

                // For string and byte-array version, we copy the timestamp first, followed
                // by the random data.
                    
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                Buffer.BlockCopy(microsecBytes, 6, guidBytes, 6, 2);
                Buffer.BlockCopy(randomBytes, 0, guidBytes, 8, 8);

                // If formatting as a string, we have to compensate for the fact
                // that .NET regards the Data1 and Data2 block as an Int32 and an Int16,
                // respectively.  That means that it switches the order on little-endian
                // systems.  So again, we have to reverse.
                if (guidType == SequentialGuidType.SequentialAsString && BitConverter.IsLittleEndian)
                {
                    Array.Reverse(guidBytes, 0, 4);
                    Array.Reverse(guidBytes, 4, 2);
                    Array.Reverse(guidBytes, 6, 2);
                }

                break;

            case SequentialGuidType.SequentialAtEnd:

                // For sequential-at-the-end versions, we copy the random data first,
                // followed by the timestamp.
                Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                break;
        }
        //Console.WriteLine($"Create GUID {new Guid(guidBytes)}");
        return new Guid(guidBytes);
    }

    /// <summary>
    /// Database type to generate GUIDs.
    /// </summary>
    public enum SequentialGuidDatabaseType
    {
        SqlServer,

        Oracle,

        MySql,

        PostgreSql,
    }

    /// <summary>
    /// Describes the type of a sequential GUID value.
    /// </summary>
    public enum SequentialGuidType
    {
        /// <summary>
        /// The GUID should be sequential when formatted using the
        /// <see cref="Guid.ToString()" /> method.
        /// </summary>
        SequentialAsString,

        /// <summary>
        /// The GUID should be sequential when formatted using the
        /// <see cref="Guid.ToByteArray" /> method.
        /// </summary>
        SequentialAsBinary,

        /// <summary>
        /// The sequential portion of the GUID should be located at the end
        /// of the Data4 block.
        /// </summary>
        SequentialAtEnd
    }
}
/*
    Configure<AbpSequentialGuidGeneratorOptions>(options =>
    {
        options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString;
    });
    //context.Services.AddTransient<IGuidGenerator, MySequentialGuidGenerator>();
    context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, MySequentialGuidGenerator>());
*/
