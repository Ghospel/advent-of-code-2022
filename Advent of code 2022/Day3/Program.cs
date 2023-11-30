await Part2();

static async Task Part1()
{
    var input = await File.ReadAllLinesAsync("input.txt");

    var items = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var prioritySum = 0;

    foreach (var line in input)
    {
        var firstHalf = line[..(line.Length / 2)];
        var secondHalf = line[(line.Length / 2)..];

        foreach (var item in firstHalf)
        {
            bool hasFoundMatch = false;

            // it also exists in de other compartment.
            if (secondHalf.IndexOf(item) != -1)
            {
                prioritySum += items.IndexOf(item) + 1;
                hasFoundMatch = true;
            }

            if (hasFoundMatch) break;
        }
    }

    Console.WriteLine($"Sum of prios: {prioritySum}");
}

static async Task Part2()
{
    var input = await File.ReadAllLinesAsync("input.txt");
    
    var items = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var prioritySum = 0;

    List<Group> groups = [];
    var group = new Group();

    for (int i = 1; i < input.Length+1; i++)
    {
        group.Elves.Add(new Elf
        {
            Items = input[i-1]
        });

        if(i % 3 == 0)
        {
            groups.Add(group);
            group = new Group();
        }
    }

    prioritySum = groups.Sum(x => items.IndexOf(x.GetBadge())+1);

    Console.WriteLine($"Sum of prios: {prioritySum}");
}
