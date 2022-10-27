using StopWatch_LinkedList;
using System.Diagnostics;

LinkedList<string> testLinkedList = new LinkedList<string>();

Console.WriteLine("Введите путь до файла с текстом:");
string path = Console.ReadLine();
StreamReader f = new StreamReader(path);

#region Оценка вставки в LinkedList через метод AddLast:
StopwatchRecording swRec1 = new("Тест 1 - LinkedList - метод AddLast");

while (!f.EndOfStream)
{
    string s = f.ReadLine();

    // Запустим таймер
    var watch = Stopwatch.StartNew();

    // Выполним вставку
    testLinkedList.AddLast(s);

    // Сохраним результат
    swRec1.SaveResult(watch.Elapsed.TotalMilliseconds);
}
f.Close();
#endregion

#region Оценка вставки в LinkedList через метод AddBefore:
StopwatchRecording swRec2 = new("Тест 2 - LinkedList - метод AddBefore");

string putString = "Строка для вставки";
LinkedListNode<string> node;

for (node = testLinkedList.Last; node != null; node = node.Previous)
{
    // Запустим таймер
    var watch = Stopwatch.StartNew();

    // Выполним вставку
    testLinkedList.AddBefore(node,putString);

    // Сохраним результат
    swRec2.SaveResult(watch.Elapsed.TotalMilliseconds);

    node = node.Previous; // первое из двух смещений к началу списка
}
#endregion

// Вывод результатов

Console.WriteLine();
swRec1.Show();

Console.WriteLine();
swRec2.Show();

Console.ReadKey();