using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class SyntaxListAttributeListSyntaxToAttributeMetaListExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImmutableArray<string> ToAttributeMetaList(this SyntaxList<AttributeListSyntax> attributeLists)
	{
		return attributeLists
			.Select(a => a.ToAttributeMeta())
			.ToImmutableArray();
	}
}
