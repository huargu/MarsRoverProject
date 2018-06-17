using System.Collections.Generic;
using MarsRover.Interfaces;

public interface IRover
{
    Point CurrentPosition { get; }
    Direction FacingDirection { get; }
    ILand RoverLand { get; }
    void Landing(Point initialPoint, Direction initialDirection, ILand roverLand);
    void Move(string operations);
    string GetPosition();
}