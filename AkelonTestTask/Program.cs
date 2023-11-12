namespace AkelonTestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<DateTime>> vacationDictionary = new ()
            {
                ["Иванов Иван Иванович"] = new (),
                ["Петров Петр Петрович"] = new (),
                ["Юлина Юлия Юлиановна"] = new (),
                ["Сидоров Сидор Сидорович"] = new (),
                ["Павлов Павел Павлович"] = new (),
                ["Георгиев Георг Георгиевич"] = new ()
            };
            var aviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            // Список отпусков сотрудников
            List<DateTime> vacations = new List<DateTime>();
            List<DateTime> dateList = new List<DateTime>();

            foreach (var vacationList in vacationDictionary)
            {
                Random gen = new Random();

                DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime end = new DateTime(DateTime.Today.Year, 12, 31);

                dateList = vacationList.Value;
                int vacationCount = 28;

                while (vacationCount > 0)
                {
                    int range = (end - start).Days;
                    var startDate = start.AddDays(gen.Next(range));

                    if (aviableWorkingDaysOfWeekWithoutWeekends.Contains(startDate.DayOfWeek.ToString()))
                    {
                        int[] vacationSteps = { 7, 14 };
                        int vacIndex = gen.Next(vacationSteps.Length);
                        var endDate = new DateTime(DateTime.Now.Year, 12, 31);
                        float difference = 0;
                        if (vacationCount <= 7)
                        {
                            endDate = startDate.AddDays(7);
                            difference = 7;
                        }
                        else
                        {
                            var step = vacationSteps[vacIndex];
                            endDate = startDate.AddDays(step);
                            difference = step;
                        }                        

                        if (!vacations.Any(element => element >= startDate && element <= endDate))
                        {
                            if (!vacations.Any(element => element.AddDays(3) >= startDate && element.AddDays(3) <= endDate))
                            {
                                for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1))
                                {
                                    vacations.Add(dt);
                                    dateList.Add(dt);
                                }

                                vacationCount -= (int)difference;
                            }
                        }
                    }
                }
            }

            List<DateTime> setDateList = new List<DateTime>();

            foreach (var vacationList in vacationDictionary)
            {
                setDateList = vacationList.Value;
                Console.WriteLine("Дни отпуска " + vacationList.Key + " : ");
                for (int i = 0; i < setDateList.Count; i++) { Console.WriteLine(setDateList[i]); }
            }

            Console.ReadKey();
        }
    }
}

