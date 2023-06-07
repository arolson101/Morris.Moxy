using Microsoft.CodeAnalysis.CSharp.Syntax;
using Morris.Moxy.Metas.Classes;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Morris.Moxy.Extensions;

internal static class ParameterListSyntaxToParamMetaListExtension
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImmutableArray<ParamMeta> ToParamMetaList(this ParameterListSyntax paramList)
	{
		return paramList.Parameters
			.Select((p, index) => p.ToParamMeta(first: index == 0, last: index == paramList.Parameters.Count - 1))
			.ToImmutableArray();
	}
}
