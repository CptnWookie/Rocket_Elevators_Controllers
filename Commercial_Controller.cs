using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Controllers
{
    public class Battery
    {
        public int columnAmount;
        public int floorAmount;
        public int elevatorAmountPerColumn;
        public int batteryMinFloor;
        public int batteryMaxFloor;
        public List<FloorGroup> floorGroupList = new List<FloorGroup>();
        public List<Column> columnList  = new List<Column>();
        public List<FloorCallButton> floorCallButtonList = new List<FloorCallButton>();
        public List<BasementCallButton> basementCallButtonList = new List<BasementCallButton>();
        

        public Battery(int _columnAmount, int _floorAmount, int _elevatorAmountPerColumn, int _batteryMinFloor, int _batteryMaxfloor)
        {
            columnAmount = _columnAmount;
            floorAmount = _floorAmount;
            elevatorAmountPerColumn = _elevatorAmountPerColumn;
            batteryMinFloor = _batteryMinFloor;
            batteryMaxFloor = _batteryMaxfloor;
                                
            Console.WriteLine("COLUMN LIST :");
            for (int i = 1; i < _columnAmount; i++)
            {
                columnList.Add(new Column(i+1, _floor, 6, 60, 5));
                Console.WriteLine("Column {0}", columnList[i].id);
            }
        }
    }

    public class Column
    {
        public int id;
        public int floorAmount;
        public int elevatorAmountPerColumn;
        public List<Elevator> elevatorList = new List<Elevator>();
        public List<FloorDisplay> floorDisplayList = new List<FloorDisplay>();
        //public Elevator bestElevator = null;

        public Column(int _id, int _floorAmount, int _elevatorAmountPerColumn)
        {
            id = _id;
            floorAmount = _floorAmount;
            elevatorAmountPerColumn = _elevatorAmountPerColumn;
            

            for (int i = 0; i < elevatorAmountPerColumn; i++)
            {
                elevatorList.Add(new Elevator(i));
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

        
    
    public class Commercial_Controller
    {
        public static void Clear ();
        static void Main(string[] args)
        {
            Console.WriteLine("Commercial Controller!");
            Battery battery = new Battery(4, 6, 60, 4);
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
