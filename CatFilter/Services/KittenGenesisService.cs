using System;
using System.Collections.Generic;

namespace CatFilter.Core.Services
{
	public class KittenGenesisService : IKittenGenesisService
	{
		public Kitten CreateNewKitten(string extra = "")
		{
			return new Kitten()
			{
				Name = _catNamesList[Random(_catNamesList.Count - 1)] + extra,
				ImgUrl = string.Format("http://placekitten.com/{0}/{0}", Random(20) + 300),
				Price = Random(23) + 3
			};
		}

		private readonly List<string> _catNamesList = new List<string>()
		{
			"Johnny",
			"Elvis",
			"Lazslo",
			"Rene",
			"Anre",
			"Ann",
			"Mary",
			"Lily",
			"Rose",
			"Oscar",
			"Scar",
			"Simba",
			"Nana",
			"Till",
			"Orwen",
			"Jon",
			"SN0WB4LL"
		};

		private int Random(int maxValue)
		{
			return _random.Next(maxValue);
		}
		private readonly Random _random = new Random();
	}
}