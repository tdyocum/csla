# Using the Source Generator with AddressPOCO in CSLA.NET

This guide provides a step-by-step approach to using the source generator in the CSLA.NET project, specifically with the `AddressPOCO.cs` class as an example. The source generator is a powerful tool that can automatically generate additional source code for your projects, enhancing productivity and maintainability.

## Prerequisites

- Visual Studio 2019 or later with the .NET Core development workload installed.
- The CSLA.NET NuGet package added to your project.
- Ths CSLA.NET Source Generator NuGet package added to your project.

## Step 1: Define Your POCO Class

Start by defining your Plain Old CLR Object (POCO) class. In this example, we use `AddressPOCO.cs`:

```csharp
using Csla.Serialization;

namespace Csla.Generators.CSharp.TestObjects
{

  [AutoSerializable]
  public partial class AddressPOCO
  {

    public string? AddressLine1 { get; set; }

    public string AddressLine2 { get; set; } = string.Empty;

    public string Town { get; set; } = string.Empty;

    public string County { get; set; } = string.Empty;

    public string Postcode { get; set; } = string.Empty;

  }
}
```

## Understanding [AutoSerializable]

- **Source Generators:** Introduced in .NET 5, source generators allow for compile-time code generation based on the existing codebase. They are a powerful tool for reducing boilerplate code and automating repetitive coding tasks.
- **[AutoSerializable] Attribute:** This custom attribute is used to mark a class for automatic serialization code generation. When the source generator sees this attribute, it generates the necessary serialization and deserialization methods for the class, tailored to its properties.

## How It Works with AddressPOCO
1.	**Marking the Class:** By adding [AutoSerializable] above the AddressPOCO class definition, you indicate that this class should have serialization code automatically generated.
2.	**Compilation:** During compilation, the source generator scans the project's code for classes marked with [AutoSerializable].
3.	**Code Generation:** For each class found, the generator produces additional source files that implement serialization and deserialization logic specific to that class. This might include methods for converting the class to and from a serialized format, handling nullability, and more.
4.	**Integration:** The generated code is compiled as part of your project, making it available for use at runtime without additional steps. This means AddressPOCO can be serialized and deserialized without manually implementing any serialization methods.
## Benefits
-	Reduced Boilerplate: Automatically generating serialization code reduces the need for repetitive, error-prone boilerplate code.
-	Consistency: Ensures consistent serialization behavior across different parts of the application.
-	Efficiency: Improves development efficiency by automating a common requirement (serialization).

## Source code generated from the example

AddressPOCO class might look like this:

```csharp
//<auto-generated/>
#nullable enable
using System;
using Csla.Serialization.Mobile;

namespace Csla.Generators.CSharp.TestObjects
{
	[Serializable]
	public partial class AddressPOCO : IMobileObject
	{
		void IMobileObject.GetChildren(SerializationInfo info, MobileFormatter formatter)
		{
		}
		
		void IMobileObject.GetState(SerializationInfo info)
		{
			info.AddValue(nameof(AddressLine1), AddressLine1);
			info.AddValue(nameof(AddressLine2), AddressLine2);
			info.AddValue(nameof(Town), Town);
			info.AddValue(nameof(County), County);
			info.AddValue(nameof(Postcode), Postcode);
		}
		
		void IMobileObject.SetChildren(SerializationInfo info, MobileFormatter formatter)
		{
		}
		
		void IMobileObject.SetState(SerializationInfo info)
		{
			AddressLine1 = info.GetValue<string?>(nameof(AddressLine1));
			AddressLine2 = info.GetValue<string>(nameof(AddressLine2));
			Town = info.GetValue<string>(nameof(Town));
			County = info.GetValue<string>(nameof(County));
			Postcode = info.GetValue<string>(nameof(Postcode));
		}
		
	}
}
```