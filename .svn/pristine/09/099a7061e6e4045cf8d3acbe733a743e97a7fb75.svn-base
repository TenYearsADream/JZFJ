using BusinessLogic.Configuration;

namespace BusinessLogic.Download
{
    public class SortingLine
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }


        public static string GetSortingLineCode()
        {
            Settings settings = Settings.GetSettings();
            return settings.GetSettingByName("LineCode").Value;
        }
    }
}
