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

		public FluentRow Set(VerticalAlignment verticalAlignment)
		{
			Subject.VerticalAlignment = verticalAlignment;
			return this;
		}

		public FluentRow Set(RowHeightRule heightRule)
		{
			Subject.HeightRule = heightRule;
			return this;
		}

		public FluentRow Heading(bool isHeading = true)
		{
			Subject.HeadingFormat = true;
			return this;
		}

		public FluentRow Height(Unit height)
		{
			Subject.Height = height;
			return this;
		}

		/// <summary>
		/// The default top- and bottom-padding for all cells of the column.
		/// </summary>
		public FluentRow Padding(Unit padding)
		{
			Subject.TopPadding = padding;
			Subject.BottomPadding = padding;
			return this;
		}

		/// <summary>
		/// The default top- and bottom-padding for all cells of the column.
		/// </summary>
		public FluentRow Padding(Unit topPadding, Unit bottomPadding)
		{
			Subject.TopPadding = topPadding;
			Subject.BottomPadding = bottomPadding;
			return this;
		}

		/// <summary>
		/// The default bottom-padding for all cells of the column.
		/// </summary>
		public FluentRow PaddingBottom(Unit padding)
		{
			Subject.BottomPadding = padding;
			return this;
		}

		/// <summary>
		/// The default top-padding for all cells of the column.
		/// </summary>
		public FluentRow PaddingTop(Unit padding)
		{
			Subject.TopPadding = padding;
			return this;
		}

		public FluentRow Borders(Action<FluentBorders> builder)
		{
			builder(new FluentBorders(Subject.Borders));
			return this;
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

		public FluentRow Cell(string? styleName, string text, VerticalAlignment? verticalAlignment = null, RoundedCorner? roundedCorner = RoundedCorner.None)
		{
			var cell = NextCell;
			cell.AddParagraph(text).Style = styleName;
			if (verticalAlignment != null)
				cell.VerticalAlignment = verticalAlignment.Value;
			if (roundedCorner != null)
				cell.RoundedCorner = roundedCorner.Value;
			return this;
		}

		public FluentRow Cell(TextFormat textFormat, string text, VerticalAlignment? verticalAlignment = null, RoundedCorner? roundedCorner = RoundedCorner.None)
		{
			var paragraph = NextCell.AddParagraph();
			paragraph.AddFormattedText(text, textFormat);
			return this;
		}
	}
}