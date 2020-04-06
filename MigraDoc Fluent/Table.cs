using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public static partial class Fluent
	{
		public static IFluentTableSomeColumns Column(this IFluentTableEditableColumns table, Action<FluentColumn>? builder = null)
		{
			var column = table.Subject.AddColumn();
			builder?.Invoke(new FluentColumn(column));
			return (IFluentTableSomeColumns) table;
		}

		public static IFluentTableSomeColumns Columns(this IFluentTableEditableColumns table, int columnCount)
		{
			for (int i = 0; i < columnCount; ++i)
			{
				table.Subject.AddColumn();
			}

			return (IFluentTableSomeColumns) table;
		}

		public static IFluentTableEditableRows Row(this IFluentTableEditableRows table, Action<FluentRow>? builder = null)
		{
			var row = table.Subject.AddRow();
			builder?.Invoke(new FluentRow(row));
			return table;
		}

		public static IFluentTableEditableRows Rows(this IFluentTableEditableRows table, int rowCount,
			Action<FluentRow, int>? builder = null)
		{
			for (StrongBox<int> i = new StrongBox<int>(0); i.Value < rowCount; ++i.Value)
			{
				table.Row(r => builder(r, i.Value));
			}
			return table;
		}

		public static IFluentTableEditableRows RowForEach<T>(this IFluentTableEditableRows table, IEnumerable<T> eachOf,
			Action<FluentRow, T> builder)
		{
			foreach (var each in eachOf)
				table.Row(r => builder(r, each));
			return table;
		}
	}

	struct FluentTable : IFluentTableSomeColumns, IFluentTableNoColumns
	{
		public Table Subject { get; }

		public FluentTable(Table subject)
		{
			Subject = subject;
		}
	}

	public interface IFluentTableEditableColumns : IFluentTable
	{
	}

	public interface IFluentTableEditableRows : IFluentTable
	{
	}

	public interface IFluentTableNoColumns : IFluentTableEditableColumns
	{
	}

	public interface IFluentTableSomeColumns : IFluentTableEditableColumns, IFluentTableEditableRows
	{
	}

	public interface IFluentTable
	{
		public Table Subject { get; }
	}
}