namespace Day2;

public class Round
{
    public Hand MyHand { get; set; }
    public Hand OpponentHand { get; set; }

    private Result GetResult()
    {
        return MyHand switch
        {
            Hand.Rock when OpponentHand == Hand.Rock => Result.Draw,
            Hand.Rock when OpponentHand == Hand.Paper => Result.Lost,
            Hand.Rock when OpponentHand == Hand.Scissors => Result.Won,

            Hand.Paper when OpponentHand == Hand.Rock => Result.Won,
            Hand.Paper when OpponentHand == Hand.Paper => Result.Draw,
            Hand.Paper when OpponentHand == Hand.Scissors => Result.Lost,

            Hand.Scissors when OpponentHand == Hand.Rock => Result.Lost,
            Hand.Scissors when OpponentHand == Hand.Paper => Result.Won,
            Hand.Scissors when OpponentHand == Hand.Scissors => Result.Draw,

            _ => throw new InvalidOperationException()
        };
    }

    public int GetPoints()
    {
        var shapePoints = (int)MyHand;
        var roundResultPoints = (int)GetResult();

        return shapePoints + roundResultPoints;
    }
}
