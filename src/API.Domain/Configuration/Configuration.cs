using System.Text.Json;

namespace Domain.Configuration
{
    public static class Configuration
    {
        public static DbSettings? GetConfiguration()
        {
            string? filePath;

            if (Directory.GetCurrentDirectory().Contains("Test"))
            {
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.Replace("\\test", string.Empty);
                filePath = Path.Combine(projectDirectory, "src", "API.Environment", "DbSettings.json");
            }
            else
            {
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API.Environment", "DbSettings.json");
            }

            string jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<DbSettings>(jsonContent);
        }
    }
}
