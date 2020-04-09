using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public interface IFluentEdgeBorder
	{
		/// <summary>
		/// Set the line style of the border.
		/// </summary>
		public FluentBorder Set(BorderStyle style);

		/// <summary>
		/// The color of the border, using RGB values from <c>0</c> to <c>255</c>.
		/// </summary>
		public FluentBorder Color(byte red, byte green, byte blue, byte opacity = byte.MaxValue);

		/// <summary>
		/// The color of the border, using CMYK values from <c>0.0d</c> to <c>1.0d</c>.
		/// </summary>
		public FluentBorder Color(double cyan, double yellow, double magenta, double opacity = 1.0d);

		/// <summary>
		/// The color of the border.
		/// </summary>
		public FluentBorder Color(Color color);

		/// <summary>
		/// The distance between the text (or other contents) and the border.
		/// </summary>
		public FluentBorder Distance(Unit distance);

		/// <summary>
		/// Whether or not the border is visible.
		/// </summary>
		public FluentBorder Visible(bool visible);

		/// <summary>
		/// The width of the lines that make up the border.
		/// </summary>
		public FluentBorder Width(Unit unit);
	}

	public struct FluentBorder : IFluentEdgeBorder
	{
		public Border Subject { get; }
		public Borders Parent { get; }
		public BorderType Type { get; }

		public FluentBorder(Border subject, Borders parent, BorderType type)
		{
			Subject = subject;
			Parent = parent;
			Type = type;
		}


		/// <summary>
		/// Set the line style of the border.
		/// </summary>
		public FluentBorder Set(BorderStyle style)
		{
			Subject.Style = style;
			return this;
		}


		/// <summary>
		/// The color of the border, using RGB values from <c>0</c> to <c>255</c>.
		/// </summary>
		public FluentBorder Color(byte red, byte green, byte blue, byte opacity = byte.MaxValue) =>
			Color(new Color(opacity, red, green, blue));
		/// <summary>
		/// The color of the border, using CMYK values from <c>0.0d</c> to <c>1.0d</c>.
		/// </summary>
		public FluentBorder Color(double cyan, double yellow, double magenta, double opacity = 1.0d) =>
			Color(new Color(opacity, cyan, yellow, magenta));
		/// <summary>
		/// The color of the border.
		/// </summary>
		public FluentBorder Color(Color color)
		{
			Subject.Color = color;
			return this;
		}

		FluentBorder IFluentEdgeBorder.Distance(Unit distance)
		{
			switch (Type)
			{
				case BorderType.Top:
					Parent.DistanceFromTop = distance;
					break;
				case BorderType.Left:
					Parent.DistanceFromLeft = distance;
					break;
				case BorderType.Bottom:
					Parent.DistanceFromBottom = distance;
					break;
				case BorderType.Right:
					Parent.DistanceFromRight = distance;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			return this;
		}

		/// <summary>
		/// Whether or not the border is visible.
		/// </summary>
		public FluentBorder Visible(bool visible = true)
		{
			Subject.Visible = visible;
			return this;
		}

		/// <summary>
		/// The width of the lines that make up the border.
		/// </summary>
		public FluentBorder Width(Unit unit)
		{
			Subject.Width = unit;
			return this;
		}
	}
}