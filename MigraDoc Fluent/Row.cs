using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public struct FluentRow
	{
		public Row Subject { get; }
		private int _cellIdx;

		private Cell NextCell => Subject.Cells[_cellIdx++];

		public FluentRow(Row subject)
		{
			Subject = subject;
			_cellIdx = 0;
		}

		public FluentRow Cell(Action<FluentCell> builder)
		{
			builder(new FluentCell(NextCell));
			return this;
		}

		public FluentRow Cell(string text)
		{
			NextCell.AddParagraph(text);
			return this;
		}

		public FluentRow Cell(string? styleName, string text)
		{
			NextCell.AddParagraph(text).Style = styleName;
			return this;
		}

		public FluentRow Cell(TextFormat textFormat, string text)
		{
			var paragraph = NextCell.AddParagraph();
			paragraph.AddFormattedText(text, textFormat);
			return this;
		}
	}
}