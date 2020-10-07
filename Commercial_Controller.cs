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
        public Column bestColumn = null;

        public List<Column> columnList = new List<Column>();
        public List<CallButton> callButtonList = new List<CallButton>();
        public List<FloorRequestPanel> floorRequestPanelList = new List<FloorRequestPanel>();
        

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
                    columnList.Add(column);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 1)
                {
                    Column column = new Column("B", 66, 5, 1, 2, 20);
                    columnList.Add(column);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 2)
                {
                    Column column = new Column("C", 66, 5, 1, 21, 40);
                    columnList.Add(column);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else 
                {
                    Column column = new Column("D", 66, 5, 1, 41, 60);
                    columnList.Add(column);
                    Console.WriteLine("Column {0}\n", columnList[i].id);
                }
            }

            for (int i = 0; i < _floorAmount-1; i++)
            {
                if (i <= 5) 
                {
                    CallButton callButton = new CallButton(i-6);
                    callButtonList.Add(callButton);
                    Console.WriteLine("Call Button {0}", callButtonList[i].id);
                }
                else if (i >= 6)
                {
                    CallButton callButton = new CallButton(i-4);
                    callButtonList.Add(callButton);
                    Console.WriteLine("Call Button {0}", callButtonList[i].id);
                }
            }

            for (int i = 0; i < _lobby; i++)
            {
                FloorRequestPanel floorRequestPanel = new FloorRequestPanel(_floorAmount);
                floorRequestPanelList.Add(floorRequestPanel);
                Console.WriteLine("Lobby Floor Request Panel");
            }
        }
    
        //This method represents an elevator request on a floor or basement.
        public void requestElevator()
        {

        }





        //This method will be used for the requests made on the first floor.
        public void assignElevator()
        {

        }




        //This method will determine the best column to be send for the current request.
        public void findBestColumn(int _floorAmount, int _minFloor, int _maxFloor)
        {
            int requestedFloor = floorRequestPanelList[0].floorAmount;
            for (int i = 0; i < requestedFloor; i++)
            {
                if (requestedFloor >= columnList[i].minFloor && requestedFloor <= columnList[i].maxFloor)
                {
                    var bestColumn = columnList[i].id;
                }
            }
        }
    }


    public class Column
    {
        public string id;
        public int floorAmount;
        public int elevatorAmountPerColumn;
        public int lobby;
        public int minFloor;
        public int maxFloor;
        public Elevator bestElevator = null;

        public List<Elevator> elevatorList = new List<Elevator>();
        
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
                Elevator elevator = new Elevator(i+1, 1, "idle", "idle", "closed");
                elevatorList.Add(elevator);
                Console.WriteLine("Elevator {0}{1}", id, elevatorList[i].id);
            }
        }


        //This method will determine the best elevator to be send for the current request.
        public void findBestElevator(int _requestedFloor, int _currentFloor, string _direction)
        {
            int distance = 0;
            int bestDistance = 99;

            if (_requestedFloor == 1)
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (_currentFloor == _requestedFloor && _currentStatus == "idle")
                    {
                        distance = Math.Abs(elevator.currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevator;
                        }
                    }
                }
            }
        }
    }
    

    public class Elevator
    {
        public int id;
        public int currentFloor;
        public string currentDirection;
        public string status;
        public string doorStatus;


        public Elevator(int _id, int _currentFloor, string _currentDirection, string _currentStatus, string _doorStatus)
        {
            id = _id;
            currentFloor = _currentFloor;
            currentDirection = _currentDirection;
            status = _currentStatus;
            doorStatus = _doorStatus;
        }
    }

    public class CallButton
    {
        public int id;
        public string direction;


        public CallButton(int _id, string _direction)
        {
            id = _id;
            direction = _direction;
        }
    }

    public class FloorRequestPanel
    {
        public int floorAmount;

        public FloorRequestPanel(int _floorAmount)
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
        
        // SCENARIO 1
            Console.WriteLine("\n SCENARIO 1 \n");

            battery.columnList[1].elevatorList[0].direction = "down";
            battery.columnList[1].elevatorList[0].currentFloor = 20;

            battery.columnList[1].elevatorList[1].direction = "up";
            battery.columnList[1].elevatorList[1].currentFloor = 3;

            battery.columnList[1].elevatorList[2].direction = "down";
            battery.columnList[1].elevatorList[2].currentFloor = 13;

            battery.columnList[1].elevatorList[3].direction = "down";
            battery.columnList[1].elevatorList[3].currentFloor = 15;

            battery.columnList[1].elevatorList[4].direction = "down";
            battery.columnList[1].elevatorList[4].currentFloor = 6;
             
            //battery.columnList[1].requestElevator(1, "up", 20 );
        
        }
    
        
    }
    
}