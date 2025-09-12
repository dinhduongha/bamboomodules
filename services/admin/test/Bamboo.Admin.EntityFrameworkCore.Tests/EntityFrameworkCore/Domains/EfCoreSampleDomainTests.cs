using Bamboo.Admin.Samples;
using Xunit;

namespace Bamboo.Admin.EntityFrameworkCore.Domains;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AdminEntityFrameworkCoreTestModule>
{

}
