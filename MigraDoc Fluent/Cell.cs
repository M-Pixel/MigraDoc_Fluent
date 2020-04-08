using System;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public struct FluentCell
	{
		public Cell Subject { get; }

		public FluentCell(Cell subject)
		{
			Subject = subject;
		}

		public FluentCell Image(string fileName, Action<FluentImage>? builder = null)
		{
			var image = Subject.AddImage(fileName);
			builder?.Invoke(new FluentImage(image));
			return this;
		}

		public FluentCell Paragraph(string? styleName, string? paragraphText = null,
			Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText);
			paragraph.Style = styleName;
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}
	}
}