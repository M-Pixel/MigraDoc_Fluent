using System;
using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public static partial class Fluent
	{
		public static FluentDocument DeclareDocument() => new Document().AsFluent();
		public static FluentDocument AsFluent(this Document document) => new FluentDocument(document);

		public static Document AppendSection(this Document document, Action<Section> builder)
		{
			builder(document.AddSection());
			return document;
		}
	}

	public struct FluentDocument
	{
		public Document Subject { get; }

		public FluentDocument(Document subject)
		{
			Subject = subject;
		}

		public FluentDocument Section(Action<FluentSection> f)
		{
			f(new FluentSection(Subject.AddSection()));
			return this;
		}
	}
}