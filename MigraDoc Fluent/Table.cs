using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MigraDoc.DocumentObjectModel.Tables;

namespace MigraDoc
{
	public static partial class Fluent
	{
		public static T Style<T>(this T table, string styleName)
			where T : IFluentTableEditableProperties
		{
			table.Subject.Style = styleName;
			return table;
		}

		public static IFluentTableSomeColumns Column(this IFluentTableEditableColumns table, Action<FluentColumn>? builder = null)
		{
			var column = table.Subject.AddColumn();
			builder?.Invoke(new FluentColumn(column));
			return (IFluentTableSomeColumns) table;
		}

		public static IFluentTableSomeColumns Column(this IFluentTableEditableColumns table, string styleName,
			Action<FluentColumn>? builder = null)
		{
			var column = table.Subject.AddColumn();
			column.Style = styleName;
			builder?.Invoke(new FluentColumn(column));
			return (IFluentTableSomeColumns) table;
		}

		public static IFluentTableSomeColumns Columns(this IFluentTableEditableColumns table, int columnCount, string? styleName = null)
		{
			for (int i = 0; i < columnCount; ++i)
			{
				var column = table.Subject.AddColumn();
				column.Style = styleName;
			}

			return (IFluentTableSomeColumns) table;
		}

		public static IFluentTableSomeRows Row(this IFluentTableEditableRows table, Action<FluentRow>? builder = null)
		{
			var row = table.Subject.AddRow();
			builder?.Invoke(new FluentRow(row));
			return (IFluentTableSomeRows) table;
		}

		public static IFluentTableSomeRows Row(this IFluentTableEditableRows table, string styleName,
			Action<FluentRow>? builder = null)
		{
			var row = table.Subject.AddRow();
			row.Style = styleName;
			builder?.Invoke(new FluentRow(row));
			return (IFluentTableSomeRows) table;
		}

		public static IFluentTableSomeRows Rows(this IFluentTableEditableRows table, int rowCount,
			Action<FluentRow, int>? builder = null)
		{
			for (StrongBox<int> i = new StrongBox<int>(0); i.Value < rowCount; ++i.Value)
			{
				table.Row(r => builder(r, i.Value));
			}
			return (IFluentTableSomeRows) table;
		}

		public static IFluentTableSomeRows Rows(this IFluentTableEditableRows table, int rowCount, string styleName,
			Action<FluentRow, int>? builder = null)
		{
			for (StrongBox<int> i = new StrongBox<int>(0); i.Value < rowCount; ++i.Value)
				table.Row(styleName, r => builder(r, i.Value));
			return (IFluentTableSomeRows) table;
		}

		public static IFluentTableSomeRows RowForEach<T>(this IFluentTableEditableRows table, IEnumerable<T> eachOf,
			Action<FluentRow, T> builder)
		{
			foreach (var each in eachOf)
				table.Row(r => builder(r, each));
			return (IFluentTableSomeRows) table;
		}

		public static IFluentTableSomeRows RowForEach<T>(this IFluentTableEditableRows table, IEnumerable<T> eachOf,
			string styleName, Action<FluentRow, T> builder)
		{
			foreach (var each in eachOf)
				table.Row(styleName, r => builder(r, each));
			return (IFluentTableSomeRows) table;
		}
	}

	struct FluentTable : IFluentTableNoColumns, IFluentTableSomeColumns, IFluentTableSomeRows
	{
		public Table Subject { get; }

		public FluentTable(Table subject)
		{
			Subject = subject;
		}
	}

	public interface IFluentTableEditableProperties : IFluentTable
	{
	}

	public interface IFluentTableEditableColumns : IFluentTable
	{
	}

	public interface IFluentTableEditableRows : IFluentTable
	{
	}

	public interface IFluentTableNoColumns : IFluentTableEditableColumns, IFluentTableEditableProperties
	{
	}

	public interface IFluentTableSomeColumns : IFluentTableEditableColumns, IFluentTableEditableRows
	{
	}

	public interface IFluentTableSomeRows : IFluentTableEditableRows
	{
	}

	public interface IFluentTable
	{
		public Table Subject { get; }
	}
}