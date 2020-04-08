using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentShading
	{
		public Shading Subject { get; }

		public FluentShading(Shading subject)
		{
			Subject = subject;
		}

		public FluentShading Color(byte red, byte green, byte blue, byte? opacity) =>
			Color(new Color(opacity ?? byte.MaxValue, red, green, blue));
		public FluentShading Color(double cyan, double yellow, double magenta, double? opacity) =>
			Color(new Color(opacity ?? 1.0d, cyan, yellow, magenta));
		public FluentShading Color(Color color)
		{
			Subject.Color = color;
			return this;
		}

		public FluentShading Visible(bool visible)
		{
			Subject.Visible = visible;
			return this;
		}
	}
}