namespace Names
{
    internal static class HistogramTask
    {
        private const int DayInMonth = 31;
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var xLabelsDay = new string[DayInMonth];
            var yCountPeople = new double[DayInMonth];

            for ( int i = 0; i < DayInMonth; i ++)
                xLabelsDay[i] = $"{i+1}";
            
            foreach(var item in names)
                if (item.Name == name && item.BirthDate.Day != 1)
                    yCountPeople[item.BirthDate.Day - 1]++;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                xLabelsDay,
                yCountPeople);
        }
    }
}