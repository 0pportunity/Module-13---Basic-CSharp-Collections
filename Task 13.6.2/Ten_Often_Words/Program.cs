using Ten_Often_Words;

Console.WriteLine("Введите путь до файла с текстом:");
string path = Console.ReadLine();
string text = File.ReadAllText(path);
WordFrequencyCounter wfc = new(text);
wfc.ShowTop(10);
Console.ReadKey();