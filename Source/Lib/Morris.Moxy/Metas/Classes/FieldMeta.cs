using System.Collections.Immutable;

namespace Morris.Moxy.Metas.Classes;

public record FieldMeta(
	string Name,
	string Type,
	string Initializer,
	bool Readable,
	bool Writable,
	ImmutableArray<string> Attributes
);
