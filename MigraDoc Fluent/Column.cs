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
	}
}