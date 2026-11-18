using System.Collections.Generic;

HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };
Console.Write("Введите слово для добавления: ");
string wordAdd = Console.ReadLine() ?? "";
string wordTrim = wordAdd.Trim();
string wordLower = wordTrim.ToLowerInvariant();
if (excludedWords.Add(wordLower))
{
    Console.WriteLine("Исключение добавлено");
}
else
{
    Console.WriteLine("Такое исключение уже есть");
}

Console.Write("Введите слово для удаления: ");
string wordDel = Console.ReadLine() ?? "";
string wordDelTrim = wordDel.Trim();
string wordDelLower = wordDelTrim.ToLowerInvariant();
if (excludedWords.Remove(wordDelLower)) {
    Console.WriteLine("Исключение удалено");
}
else
{
    Console.WriteLine("Такого исключения нет");
}
Console.WriteLine($"Количество исключений: {excludedWords.Count}"); 

Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";
string[] words = text.ToLowerInvariant()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string,int> frequencies = new Dictionary<string,int>();
foreach (string word in words) {
    if (!excludedWords.Contains(word)) {
        AddWord(frequencies, word);;
    }
}

int len = words.Length;
int count = SumFrequencies(frequencies);

Console.WriteLine();
Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine($"Исходная строка: [{text}]");
Console.WriteLine($"Всего слов: {len}");
Console.WriteLine($"Учтено слов: {count}");
Console.WriteLine($"Пропущено слов: {len - count}");
Console.WriteLine($"Разных учтённых слов: {frequencies.Count}");
Console.WriteLine();
Console.WriteLine("Частоты слов:");
PrintFrequencies(frequencies);

Console.WriteLine("Введите слово для поиска: ");
string wordFind = Console.ReadLine() ?? "";
string wordFindTrim = wordFind.Trim().ToLowerInvariant();
if (frequencies.TryGetValue(wordFindTrim, out int found)) {
    Console.WriteLine($"Количество вхождений: {found}");
}
else {
Console.WriteLine("Слово не найдено");
}




void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        sum += entry.Value;
    }

    return sum;
}

void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
    {
        frequencies[word] = count + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}

