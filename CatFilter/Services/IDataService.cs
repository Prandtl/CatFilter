using System.Collections.Generic;

namespace CatFilter.Core.Services
{
	public interface IDataService
	{
		List<Kitten> KittensMatching(string filter);
		void Insert(Kitten kitten);
		void Update(Kitten kitten);
		void Delete(Kitten kitten);
		int Count { get; }
	}
}
