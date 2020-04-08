using MigraDoc.DocumentObjectModel;

namespace MigraDoc
{
	public struct FluentPageSetup
	{
		public PageSetup Subject { get; }

		public FluentPageSetup(PageSetup subject)
		{
			Subject = subject;
		}

		public FluentPageSetup Set(PageFormat format)
		{
			Subject.PageFormat = format;
			return this;
		}
	}
}