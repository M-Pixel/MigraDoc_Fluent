using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public static partial class Fluent
	{
		public static FluentDocument DeclareDocument() => DeclareDocument(out _);
		public static FluentDocument DeclareDocument(out Document document) => (document = new Document()).AsFluent();
		public static FluentDocument AsFluent(this Document document) => new FluentDocument(document);

		public static Unit cm(this double value) => new Unit(value, UnitType.Centimeter);
		public static Unit cm(this int value) => new Unit(value, UnitType.Centimeter);
		public static Unit inch(this double value) => new Unit(value, UnitType.Inch);
		public static Unit inch(this int value) => new Unit(value, UnitType.Inch);
		public static Unit mm(this double value) => new Unit(value, UnitType.Millimeter);
		public static Unit mm(this int value) => new Unit(value, UnitType.Millimeter);
		public static Unit pt(this double value) => new Unit(value, UnitType.Point);
		public static Unit pt(this int value) => new Unit(value, UnitType.Centimeter);
		public static Unit pc(this double value) => new Unit(value, UnitType.Centimeter);
		public static Unit pc(this int value) => new Unit(value, UnitType.Centimeter);
	}

	public struct FluentDocument
	{
		public Document Subject { get; }

		public FluentDocument(Document subject)
		{
			Subject = subject;
		}

		public FluentDocument DefaultPageSetup(Action<FluentPageSetup> builder) => DefaultPageSetup(out _, builder);
		public FluentDocument DefaultPageSetup(out PageSetup setup, Action<FluentPageSetup> builder)
		{
			builder(new FluentPageSetup(setup = Subject.DefaultPageSetup));
			return this;
		}

		public FluentDocument Style(string styleName, string baseName, Action<FluentStyle> builder)
		{
			var style = Subject.AddStyle(styleName, baseName);
			builder(new FluentStyle(style));
			return this;
		}

		public FluentDocument Section(Action<FluentSection> builder)
		{
			builder(new FluentSection(Subject.AddSection()));
			return this;
		}
	}
}