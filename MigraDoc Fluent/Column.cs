using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public struct FluentColumn
	{
		public Column Subject { get; }

		public FluentColumn(Column subject)
		{
			Subject = subject;
		}

		/// <summary>
		/// Whether or not this column is a header.
		/// </summary>
		public FluentColumn Heading(bool headingFormat = true)
		{
			Subject.HeadingFormat = headingFormat;
			return this;
		}

		/// <summary>
		/// The default left- and right-padding for all cells of the column.
		/// </summary>
		public FluentColumn Padding(Unit padding)
		{
			Subject.LeftPadding = padding;
			Subject.RightPadding = padding;
			return this;
		}

		/// <summary>
		/// The default left- and right-padding for all cells of the column.
		/// </summary>
		public FluentColumn Padding(Unit leftPadding, Unit rightPadding)
		{
			Subject.LeftPadding = leftPadding;
			Subject.RightPadding = rightPadding;
			return this;
		}

		/// <summary>
		/// The default left-padding for all cells of the column.
		/// </summary>
		public FluentColumn PaddingLeft(Unit padding)
		{
			Subject.LeftPadding = padding;
			return this;
		}

		/// <summary>
		/// The default right-padding for all cells of the column.
		/// </summary>
		public FluentColumn PaddingRight(Unit padding)
		{
			Subject.RightPadding = padding;
			return this;
		}

		public FluentColumn Width(Unit width)
		{
			Subject.Width = width;
			return this;
		}
	}
}