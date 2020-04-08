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


		public FluentSection Image(string fileName, Action<FluentImage>? builder = null)
		{
			var image = Subject.AddImage(fileName);
			builder?.Invoke(new FluentImage(image));
			return this;
		}

		public FluentSection Paragraph(Action<FluentParagraph> builder)
		{
			builder(new FluentParagraph(Subject.AddParagraph()));
			return this;
		}

		public FluentSection Paragraph(string styleName, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph();
			paragraph.Style = styleName;
			builder.Invoke(new FluentParagraph(paragraph));
			return this;
		}

		public FluentSection Paragraph(string? styleName, string paragraphText, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText, styleName);
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}

		public FluentSection Table(Action<IFluentTableNoColumns> builder)
		{
			builder.Invoke(new FluentTable(Subject.AddTable()));
			return this;
		}

		public FluentSection Table(string styleName, Action<IFluentTableNoColumns> builder)
		{
			var table = Subject.AddTable();
			table.Style = styleName;
			builder.Invoke(new FluentTable(table));
			return this;
		}
	}
}