using Day2;

var input = await File.ReadAllLinesAsync("input.txt");

var rounds = new List<Round>();

foreach (var line in input)
{
    var chars = line.Split(' ');

    Round round = new()
    {
        OpponentHand = FromInput(chars[0]),
        MyHand = FromInput(chars[1]),
    };

    rounds.Add(round);
}

var totalPoints = rounds.Sum(x => x.GetPoints());

Console.WriteLine($"Total points gained over all rounds: {totalPoints}");

Console.ReadKey();

static Hand FromInput(string input)
{
    // A for rock, B for paper, C for scissors
    // X for rock, Y for paper, Z for scissors

    input = input.Trim();

    return input switch
    {
        "A" or "X" => Hand.Rock,
        "B" or "Y" => Hand.Paper,
        "C" or "Z" => Hand.Scissors,
        _ => throw new ArgumentOutOfRangeException()
    };
}
