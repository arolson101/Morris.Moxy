using Morris.Moxy.Extensions;
using Morris.Moxy.Helpers;
using System.Collections.Immutable;

namespace Morris.Moxy.Metas.Classes;

internal class ClassMeta : IEquatable<ClassMeta>
{
	public readonly string ClassName;
	public readonly string Namespace;
	public readonly ImmutableArray<string> GenericParameterNames;
	public readonly ImmutableArray<string> UsingClauses;
	public readonly ImmutableArray<AttributeInstance> PossibleTemplates;
	public readonly string GenericParametersSignature;
	public readonly ImmutableArray<FieldMeta> Fields;
	public readonly ImmutableArray<MethodMeta> Methods;
	public readonly MethodMeta Constructor;

	public string FullName => NamespaceHelper.Combine(Namespace, ClassName);

	private readonly Lazy<int> CachedHashCode;

	public ClassMeta()
	{
		ClassName = "";
		Namespace = "";
		GenericParameterNames = ImmutableArray<string>.Empty;
		UsingClauses = ImmutableArray<string>.Empty;
		PossibleTemplates = ImmutableArray<AttributeInstance>.Empty;
		GenericParametersSignature = "";
		Fields = ImmutableArray<FieldMeta>.Empty;
		Methods = ImmutableArray<MethodMeta>.Empty;
		Constructor = new MethodMeta("", ImmutableArray<ParamMeta>.Empty, ImmutableArray<AttributeMeta>.Empty);
		CachedHashCode = new Lazy<int>(() => typeof(ClassMeta).GetHashCode());
	}

	public ClassMeta(
		string className,
		string @namespace,
		ImmutableArray<string> genericParameterNames,
		ImmutableArray<string> usingClauses,
		ImmutableArray<AttributeInstance> possibleTemplates,
		ImmutableArray<FieldMeta> fields,
		ImmutableArray<MethodMeta> methods,
		MethodMeta? constructor)
	{
		GenericParametersSignature = GetGenericParametersSignature(genericParameterNames);
		ClassName = className + GenericParametersSignature;
		Namespace = @namespace;
		GenericParameterNames = genericParameterNames;
		UsingClauses = usingClauses;
		PossibleTemplates = possibleTemplates;
		Fields = fields;
		Methods = methods;
		Constructor = constructor ?? new MethodMeta("", ImmutableArray<ParamMeta>.Empty, ImmutableArray<AttributeMeta>.Empty);

		CachedHashCode = new Lazy<int>(() => HashCode.Combine(
			className,
			@namespace,
			genericParameterNames.GetContentsHashCode(),
			usingClauses.GetContentsHashCode(),
			possibleTemplates.GetContentsHashCode(),
			Fields.GetContentsHashCode(),
			Methods.GetContentsHashCode(),
			Constructor.GetHashCode())
		);
	}

	public static bool operator ==(ClassMeta left, ClassMeta right) => left.Equals(right);
	public static bool operator !=(ClassMeta left, ClassMeta right) => !(left == right);
	public override bool Equals(object obj) => obj is ClassMeta other && Equals(other);

	public bool Equals(ClassMeta other) =>
		ReferenceEquals(this, other)
		||
		(
			CachedHashCode.IsValueCreated == other.CachedHashCode.IsValueCreated == true
				? CachedHashCode.Value == other.CachedHashCode.Value
				: true
			&& ClassName == other.ClassName
			&& Namespace == other.Namespace
			&& GenericParameterNames.SequenceEqual(other.GenericParameterNames)
			&& UsingClauses.SequenceEqual(other.UsingClauses)
			&& PossibleTemplates.SequenceEqual(other.PossibleTemplates)
			&& Fields.SequenceEqual(other.Fields)
			&& Methods.SequenceEqual(other.Methods)
			&& Constructor == other.Constructor
		);

	public override int GetHashCode() => CachedHashCode.Value;

	public ClassMeta WithNamespace(string @namespace) =>
		new ClassMeta(
			className: ClassName,
			@namespace: @namespace,
			genericParameterNames: GenericParameterNames,
			usingClauses: UsingClauses,
			possibleTemplates: PossibleTemplates,
			fields: Fields,
			methods: Methods,
			constructor: Constructor);

	private static string GetGenericParametersSignature(ImmutableArray<string> genericParameterNames) =>
		genericParameterNames.IsDefaultOrEmpty
		? ""
		: "<" + string.Join(", ", genericParameterNames) + ">";
}

