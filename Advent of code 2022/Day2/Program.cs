using Day2;

var input = await File.ReadAllLinesAsync("input.txt");

var rounds = new List<Round>();

foreach (var line in input)
{
    var chars = line.Split(' ');
    var opponentHand = FromInput(chars[0]);

    Round round = new()
    {
        OpponentHand = opponentHand,

        // X for lose, Y for draw, Z for win
        MyHand = chars[1] switch
        {
            "X" when opponentHand is Hand.Scissors => Hand.Paper,
            "X" when opponentHand is Hand.Rock => Hand.Scissors,
            "X" when opponentHand is Hand.Paper => Hand.Rock,

            "Y" when opponentHand is Hand.Scissors => Hand.Scissors,
            "Y" when opponentHand is Hand.Rock => Hand.Rock,
            "Y" when opponentHand is Hand.Paper => Hand.Paper,

            "Z" when opponentHand is Hand.Scissors => Hand.Rock,
            "Z" when opponentHand is Hand.Rock => Hand.Paper,
            "Z" when opponentHand is Hand.Paper => Hand.Scissors,

            _ => throw new ArgumentOutOfRangeException()
        }
    };

    rounds.Add(round);
}

var totalPoints = rounds.Sum(x => x.GetPoints());

Console.WriteLine($"Total points gained over all rounds: {totalPoints}");

Console.ReadKey();

static Hand FromInput(string input)
{
    // A for rock, B for paper, C for scissors


    input = input.Trim();

    return input switch
    {
        "A" => Hand.Rock,
        "B" => Hand.Paper,
        "C" => Hand.Scissors,
        _ => throw new ArgumentOutOfRangeException()
    };
}
