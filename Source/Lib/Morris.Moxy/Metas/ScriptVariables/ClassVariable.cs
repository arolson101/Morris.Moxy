using Morris.Moxy.Metas.Classes;
using System.Collections.Immutable;

namespace Morris.Moxy.Metas.ScriptVariables;

public readonly struct ClassVariable
{
	public readonly string Name;
	public readonly string Namespace;
	public readonly string TestValue = "test value";
	public readonly string[] Values = new []{"a", "b", "c"};
	public readonly ImmutableArray<FieldMeta> Fields;
	public readonly ImmutableArray<MethodMeta> Methods;
	public readonly MethodMeta Constructor;

	public ClassVariable(string name, string @namespace, ImmutableArray<FieldMeta> fields, ImmutableArray<MethodMeta> methods, MethodMeta constructor)
	{
		Name = name;
		Namespace = @namespace;
		Fields = fields;
		Methods = methods;
		Constructor = constructor;
	}
}
