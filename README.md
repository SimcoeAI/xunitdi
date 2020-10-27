[![Build Status](https://dev.azure.com/simcoeai/ArchitectureLibrary/_apis/build/status/SimcoeAI.xunittools?branchName=main)](https://dev.azure.com/simcoeai/ArchitectureLibrary/_build/latest?definitionId=10&branchName=main)

![Nuget](https://img.shields.io/nuget/v/SimcoeAI.Test?color=cc)

# A minimal and unambitious library to help dependency injection in Xunit framework
This library leverages Xunit's fixture implementation to bring dependency injection to .net core test projects powered by Xunit. 

## Steps to activate dependency injection in Xunit test projects

### 1) Derive from DIFixture class
Simply create your own fixture and derive from ```DIFixture``` abstract class found in ```SimcoAI.Test.DependencyInjection``` namespace. The following example illustrates it:

```csharp
public class MyTestFixture : DIFixture
{
   protected override void AddServices(IServiceCollection services)
   {
	services.Configure<MyOptions>(option => Configuration.GetSection("MyOptions").Bind(option));
	services.AddSingleton<IMyService, MyServiceImplementation>();
	services.AddScoped<IAnotherService, AnotherServiceImplementation>();
   }

   protected override string GetConfigurationFile()
	=> "appsettings.json";
}
```
```MyOptions```, ```IMyService```, ```IAnotherService```, ```MyServiceImplementation``` and ```AnotherServiceImplementation``` are interfaces and classes that we assumed they have pre-existed in this example.

### 2) Define the test fixture's collection
The following example illustrates how to assign a test collection to the fixture defined in the previous step:

```csharp
[CollectionDefinition("my tests")]
public class MyTestCollection : ICollectionFixture<MyTestFixture>
{
}
``` 

### 3) Define test classes
Your test classes should derive from ```SimcoeAI.Test.TestsWithFixture``` class and it must be decorated by the right collection name. Example:

```csharp
[CollectionDefinition("my tests")]
public class MyTestCollection : ICollectionFixture<MyTestFixture>
{
}
```
