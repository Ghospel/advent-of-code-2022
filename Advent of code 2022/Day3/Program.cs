var input = await File.ReadAllLinesAsync("input.txt");

var items = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

var prioritySum = 0;

foreach (var line in input)
{
    var firstHalf = line[..(line.Length/2)];
    var secondHalf = line[(line.Length / 2)..];

    foreach(var item in firstHalf)
    {
        bool hasFoundMatch = false;

        // it also exists in de other compartment.
        if(secondHalf.IndexOf(item) != -1)
        {
            prioritySum += items.IndexOf(item) + 1;
            hasFoundMatch = true;
        }

        if (hasFoundMatch) break;
    }
}


Console.WriteLine($"Sum of prios: {prioritySum}");