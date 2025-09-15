using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

class NullDataSeederContributor
        : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    public NullDataSeederContributor(IGuidGenerator guidGenerator)
    {
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await Task.CompletedTask;
    }
}