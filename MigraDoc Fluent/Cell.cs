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


		public FluentCell Set(RoundedCorner roundedCorner)
		{
			Subject.RoundedCorner = roundedCorner;
			return this;
		}

		public FluentCell Set(VerticalAlignment verticalAlignment)
		{
			Subject.VerticalAlignment = verticalAlignment;
			return this;
		}


		public FluentCell MergeDown(int cellCount)
		{
			Subject.MergeDown = cellCount;
			return this;
		}

		public FluentCell MergeRight(int cellCount)
		{
			Subject.MergeRight = cellCount;
			return this;
		}

		public FluentCell Image(string fileName, Action<FluentImage>? builder = null)
		{
			var image = Subject.AddImage(fileName);
			builder?.Invoke(new FluentImage(image));
			return this;
		}

		public FluentCell Paragraph(string styleName, string paragraphText = null,
			Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph(paragraphText);
			paragraph.Style = styleName;
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}

		public FluentCell Paragraph(string styleName, Action<FluentParagraph>? builder = null)
		{
			var paragraph = Subject.AddParagraph();
			paragraph.Style = styleName;
			builder?.Invoke(new FluentParagraph(paragraph));
			return this;
		}

		public FluentCell Paragraph(Action<FluentParagraph> builder)
		{
			builder(new FluentParagraph(Subject.AddParagraph()));
			return this;
		}
	}
}