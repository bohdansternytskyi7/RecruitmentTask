using RecruitmentTask.Interfaces;

namespace RecruitmentTask.Services
{
	public class FileService : IFileService
	{
		private readonly string _filePath;

		public FileService(string filePath)
		{
			_filePath = filePath;
		}

		public async Task WriteToFile(string text)
		{
			using (StreamWriter writer = File.AppendText(_filePath))
			{
				await writer.WriteLineAsync(text);
			}
		}
	}
}
