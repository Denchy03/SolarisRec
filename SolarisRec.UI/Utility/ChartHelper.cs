using SolarisRec.Core.Faction;

namespace SolarisRec.UI.Utility
{
    internal static class ChartHelper
    {
        public static string[] GenerateChartPalette(string[] labels)
        {
            var size = labels.Length;

            var result = new string[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = GetColorCode(labels[i][..labels[i].IndexOf(" ")]);
            }

            return result;
        }

        private static string GetColorCode(string factionName)
        {
            return factionName switch
            {
                FactionConstants.Belt => "#2E2F30",
                FactionConstants.Earth => "#4E843D",
                FactionConstants.Mars => "#D73B4A",
                FactionConstants.Mercury => "#EEB01F",
                FactionConstants.Titan => "#0473B8",
                FactionConstants.Venus => "#9A72AB",
                _ => "#000000",
            };
        }
    }
}