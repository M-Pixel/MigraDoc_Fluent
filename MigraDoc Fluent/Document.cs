using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public static partial class Fluent
	{
		public static FluentDocument DeclareDocument() => DeclareDocument(out _);
		public static FluentDocument DeclareDocument(out Document document) => (document = new Document()).AsFluent();
		public static FluentDocument AsFluent(this Document document) => new FluentDocument(document);
	}

	public struct FluentDocument
	{
		public Document Subject { get; }

		public FluentDocument(Document subject)
		{
			Subject = subject;
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