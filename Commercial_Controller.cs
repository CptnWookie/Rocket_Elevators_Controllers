using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    public class Commercial_Controller
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Commercial Controller!");
            
            Battery battery = new Battery(4, 66, 5, 1, 66);
        }
    
        public class Battery
        {
            public int columnAmount;
            public int floorAmount;
            public int elevatorAmountPerColumn;
            public int minFloor;
            public int maxFloor;
            public List<Column> columnList = new List<Column>();
            public List<CallButton> floorCallButtonList = new List<CallButton>();
            

            public Battery(int _columnAmount, int _floorAmount, int _elevatorAmountPerColumn, int _minFloor, int _maxfloor)
            {
                columnAmount = _columnAmount;
                floorAmount = _floorAmount;
                elevatorAmountPerColumn = _elevatorAmountPerColumn;
                minFloor = _minFloor;
                maxFloor = _maxfloor;

                Console.WriteLine("COLUMN LIST :");

                for (int i = 0; i < _columnAmount; i++)
                {
                    if (i == 0 )
                    {
                    columnList.Add(new Column("A", 66, 5, 1, 6));
                    Console.WriteLine("Column {0}", columnList[i].id);
                    }
                    else if (i == 1)
                    {
                        columnList.Add(new Column("B", 66, 5, 8, 26));
                        Console.WriteLine("Column {0}", columnList[i].id);
                    }
                    else if (i == 2)
                    {
                        columnList.Add(new Column("C", 66, 5, 27, 46));
                        Console.WriteLine("Column {0}", columnList[i].id);
                    }
                    else 
                    {
                        columnList.Add(new Column("D", 66, 5, 47, 66));
                        Console.WriteLine("Column {0}", columnList[i].id);
                    }
                }
            }
        

        public class Column
        {
            public string id;
            public int floorAmount;
            public int elevatorAmountPerColumn;
            public int minFloor;
            public int maxFloor;
            public List<Elevator> elevatorList = new List<Elevator>();
            //public List<FloorDisplay> floorDisplayList = new List<FloorDisplay>();
            //public Elevator bestElevator = null;

            public Column(string _id, int _floorAmount, int _elevatorAmountPerColumn, int _minFloor, int _maxfloor)
            {
                id = _id;
                floorAmount = _floorAmount;
                elevatorAmountPerColumn = _elevatorAmountPerColumn;


                for (int i = 0; i < elevatorAmountPerColumn; i++)
                {
                    elevatorList.Add(new Elevator(i+1, 1, "idle", "idle", "closed"));
                    Console.WriteLine("Elevator {0}{1}", id, elevatorList[i].id);
                }
            }
        }
        

        public class Elevator
        {
            public int id;
            public int currentFloor;
            public string direction;
            public string status;
            public string doorStatus;


            public Elevator(int _id, int _currentFloor, string _direction, string _status, string _doorStatus)
            {
                id = _id;
                currentFloor = _currentFloor;
                direction = _direction;
                status = _status;
                doorStatus = _doorStatus;
            }
        }

        public class CallButton
        {
            public int id;


            public CallButton(int _id)
            {
                id = _id;
            }
        }

        public class RequestFloorPanel
        {
            public int floorAmount;

            public RequestFloorPanel(int _floorAmount)
            {
                floorAmount = _floorAmount;
            }
        }

    
        }
    }
    
}