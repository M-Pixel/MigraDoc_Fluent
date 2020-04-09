using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentFormattedText
	{
		public FormattedText Subject { get; }

		public FluentFormattedText(FormattedText subject)
		{
			Subject = subject;
		}

		public FluentFormattedText Style(string styleName)
		{
			Subject.Style = styleName;
			return this;
		}

		public FluentFormattedText FormattedText(TextFormat format, string text, Action<FluentFormattedText>? builder = null)
		{
			var formattedText = Subject.AddFormattedText(text, format);
			builder?.Invoke(new FluentFormattedText(formattedText));
			return this;
		}

		public FluentFormattedText FormattedText(string? styleName, string text, Action<FluentFormattedText>? builder = null)
		{
			var formattedText = Subject.AddFormattedText(text, styleName);
			builder?.Invoke(new FluentFormattedText(formattedText));
			return this;
		}

		public FluentFormattedText Image(string fileName, Action<FluentImage>? builder = null)
		{
			var image = Subject.AddImage(fileName);
			builder?.Invoke(new FluentImage(image));
			return this;
		}

		public FluentFormattedText Text(string text)
		{
			Subject.AddText(text);
			return this;
		}
	}
}