using Bamboo.Admin.Samples;
using Xunit;

namespace Bamboo.Admin.EntityFrameworkCore.Applications;

[Collection(AdminTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AdminEntityFrameworkCoreTestModule>
{

}
