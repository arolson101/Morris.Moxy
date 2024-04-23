using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class AttributeListSyntaxToAttributeMetaExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToAttributeMeta(this AttributeListSyntax attribute)
	{
		var name = attribute.Attributes.FirstOrDefault()?.Name.ToFullString() ?? "";
		return name;
	}
}
