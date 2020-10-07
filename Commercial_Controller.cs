using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    public class Battery
    {
        public int columnAmount;
        public int floorAmount;
        public int elevatorAmountPerColumn;
        public int minFloor;
        public int maxFloor;

        public List<Column> columnList = new List<Column>();
        public List<CallButton> floorCallButtonList = new List<CallButton>();
        

        public Battery(int _columnAmount, int _floorAmount, int _elevatorAmountPerColumn, int _lobby, int _minFloor, int _maxfloor)
        {
            columnAmount = _columnAmount;
            floorAmount = _floorAmount;
            elevatorAmountPerColumn = _elevatorAmountPerColumn;
            _lobby = 1;
            minFloor = _minFloor;
            maxFloor = _maxfloor;

            Console.WriteLine("COLUMN LIST :");

            for (int i = 0; i < _columnAmount; i++)
            {
                if (i == 0 )
                {
                    Column column = new Column("A", 66, 5, 1, -6, -1);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 1)
                {
                    Column column = new Column("B", 66, 5, 1, 2, 20);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 2)
                {
                    Column column = new Column("C", 66, 5, 1, 21, 40);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else 
                {
                    Column column = new Column("D", 66, 5, 1, 41, 60);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
            }
        }
    
        //public void findBestColumn(
    }


    public class Column
    {
        public string id;
        public int floorAmount;
        public int elevatorAmountPerColumn;
        public int lobby;
        public int minFloor;
        public int maxFloor;
        public List<Elevator> elevatorList = new List<Elevator>();
        //public List<FloorDisplay> floorDisplayList = new List<FloorDisplay>();
        //public Elevator bestElevator = null;

        public Column(string _id, int _floorAmount, int _elevatorAmountPerColumn, int _lobby, int _minFloor, int _maxFloor)
        {
            id = _id;
            floorAmount = _floorAmount;
            elevatorAmountPerColumn = _elevatorAmountPerColumn;
            _lobby = 1;
            minFloor = _minFloor;
            maxFloor = _maxFloor;


            for (int i = 0; i < elevatorAmountPerColumn; i++)
            {
                elevatorList.Add(new Elevator(i+1, 1, "idle", "idle", "closed"));
                Console.WriteLine("Elevator {0}{1}", id, elevatorList[i].id);
            }
        }

        /* public void coveredFloor(int _lobby, int _minFloor, int _maxFloor)
        {
            _lobby = 1
            minFloor = _minFloor;
            maxFloor = _maxFloor;
        } */
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


    public class FloorDisplay
    {
        public int floorAmount;

        public FloorDisplay(int _floorAmount)
        {
            floorAmount = _floorAmount;
        }
    }


    

    public class Commercial_Controller
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Commercial Controller!");
            
            Battery battery = new Battery(4, 66, 5, 1, -6, 66);
        }
    
        
    }
    
}