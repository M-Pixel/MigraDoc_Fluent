using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentParagraph
	{
		public Paragraph Subject { get; }

		public FluentParagraph(Paragraph subject)
		{
			Subject = subject;
		}

		public FluentParagraph Style(string styleName)
		{
			Subject.Style = styleName;
			return this;
		}

		public FluentParagraph Image(string fileName, Action<FluentImage>? builder = null)
		{
			var image = Subject.AddImage(fileName);
			builder?.Invoke(new FluentImage(image));
			return this;
		}

		public FluentParagraph Text(string text, Action<Text>? builder = null)
		{
			var plainText = Subject.AddText(text);
			builder?.Invoke(plainText);
			return this;
		}

		public FluentParagraph FormattedText(TextFormat format, string text, Action<FluentFormattedText>? builder = null)
		{
			var formattedText = Subject.AddFormattedText(text, format);
			builder?.Invoke(new FluentFormattedText(formattedText));
			return this;
		}

		public FluentParagraph FormattedText(string? styleName, string text, Action<FluentFormattedText>? builder = null)
		{
			var formattedText = Subject.AddFormattedText(text, styleName);
			builder?.Invoke(new FluentFormattedText(formattedText));
			return this;
		}
	}
}