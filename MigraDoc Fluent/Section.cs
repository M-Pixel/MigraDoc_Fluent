using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentSection
	{
		public Section Subject { get; }

		public FluentSection(Section subject)
		{
			Subject = subject;
		}

		public FluentSection Paragraph(Action<FluentParagraph> builder)
		{
			builder(new FluentParagraph(Subject.AddParagraph()));
			return this;
		}

		public FluentSection Paragraph(string paragraphText, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText);
			builder.Invoke(new FluentParagraph(paragraph));
			return this;
		}
		public FluentSection Paragraph(string paragraphText, string styleName, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText, styleName);
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}

		public FluentSection Table(Action<IFluentTableNoColumns>? builder = null)
		{
			var table = Subject.AddTable();
			builder?.Invoke(new FluentTable(table));
			return this;
		}
	}
}