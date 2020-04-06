using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentPlainText
	{
		public Text Subject { get; }

		public FluentPlainText(Text subject)
		{
			Subject = subject;
		}
	}
}