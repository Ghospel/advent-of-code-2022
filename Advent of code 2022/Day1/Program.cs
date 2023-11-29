
var input = await File.ReadAllLinesAsync("input.txt");

var elves = new List<Elf>();
var elf = new Elf();

foreach(var line in input)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        elves.Add(elf);
        elf = new Elf();
    } else
    {
        elf.Calories.Add(int.Parse(line));
    }
}

var ordered = elves.OrderByDescending(x => x.Calories.Sum()).ToList();

Console.WriteLine($"Sum of highest 3 is: {ordered[0].Calories.Sum() + ordered[1].Calories.Sum() + ordered[2].Calories.Sum()}");

Console.ReadKey();

class Elf
{
    public List<int> Calories { get; set; } = [];
}