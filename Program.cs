using Microsoft.Extensions.DependencyInjection;
using RecruitmentTask.Interfaces;
using RecruitmentTask.Services;

class Program
{
	static async Task Main()
	{
		var serviceProvider = new ServiceCollection()
			.AddHttpClient()
			.AddTransient<IHttpService, HttpService>()
			.AddTransient<IFileService, FileService>(provider =>
			{
				string filePath = "cat_facts.txt";
				return new FileService(filePath);
			})
			.BuildServiceProvider();

		var httpService = serviceProvider.GetService<IHttpService>();
		var fileService = serviceProvider.GetService<IFileService>();

		try
		{
			string catFact = await httpService.GetCatFact();
			await fileService.WriteToFile(catFact);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
	}
}