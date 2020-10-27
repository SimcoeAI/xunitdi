using System;

namespace SimcoeAI.Test.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class TestPriorityAttribute : Attribute
	{
		public TestPriorityAttribute(int priority)
			=> Priority = priority;

		public int Priority { get; }
	}
}
