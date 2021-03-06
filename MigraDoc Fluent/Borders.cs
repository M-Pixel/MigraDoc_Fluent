using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentBorders
	{
		public Borders Subject { get; }

		public FluentBorders(Borders subject)
		{
			Subject = subject;
		}


		public FluentBorders Set(BorderStyle style)
		{
			Subject.Style = style;
			return this;
		}


		public FluentBorders Color(byte red, byte green, byte blue, byte? opacity) =>
			Color(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentBorders Color(double cyan, double yellow, double magenta, double? opacity) =>
			Color(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentBorders Color(Color color)
		{
			Subject.Color = color;
			return this;
		}


		public FluentBorders Distance(Unit unit)
		{
			Subject.Distance = unit;
			return this;
		}

		public FluentBorders Distance(Unit? top, Unit? right, Unit? bottom, Unit? left)
		{
			Subject.DistanceFromTop = top ?? Unit.Empty;
			Subject.DistanceFromRight = right ?? Unit.Empty;
			Subject.DistanceFromBottom = bottom ?? Unit.Empty;
			Subject.DistanceFromLeft = left ?? Unit.Empty;
			return this;
		}

		public FluentBorders Visible(bool visible = true)
		{
			Subject.Visible = visible;
			return this;
		}

		public FluentBorders Width(Unit width)
		{
			Subject.Width = width;
			return this;
		}


		public FluentBorders Bottom(Action<IFluentEdgeBorder> builder)
		{
			builder(new FluentBorder(Subject.Bottom, Subject, BorderType.Bottom));
			return this;
		}

		public FluentBorders Left(Action<IFluentEdgeBorder> builder)
		{
			builder(new FluentBorder(Subject.Left, Subject, BorderType.Left));
			return this;
		}

		public FluentBorders Right(Action<IFluentEdgeBorder> builder)
		{
			builder(new FluentBorder(Subject.Right, Subject, BorderType.Right));
			return this;
		}

		public FluentBorders Top(Action<IFluentEdgeBorder> builder)
		{
			builder(new FluentBorder(Subject.Top, Subject, BorderType.Top));
			return this;
		}

		public FluentBorders DiagonalDown(Action<FluentBorder> builder)
		{
			builder(new FluentBorder(Subject.DiagonalDown, null, BorderType.DiagonalDown));
			return this;
		}

		public FluentBorders DiagonalUp(Action<FluentBorder> builder)
		{
			builder(new FluentBorder(Subject.DiagonalUp, null, BorderType.DiagonalUp));
			return this;
		}
	}
}