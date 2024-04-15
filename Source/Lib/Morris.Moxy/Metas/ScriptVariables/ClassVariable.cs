using Morris.Moxy.Metas.Classes;
using System.Collections.Immutable;

namespace Morris.Moxy.Metas.ScriptVariables;

public readonly struct ClassVariable
{
	public readonly string Name;
	public readonly string Namespace;
	public readonly bool IsSealed;
	public readonly ImmutableArray<FieldMeta> Fields;
	public readonly ImmutableArray<MethodMeta> Methods;
	public readonly MethodMeta Constructor;
	public readonly DeclaringTypeVariable? DeclaringType;

	public ClassVariable(string name, string @namespace, bool isSealed, ImmutableArray<FieldMeta> fields, ImmutableArray<MethodMeta> methods, MethodMeta constructor, DeclaringTypeVariable? declaringType = null)
	{
		Name = name;
		Namespace = @namespace;
		IsSealed = isSealed;
		Fields = fields;
		Methods = methods;
		Constructor = constructor;
		DeclaringType = declaringType;
	}
}
