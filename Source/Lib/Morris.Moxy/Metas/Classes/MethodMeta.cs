using System.Collections.Immutable;

namespace Morris.Moxy.Metas.Classes;

public record MethodMeta(
	string Name,
	ImmutableArray<ParamMeta> Params,
	ImmutableArray<string> Attributes
);
