namespace TARge23Cars.Tests;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

public class MockHostEnvironment : IHostEnvironment
{
    public string EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
