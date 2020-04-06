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

		public FluentCell Paragraph(string paragraphText, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText);
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}
	}
}