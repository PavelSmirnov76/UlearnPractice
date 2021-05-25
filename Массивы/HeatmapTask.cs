namespace Names
{
    internal static class HeatmapTask
    {
        private const int DayInMonth = 30;
        private const int MonthInYear = 12;
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var xLabelsDay = new string[DayInMonth];
            var yLabelsMonth = new string[MonthInYear];
            var masResult = new double[DayInMonth, MonthInYear];
            
            for (int i = 0; i < DayInMonth; i++)
                xLabelsDay[i] = $"{i+2}";
            for (int i = 0; i < MonthInYear; i++)
                yLabelsMonth[i] = $"{i + 1}";

            foreach (var name in names)
                if (name.BirthDate.Day != 1)
                    masResult[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;

            return new HeatmapData(
                "Пример карты интенсивностей",
                masResult,
                xLabelsDay,
                yLabelsMonth
              
                );
        }
    }
}