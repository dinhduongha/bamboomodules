using Xunit;

namespace Bamboo.Admin.EntityFrameworkCore;

[CollectionDefinition(AdminTestConsts.CollectionDefinitionName)]
public class AdminEntityFrameworkCoreCollection : ICollectionFixture<AdminEntityFrameworkCoreFixture>
{

}
