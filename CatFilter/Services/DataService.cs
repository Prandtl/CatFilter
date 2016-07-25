using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace CatFilter.Core.Services
{
	public class DataService : IDataService
	{
		private readonly SQLiteConnection _connection;

		public DataService(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("cat.sql");
			_connection.CreateTable<Kitten>();
		}

		public List<Kitten> KittensMatching(string filter)
		{
			return _connection.Table<Kitten>()
				.Where(c => c.Name.Contains(filter))
				.OrderBy(c => c.Price)
				.ToList();
		}

		public void Insert(Kitten kitten)
		{
			_connection.Insert(kitten);
		}

		public void Update(Kitten kitten)
		{
			_connection.Update(kitten);
		}

		public void Delete(Kitten kitten)
		{
			_connection.Delete(kitten);
		}

		public int Count => _connection.Table<Kitten>().Count();
	}
}