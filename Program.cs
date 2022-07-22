using System;
using System.Collections.Generic;

namespace Backend
{
    class Program
    {
        public static Coordinate lastCoord = new Coordinate(100, 100, 100);

        static void Main(string[] args)
        {
            PathCalculator calculator = new PathCalculator();
            

            calculator.setInitialPos(
                            new PositionData(
                                getSatellitePosition(),
                                getRelativeTargetPosition()
                           )
                    );

            while (true)
            {
                calculator.setAfterPos(
                    new PositionData(
                                getSatellitePosition(),
                                getRelativeTargetPosition()
                           ), 1
                    );
                List<Coordinate> path = calculator.calcPath();
                if (path == null) break;
                else
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        Console.WriteLine("t:{0}, x:{1}, y:{2}, z:{3}",i, path[i].item1, path[i].item2, path[i].item3);
                        
                    }
                    Console.WriteLine();
                }
            }

        }
        private static Coordinate getSatellitePosition()
        {
            //float longitude = 100;
            //float latitude = 100;
            //float altitude = 100;
            //return new Coordinate(longitude, latitude, altitude);
            lastCoord = Coordinate.realNumMul(lastCoord, (float)0.9);
            return lastCoord;
        }
        private static Coordinate getRelativeTargetPosition()
        {
            float rho = 10;
            float theta = 10;
            float phi = 10;
            return new Coordinate(rho,theta,phi);
        }
    }
}
