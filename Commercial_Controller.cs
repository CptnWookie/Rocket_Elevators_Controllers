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
                    CallButton callButton = new CallButton(i-6, "up");
                    callButtonList.Add(callButton);
                    Console.WriteLine("Call Button {0}", callButtonList[i].id);
                }
                else if (i >= 6)
                {
                    CallButton callButton = new CallButton(i-4, "down");
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
        public Elevator bestCase = null;
        public Elevator bestIdle = null;
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

        //This method represents an elevator request on a floor or basement.
        public void requestElevator(int _requestedFloor, string _currentDirection, int _destinationFloor)
        {
            findBestElevator(_requestedFloor, _currentDirection);
            Console.WriteLine("Best Elevator Found : Elevator {0}", id);
            //bestElevator.moveElevator(_requestedFloor);
            //bestElevator.doorsStatus("opened");
            //bestElevator.doorsStatus("closed");
            //bestElevator.moveElevator(_destinationFloor);
            //bestElevator.doorsStatus("opened");
            //bestElevator.doorsStatus("closed");
            
        }





        //This method will be used for the requests made on the first floor.
        public void assignElevator(int _currentFloor, string _direction, int _destinationFloor)
        {

        }

        //This method will determine the best elevator to be send for the current request.
        public void findBestElevator(int _requestedFloor, string _currentDirection)
        {
            int distance = 0;
            int bestDistance = 99;

            if (_requestedFloor == 1)
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (elevator.currentFloor == _requestedFloor && elevator.currentStatus == "idle")
                    {
                        bestCase = elevator;
                    }
                    else if (elevator.currentDirection == "down" && elevator.currentFloor >= _requestedFloor)
                    {
                        distance = Math.Abs(elevator.currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestCase = elevator;
                        }
                    }
                    else if (elevator.currentDirection == "up" && elevator.currentFloor <= _requestedFloor)
                    {
                        distance = Math.Abs(elevator.currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestCase = elevator;
                        }
                    }   
                }

                
            }
            else 
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (elevator.currentFloor == _requestedFloor && elevator.currentStatus == "idle")
                    {
                        bestElevator = elevator;
                    }
                    else if (elevator.currentDirection == "down" && elevator.currentFloor >= _requestedFloor)
                    {
                        distance = Math.Abs(elevator.currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevator;
                        }
                    }
                    else if (elevator.currentDirection == "up" && elevator.currentFloor <= _requestedFloor)
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
        public string currentStatus;
        public string doorStatus;

        //public List<Requests> requestsList = new List<Requests>();


        public Elevator(int _id, int _currentFloor, string _currentDirection, string _currentStatus, string _doorStatus)
        {
            id = _id;
            currentFloor = _currentFloor;
            currentDirection = _currentDirection;
            currentStatus = _currentStatus;
            doorStatus = _doorStatus;
        }

        //This method will move the elevator.
        public void moveElevator(int _destinationFloor)
        {
            currentFloor = _destinationFloor;
        }


        public void doorsStatus(string _doorStatus)
        {
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

            battery.columnList[1].elevatorList[0].currentDirection = "down";
            battery.columnList[1].elevatorList[0].currentFloor = 20;
            battery.columnList[1].elevatorList[1].currentDirection = "up";
            battery.columnList[1].elevatorList[1].currentFloor = 3;
            battery.columnList[1].elevatorList[2].currentDirection = "down";
            battery.columnList[1].elevatorList[2].currentFloor = 13;
            battery.columnList[1].elevatorList[3].currentDirection = "down";
            battery.columnList[1].elevatorList[3].currentFloor = 15;
            battery.columnList[1].elevatorList[4].currentDirection = "down";
            battery.columnList[1].elevatorList[4].currentFloor = 6;
            battery.columnList[1].assignElevator(1, "up", 20 );
        

            // SCENARIO 2
            Console.WriteLine("\n SCENARIO 2 \n");
            battery.columnList[2].elevatorList[0].currentDirection = "idle";
            battery.columnList[2].elevatorList[0].currentFloor = 1;
            battery.columnList[2].elevatorList[1].currentDirection = "up";
            battery.columnList[2].elevatorList[1].currentFloor = 23;
            battery.columnList[2].elevatorList[2].currentDirection = "down";
            battery.columnList[2].elevatorList[2].currentFloor = 33;
            battery.columnList[2].elevatorList[3].currentDirection = "down";
            battery.columnList[2].elevatorList[3].currentFloor = 40;
            battery.columnList[2].elevatorList[4].currentDirection = "down";
            battery.columnList[2].elevatorList[4].currentFloor = 39;
            battery.columnList[2].assignElevator(1, "up", 36 );

            // SCENARIO 3
            Console.WriteLine("\n SCENARIO 3 \n");
            battery.columnList[3].elevatorList[0].currentDirection = "down";
            battery.columnList[3].elevatorList[0].currentFloor = 58;
            battery.columnList[3].elevatorList[1].currentDirection = "up";
            battery.columnList[3].elevatorList[1].currentFloor = 50;
            battery.columnList[3].elevatorList[2].currentDirection = "up";
            battery.columnList[3].elevatorList[2].currentFloor = 46;
            battery.columnList[3].elevatorList[3].currentDirection = "up";
            battery.columnList[3].elevatorList[3].currentFloor = 1;
            battery.columnList[3].elevatorList[4].currentDirection = "down";
            battery.columnList[3].elevatorList[4].currentFloor = 60;
            battery.columnList[3].requestElevator(54, "down", 1 );

            // SCENARIO 4
            Console.WriteLine("\n SCENARIO 4 \n");
            battery.columnList[0].elevatorList[0].currentDirection = "idle";
            battery.columnList[0].elevatorList[0].currentFloor = -4;
            battery.columnList[0].elevatorList[1].currentDirection = "idle";
            battery.columnList[0].elevatorList[1].currentFloor = 1;
            battery.columnList[0].elevatorList[2].currentDirection = "idle";
            battery.columnList[0].elevatorList[2].currentFloor = -3;
            battery.columnList[0].elevatorList[3].currentDirection = "up";
            battery.columnList[0].elevatorList[3].currentFloor = -6;
            battery.columnList[0].elevatorList[4].currentDirection = "down";
            battery.columnList[0].elevatorList[4].currentFloor = -1;
            battery.columnList[0].requestElevator(-3, "up", 1 );

        }
    
        
    }
    
}