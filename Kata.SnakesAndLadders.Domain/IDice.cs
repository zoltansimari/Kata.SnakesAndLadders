namespace Kata.SnakesAndLadders.Domain
{
    public interface IDice
    {
        int? LastNumber { get; }

        int Roll();
    }
}