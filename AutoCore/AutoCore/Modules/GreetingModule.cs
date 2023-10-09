using Autofac;
using AutoCore.Services;

namespace AutoCore.Modules;

public class GreetingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GreetingService>().As<IGreetingService>();
    }
}