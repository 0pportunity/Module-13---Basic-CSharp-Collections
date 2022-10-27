namespace StopWatch_List
{
    internal class StopwatchRecording
    {
        private string description;
        // Переменные для записи результатов
        private double minTime;
        private double maxTime;
        private double middleTime;
        private List<double> results;
        private int i; // Счетчик

        public StopwatchRecording(string description)
        {
            this.description = description;
            minTime = double.MaxValue;
            maxTime = double.MinValue;
            middleTime = 0;
            results = new List<double>();
            i = 0;
        }

        /// <summary>
        /// Запись минимального и максимального значения, подсчёт среднего. Сохранение значения результата.
        /// </summary>
        /// <param name="result"></param>
        public void SaveResult(double result)
        {
            results.Add(result);
            middleTime = (middleTime * i + result) / ++i; // Уточнение среднего значения
            if (minTime > result) { minTime = result; } // Фиксация минимального значения
            if (maxTime < result) { maxTime = result; } // Фиксация максимального значения
        }

        /// <summary>
        /// Вывод результата в консоль
        /// </summary>
        public void Show()
        {
            Console.WriteLine(description);
            Console.WriteLine($"\tСреднее время вставки: {middleTime} мс");
            Console.WriteLine($"\tМаксимальное время вставки: {maxTime} мс");
            Console.WriteLine($"\tМинимальное время вставки: {minTime} мс");
        }
    }
}
