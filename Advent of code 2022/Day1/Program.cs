
var input = await File.ReadAllLinesAsync("input.txt");

int highest = 0;
int current = 0;

foreach(var line in input)
{

    if (string.IsNullOrWhiteSpace(line))
    {
        if(current > highest)
        {
            highest = current;
        }
        current = 0;
    } else
    {
        current += int.Parse(line);
    }
}

Console.WriteLine($"Highest is: {highest}");

Console.ReadKey();
