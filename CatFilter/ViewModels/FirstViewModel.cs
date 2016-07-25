using System.Collections.Generic;
using CatFilter.Core.Services;
using MvvmCross.Core.ViewModels;

namespace CatFilter.Core.ViewModels
{
	public class FirstViewModel
		: MvxViewModel
	{
		public FirstViewModel(IDataService dataService, IKittenGenesisService kittenGenesisService)
		{
			_dataService = dataService;
			_kittenGenesisService = kittenGenesisService;
		}

		private string _filter = "";

		public string Filter
		{
			get { return _filter;}
			set { SetProperty(ref _filter, value); }
		}

		private List<Kitten> _kittens;

		public List<Kitten> Kittens
		{
			get { return _kittens; }
			set { SetProperty(ref _kittens, value); }
		}

		private MvxCommand _applyFilterCommand;

		public System.Windows.Input.ICommand ApplyFilterCommand
		{
			get
			{
				_applyFilterCommand = _applyFilterCommand ?? new MvxCommand(DoApplyFilter);
				return _applyFilterCommand;
			}
		}

		private void DoApplyFilter()
		{
			var filtratedCats = _dataService.KittensMatching(Filter);
			Kittens = filtratedCats;
		}

		private int _totalKittenCount;

		public int TotalKittenCount
		{
			get { return _totalKittenCount; }
			set { SetProperty(ref _totalKittenCount, value); }
		}

		private MvxCommand _addACatCommand;

		public System.Windows.Input.ICommand AddACatCommand
		{
			get
			{
				_addACatCommand = _addACatCommand ?? new MvxCommand(AddACat);
				return _addACatCommand;
			}
		}

		private void AddACat()
		{
			//get-a-cat
			var cat = _kittenGenesisService.CreateNewKitten(_count.ToString());
			_count++;
			//insert-a-cat
			_dataService.Insert(cat);
			//update-a-count
			RefreshCounter();
		}

		private void RefreshCounter()
		{
			TotalKittenCount = _dataService.Count;
		}

		private int _count = 0;

		private readonly IDataService _dataService;
		private readonly IKittenGenesisService _kittenGenesisService;
	}
}
