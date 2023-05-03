using Volo.Abp.DependencyInjection;

namespace Bamboo.App;

public class HelloWorldService : ITransientDependency
{
    public string SayHello()
    {
        return "Hello, World!";
    }
}