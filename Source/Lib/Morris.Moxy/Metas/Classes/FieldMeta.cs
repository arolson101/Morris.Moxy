using System.Collections.Immutable;

namespace Morris.Moxy.Metas.Classes;

public record FieldMeta(
	string Name,
	string Type,
	bool Readable,
	bool Writable,
	ImmutableArray<AttributeMeta> Attributes
);
