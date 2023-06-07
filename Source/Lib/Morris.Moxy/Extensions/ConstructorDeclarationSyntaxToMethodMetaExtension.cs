using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class ConstructorDeclarationSyntaxToMethodMetaExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static MethodMeta ToMethodMeta(this ConstructorDeclarationSyntax m)
	{
		return new MethodMeta(
			Name: m.Identifier.Text,
			Params: m.ParameterList.ToParamMetaList(),
			Attributes: m.AttributeLists.ToAttributeMetaList()
		);
	}
}
