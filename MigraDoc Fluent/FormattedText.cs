using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentFormattedText
	{
		public FormattedText Subject { get; }

		public FluentFormattedText(FormattedText subject)
		{
			Subject = subject;
		}
	}
}