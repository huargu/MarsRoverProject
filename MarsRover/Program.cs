using System;
using MarsRover.Classes;

namespace mars_rover_project
{
    class Program
    {
        static void Main(string[] args)
        {            
            Direction startDirection = Direction.South;

            Console.WriteLine("Enter max point of plateau:");
            string maxPoint = Console.ReadLine();
            string[] maxCoordinates = maxPoint.Split(' ');

            int maxX = Convert.ToInt32(maxCoordinates[0]);
            int maxY = Convert.ToInt32(maxCoordinates[1]);
            Plateau plateau = new Plateau(new Point(maxX, maxY));

            while(true)
            {
                Console.WriteLine("Enter landing point of rover:");
                string startingPoint = Console.ReadLine();

                string[] startCoordinates = startingPoint.Split(' ');
                int startX = Convert.ToInt32(startCoordinates[0]);
                int startY = Convert.ToInt32(startCoordinates[1]);
                startDirection = (Direction)startDirection.ParseByDescription(startCoordinates[2]);
                
                Rover vehicle = new Rover(new FileLogger("log.txt"));
                vehicle.Landing(new Point(startX, startY), startDirection, plateau);

                Console.WriteLine("Enter operations for rover:");
                string operations = Console.ReadLine();
                
                vehicle.Move(operations);
                
                Console.WriteLine(vehicle.GetPosition());

                string yesorno = "z";

                while(!yesorno.ToLower().Equals("n") && !yesorno.ToLower().Equals("y"))
                {
                    Console.WriteLine("Do you want to continue? (Y/N)");
                    yesorno = Console.ReadLine();
                }
                if (yesorno.ToLower().Equals("n"))
                    break;
            }
        }
    }
}
