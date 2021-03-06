using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public static partial class Fluent
	{
	}

	public struct FluentStyle
	{
		public Style Subject { get; }

		public FluentStyle(Style subject)
		{
			Subject = subject;
		}

		public FluentStyle Set(ParagraphAlignment alignment)
		{
			Subject.ParagraphFormat.Alignment = alignment;
			return this;
		}

		public FluentStyle Set(OutlineLevel outlineLevel)
		{
			Subject.ParagraphFormat.OutlineLevel = outlineLevel;
			return this;
		}

		public FluentStyle Set(LineSpacingRule lineSpacingRule)
		{
			Subject.ParagraphFormat.LineSpacingRule = lineSpacingRule;
			return this;
		}

		public FluentStyle Set(Underline underlineType)
		{
			Subject.Font.Underline = underlineType;
			return this;
		}

		public FluentStyle Base(string styleName)
		{
			Subject.BaseStyle = styleName;
			return this;
		}

		public FluentStyle Bold(bool bold = true)
		{
			Subject.Font.Bold = bold;
			return this;
		}

		public FluentStyle Color(byte red, byte green, byte blue, byte? opacity) =>
			Color(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentStyle Color(double cyan, double yellow, double magenta, double? opacity) =>
			Color(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentStyle Color(Color color)
		{
			Subject.Font.Color = color;
			return this;
		}

		public FluentStyle Italic(bool italic = true)
		{
			Subject.Font.Italic = italic;
			return this;
		}

		public FluentStyle Size(Unit fontSize)
		{
			Subject.Font.Size = fontSize;
			return this;
		}

		public FluentStyle Superscript(bool isSuperscript)
		{
			Subject.Font.Subscript = isSuperscript;
			return this;
		}

		public FluentStyle Subscript(bool isSubscript)
		{
			Subject.Font.Subscript = isSubscript;
			return this;
		}

		public FluentStyle Font(string fontName)
		{
			Subject.Font.Name = fontName;
			return this;
		}

		public FluentStyle IndentLeft(Unit leftIndent)
		{
			Subject.ParagraphFormat.LeftIndent = leftIndent;
			return this;
		}

		public FluentStyle IndentRight(Unit rightIndent)
		{
			Subject.ParagraphFormat.RightIndent = rightIndent;
			return this;
		}

		public FluentStyle IndentFirstLine(Unit firstLineIndent)
		{
			Subject.ParagraphFormat.FirstLineIndent = firstLineIndent;
			return this;
		}

		/// <summary>
		/// Whether or not to keep all of the paragraph's lines on the same page.
		/// </summary>
		public FluentStyle KeepTogether(bool keepTogether = true)
		{
			Subject.ParagraphFormat.KeepTogether = keepTogether;
			return this;
		}

		public FluentStyle LineSpacing(Unit lineSpacing)
		{
			Subject.ParagraphFormat.LineSpacing = lineSpacing;
			return this;
		}

		public FluentStyle PageBreakBefore(bool pageBreakBefore = true)
		{
			Subject.ParagraphFormat.PageBreakBefore = pageBreakBefore;
			return this;
		}

		public FluentStyle Shading(Action<FluentShading> builder)
		{
			builder(new FluentShading(Subject.ParagraphFormat.Shading));
			return this;
		}

		public FluentStyle Shading(byte red, byte green, byte blue, byte? opacity) =>
			Shading(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentStyle Shading(double cyan, double yellow, double magenta, double? opacity) =>
			Shading(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentStyle Shading(Color color)
		{
			var shading = Subject.ParagraphFormat.Shading;
			shading.Color = color;
			shading.Visible = true;
			return this;
		}

		public FluentStyle Shading(bool visible = true)
		{
			Subject.ParagraphFormat.Shading.Visible = visible;
			return this;
		}

		public FluentStyle SpaceAfter(Unit spaceAfter)
		{
			Subject.ParagraphFormat.SpaceAfter = spaceAfter;
			return this;
		}

		public FluentStyle SpaceBefore(Unit spaceBefore)
		{
			Subject.ParagraphFormat.SpaceBefore = spaceBefore;
			return this;
		}


		public FluentStyle Set(ListType listType)
		{
			Subject.ParagraphFormat.ListInfo.ListType = listType;
			return this;
		}

		public FluentStyle ListNumberPosition(Unit numberPosition)
		{
			Subject.ParagraphFormat.ListInfo.NumberPosition = numberPosition;
			return this;
		}

		public FluentStyle ContinuePreviousList(bool continuePreviousList = true)
		{
			Subject.ParagraphFormat.ListInfo.ContinuePreviousList = continuePreviousList;
			return this;
		}


		public FluentStyle Borders(Action<FluentBorders> builder)
		{
			builder(new FluentBorders(Subject.ParagraphFormat.Borders));
			return this;
		}
	}
}