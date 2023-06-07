using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class ParameterSyntaxToParamMetaExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ParamMeta ToParamMeta(this ParameterSyntax parameter, bool first, bool last)
	{
		return new ParamMeta(
			Name: parameter.Identifier.Text,
			Type: parameter.Type?.ToString() ?? "",
			IsFirst: first,
			IsLast: last
		);
	}
}
