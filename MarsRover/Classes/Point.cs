public class Point : ICoordinate
{
    private int _x { get; set; }
    private int _y { get; set; }
    public int X
    {
        get
        {
            return this._x;
        } 
    }

    public int Y
    {
        get
        {
            return this._y;
        }
    }

    public Point(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public void AddX()
    {
        this._x++;
    }

    public void AddY()
    {
        this._y++;
    }

    public void SubsX()
    {
        this._x--;
    }
    
    public void SubsY()
    {
        this._y--;
    }
}