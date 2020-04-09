using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;

namespace MigraDoc
{
	public struct FluentImage
	{
		// TODO: Shape things should be done via interface

		public Image Subject { get; }

		public FluentImage(Image subject)
		{
			Subject = subject;
		}


		public FluentImage Set(RelativeHorizontal relativeHorizontal)
		{
			Subject.RelativeHorizontal = relativeHorizontal;
			return this;
		}

		public FluentImage Set(RelativeVertical relativeVertical)
		{
			Subject.RelativeVertical = relativeVertical;
			return this;
		}


		public FluentImage Height(Unit height)
		{
			Subject.Height = height;
			return this;
		}

		public FluentImage LockAspectRatio(bool lockAspectRatio = true)
		{
			Subject.LockAspectRatio = lockAspectRatio;
			return this;
		}

		public FluentImage PositionLeft(ShapePosition position)
		{
			Subject.Left = position;
			return this;
		}

		public FluentImage PositionLeft(Unit position)
		{
			Subject.Left = position;
			return this;
		}

		public FluentImage PositionTop(ShapePosition position)
		{
			Subject.Top = position;
			return this;
		}

		public FluentImage PositionTop(Unit position)
		{
			Subject.Top = position;
			return this;
		}

		public FluentImage Position(ShapePosition left, ShapePosition top)
		{
			Subject.Left = left;
			Subject.Top = top;
			return this;
		}

		public FluentImage Position(ShapePosition left, Unit top)
		{
			Subject.Left = left;
			Subject.Top = top;
			return this;
		}

		public FluentImage Position(Unit left, ShapePosition top)
		{
			Subject.Left = left;
			Subject.Top = top;
			return this;
		}

		public FluentImage Position(Unit left, Unit top)
		{
			Subject.Left = left;
			Subject.Top = top;
			return this;
		}

		public FluentImage Resolution(double resolutionDPI)
		{
			Subject.Resolution = resolutionDPI;
			return this;
		}

		public FluentImage ScaleHeight(double heightScale)
		{
			Subject.ScaleHeight = heightScale;
			return this;
		}

		public FluentImage ScaleWidth(double widthScale)
		{
			Subject.ScaleWidth = widthScale;
			return this;
		}

		public FluentImage Scale(double widthScale, double heightScale)
		{
			Subject.ScaleWidth = widthScale;
			Subject.ScaleHeight = heightScale;
			return this;
		}

		public FluentImage Width(Unit width)
		{
			Subject.Width = width;
			return this;
		}


		public FluentImage Crop(Unit top, Unit right, Unit bottom, Unit left)
		{
			Subject.PictureFormat.CropTop = top;
			Subject.PictureFormat.CropRight = right;
			Subject.PictureFormat.CropBottom = bottom;
			Subject.PictureFormat.CropLeft = left;
			return this;
		}

		public FluentImage Fill(byte red, byte green, byte blue, byte? opacity) =>
			Fill(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentImage Fill(double cyan, double yellow, double magenta, double? opacity) =>
			Fill(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentImage Fill(Color color)
		{
			var fillFormat = Subject.FillFormat;
			fillFormat.Color = color;
			fillFormat.Visible = true;
			return this;
		}

		public FluentImage Fill(bool visible = true)
		{
			Subject.FillFormat.Visible = visible;
			return this;
		}

		public FluentImage Line(Color color, Unit width, LineStyle style, DashStyle dashStyle)
		{
			var lineFormat = Subject.LineFormat;
			lineFormat.Visible = true;
			lineFormat.Color = color;
			lineFormat.Width = width;
			lineFormat.Style = style;
			lineFormat.DashStyle = dashStyle;
			return this;
		}

		public FluentImage Wrap(WrapStyle style, Unit distanceTop, Unit distanceRight, Unit distanceBottom, Unit distanceLeft)
		{
			var wrapFormat = Subject.WrapFormat;
			wrapFormat.Style = style;
			wrapFormat.DistanceTop = distanceTop;
			wrapFormat.DistanceRight = distanceRight;
			wrapFormat.DistanceBottom = distanceBottom;
			wrapFormat.DistanceLeft = distanceLeft;
			return this;
		}
	}
}