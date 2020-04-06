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

		public FluentParagraph PlainText(string text, Action<Text>? builder = null)
		{
			var plainText = Subject.AddText(text);
			builder?.Invoke(plainText);
			return this;
		}

		public FluentParagraph FormattedText(string text, TextFormat format, Action<FluentFormattedText>? builder = null)
		{
			var formattedText = Subject.AddFormattedText(text, format);
			builder?.Invoke(new FluentFormattedText(formattedText));
			return this;
		}
	}
}