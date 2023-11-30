class Group
{
    public List<Elf> Elves { get; set; } = [];

    public char GetBadge()
    {
        return Elves[0].Items
            .Intersect(Elves[1].Items)
            .Intersect(Elves[2].Items)
            .FirstOrDefault();
    }
}
