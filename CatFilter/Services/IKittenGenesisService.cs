namespace CatFilter.Core.Services
{
	public interface IKittenGenesisService
	{
		Kitten CreateNewKitten(string extra = "");
	}
}
