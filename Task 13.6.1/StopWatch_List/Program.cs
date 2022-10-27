using StopWatch_List;
using System.Diagnostics;

List<string> testList = new List<string>();

Console.WriteLine("Введите путь до файла с текстом:");
string path = Console.ReadLine();
StreamReader f = new StreamReader(path);

#region Оценка вставки в List через метод Add:
StopwatchRecording swRec1 = new("Тест 1 - List - метод Add");

while (!f.EndOfStream)
{
    string s = f.ReadLine();

    // Запустим таймер
    var watch = Stopwatch.StartNew();

    // Выполним вставку
    testList.Add(s);

    // Сохраним результат
    swRec1.SaveResult(watch.Elapsed.TotalMilliseconds);
}
f.Close();
#endregion

#region Оценка вставки в List через метод Insert:
StopwatchRecording swRec2 = new("Тест 2 - List - метод Insert");

string putString = "Строка для вставки";

for (int i = testList.LastIndexOf(testList.Max()); i > 0; i--)
{
    // Запустим таймер
    var watch = Stopwatch.StartNew();

    // Выполним вставку
    testList.Insert(i, putString);

    // Сохраним результат
    swRec2.SaveResult(watch.Elapsed.TotalMilliseconds);
}
#endregion

// Вывод результатов

Console.WriteLine();
swRec1.Show();

Console.WriteLine();
swRec2.Show();

Console.ReadKey();