public interface ICoordinate
{
    int X { get; }
    int Y { get; }

    void AddX();
    void AddY();
    void SubsX();
    void SubsY();
}