using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimcoeAI.Test.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public sealed class JsonInputAttribute : FileAttribute
	{
		public JsonInputAttribute(string jsonFile)
			: base(jsonFile) { }

		public override IEnumerable<object[]> GetData(MethodInfo testMethod)
			=> new List<object[]> { new object[1] { JsonConvert.DeserializeObject(ReadFile()) } };
	}
}