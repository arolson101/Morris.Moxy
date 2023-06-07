using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class MemberDeclarationSyntaxToFieldMetaExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static FieldMeta? ToFieldMeta(this MemberDeclarationSyntax symbol)
	{
		string? name;
		string? type;
		bool writable;
		bool readable;

		switch (symbol)
		{
			case FieldDeclarationSyntax field:
				name = field.Declaration.Variables.FirstOrDefault()?.Identifier.Text;
				type = field.Declaration.Type?.ToString();
				writable = field.Modifiers.All(m => m.Text != "readonly");
				readable = true;
				break;

			case PropertyDeclarationSyntax property:
				name = property.Identifier.Text;
				type = property.Type?.ToString();
				writable = property.AccessorList?.Accessors.Any(a => a.Keyword.Text == "set") ?? true;
				readable = property.AccessorList?.Accessors.Any(a => a.Keyword.Text == "get") ?? true;
				break;

			default:
				return null;
		}

		if (name == null || type == null)
			return null;

		var attributes = symbol.AttributeLists
			.Select(a => a.ToAttributeMeta())
			.ToImmutableArray();

		return new FieldMeta(
			Name: name,
			Type: type,
			Writable: writable,
			Readable: readable,
			Attributes: attributes);
	}
}
