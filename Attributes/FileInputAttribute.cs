using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimcoeAI.Test.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public sealed class FileInputAttribute : FileAttribute
	{
		public FileInputAttribute(string filename)
			: base(filename) { }

		public override IEnumerable<object[]> GetData(MethodInfo testMethod)
			=> new List<object[]> { new object[1] { ReadFile() } };
	}
}
