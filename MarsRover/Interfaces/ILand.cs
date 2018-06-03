public interface ILand
{
    Point CornerPoint { get; }
    bool IsInsideLand(int x, int y);
}