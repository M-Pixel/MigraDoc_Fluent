using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentBorder
	{
		public Border Subject { get; }

		public FluentBorder(Border subject)
		{
			Subject = subject;
		}

		public FluentBorder Set(BorderStyle style)
		{
			Subject.Style = style;
			return this;
		}

		public FluentBorder Color(byte red, byte green, byte blue, byte? opacity) =>
			Color(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentBorder Color(double cyan, double yellow, double magenta, double? opacity) =>
			Color(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentBorder Color(Color color)
		{
			Subject.Color = color;
			return this;
		}

		public FluentBorder Visible(bool visible)
		{
			Subject.Visible = visible;
			return this;
		}

		public FluentBorder Width(Unit unit)
		{
			Subject.Width = unit;
			return this;
		}
	}
}