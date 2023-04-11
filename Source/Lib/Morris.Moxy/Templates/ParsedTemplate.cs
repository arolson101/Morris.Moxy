﻿using System.Collections.Immutable;

namespace Morris.Moxy.Templates;

public readonly struct ParsedTemplate
{
	public readonly bool Success;
	public readonly string Name;
	public readonly string FilePath;
	public readonly string? TemplateSource;
	public readonly int TemplateBodyLineNumber;
	public readonly ImmutableArray<string> AttributeUsingClauses;
	public readonly ImmutableArray<TemplateAttributeProperty> AttributeRequiredProperties;
	public readonly ImmutableArray<TemplateAttributeProperty> AttributeOptionalProperties;

	public static readonly ParsedTemplate Empty = new();

	public ParsedTemplate(
		string name,
		string filePath,
		int templateBodyLineNumber,
		ImmutableArray<string> attributeUsingClauses,
		ImmutableArray<TemplateAttributeProperty> attributeRequiredProperties,
		ImmutableArray<TemplateAttributeProperty> attributeOptionalProperties,
		string templateSource)
	{
		Success = true;
		Name = name ?? throw new ArgumentNullException(nameof(name));
		FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
		TemplateBodyLineNumber = templateBodyLineNumber;
		AttributeUsingClauses = attributeUsingClauses;
		AttributeRequiredProperties = attributeRequiredProperties;
		AttributeOptionalProperties = attributeOptionalProperties;
		TemplateSource = templateSource ?? throw new ArgumentNullException(nameof(templateSource));
	}

	public ParsedTemplate(
		string name,
		string filePath,
		int templateBodyLineNumber)
	{
		Success = false;
		Name = name ?? throw new ArgumentNullException(nameof(name));
		FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
		TemplateBodyLineNumber = templateBodyLineNumber;
		AttributeUsingClauses = ImmutableArray<string>.Empty;
		AttributeRequiredProperties = ImmutableArray<TemplateAttributeProperty>.Empty;
		AttributeOptionalProperties = ImmutableArray<TemplateAttributeProperty>.Empty;
		TemplateSource = null;
	}
}
