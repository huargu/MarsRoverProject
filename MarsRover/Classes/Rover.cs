using System.Collections.Generic;
using MarsRover.Interfaces;

public class Rover : IRover
{
    public Point CurrentPosition { get; set;}
    public Direction FacingDirection { get; private set; }
    public ILand RoverLand { get; private set; }
    private ILogger _logger { get; set; }
    public Rover(ILogger logger)
    {
        this._logger = logger;
    }

    public void Landing(Point initialPoint, Direction initialDirection, ILand roverLand)
    {
        this.CurrentPosition = initialPoint;
        this.FacingDirection = initialDirection;
        this.RoverLand = roverLand;
        _logger.AddLog(string.Format("Landed on: {0} {1}, Facing: {2}", this.CurrentPosition.X, this.CurrentPosition.Y, this.FacingDirection.GetDescription()));
    }

    public void Move(string operations)
    {
        foreach(char c in operations)
        {
            switch(c)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    MoveForward();
                    break;
                default:
                    throw new System.Exception("Unidentified operation!");
            }
        }
    }

    public string GetPosition()
    {
        return string.Format("{0} {1} {2}", CurrentPosition.X.ToString(), CurrentPosition.Y.ToString(), FacingDirection.GetDescription());
    }

    private void TurnLeft()
    {
        _logger.AddLog("turning left");
        if(this.FacingDirection == Direction.North)
            this.FacingDirection = Direction.West;
        else
            this.FacingDirection--;
    }

    private void TurnRight()
    {
        _logger.AddLog("turning right");
        if(this.FacingDirection == Direction.West)
            this.FacingDirection = Direction.North;
        else
            this.FacingDirection++;
    }

    private void MoveForward()
    {
        _logger.AddLog("moving forward");
        switch(this.FacingDirection)
        {
            case Direction.North:
                if (this.RoverLand.IsInsideLand(this.CurrentPosition.X, this.CurrentPosition.Y + 1))
                    this.CurrentPosition.AddY();
                else
                    throw new System.Exception("Land boundaries cannot be exceeded!");
                break;
            case Direction.South:
                if (this.RoverLand.IsInsideLand(this.CurrentPosition.X, this.CurrentPosition.Y - 1))
                    this.CurrentPosition.SubsY();
                else
                    throw new System.Exception("Land boundaries cannot be exceeded!");
                break;
            case Direction.East:
                if (this.RoverLand.IsInsideLand(this.CurrentPosition.X + 1, this.CurrentPosition.Y))
                    this.CurrentPosition.AddX();
                else
                    throw new System.Exception("Land boundaries cannot be exceeded!");
                break;
            case Direction.West:
                if (this.RoverLand.IsInsideLand(this.CurrentPosition.X - 1, this.CurrentPosition.Y))
                    this.CurrentPosition.SubsX();
                else
                    throw new System.Exception("Land boundaries cannot be exceeded!");
                break;
        }
    }
}