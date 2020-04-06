using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public struct FluentColumn
	{
		public FluentColumn(Column subject)
		{
			Subject = subject;
		}

		public Column Subject { get; }
	}
}