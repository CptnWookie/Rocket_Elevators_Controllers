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

            //Console.WriteLine("COLUMN LIST :");

            for (int i = 0; i < _columnAmount; i++)
            {
                if (i == 0 )
                {
                    Column column = new Column("A", 66, 5, 1, -6, -1);
                    columnList.Add(column);
                    //Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 1)
                {
                    Column column = new Column("B", 66, 5, 1, 2, 20);
                    columnList.Add(column);
                    //Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else if (i == 2)
                {
                    Column column = new Column("C", 66, 5, 1, 21, 40);
                    columnList.Add(column);
                    //Console.WriteLine("Column {0}\n", columnList[i].id);
                }
                else 
                {
                    Column column = new Column("D", 66, 5, 1, 41, 60);
                    columnList.Add(column);
                    //Console.WriteLine("Column {0}\n", columnList[i].id);
                }
            }

            for (int i = 0; i < _floorAmount-1; i++)
            {
                if (i <= 5) 
                {
                    CallButton callButton = new CallButton(i-6, "up");
                    callButtonList.Add(callButton);
                    //Console.WriteLine("Call Button {0}", callButtonList[i].id);
                }
                else if (i >= 6)
                {
                    CallButton callButton = new CallButton(i-4, "down");
                    callButtonList.Add(callButton);
                    //Console.WriteLine("Call Button {0}", callButtonList[i].id);
                }
            }

            for (int i = 0; i < _lobby; i++)
            {
                FloorRequestPanel floorRequestPanel = new FloorRequestPanel(_floorAmount);
                floorRequestPanelList.Add(floorRequestPanel);
                //Console.WriteLine("Lobby Floor Request Panel");
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
                //Console.WriteLine("Elevator {0}{1}", id, elevatorList[i].id);
            }
        }
        //This method represents an elevator request on a floor or basement.
        public void requestElevator(int _requestedFloor, string _currentDirection, int _destinationFloor)
        {
            Console.WriteLine("Elevator requested !\n");
            Console.WriteLine("...Looking for Best Elevator...\n");
            findBestElevator(_requestedFloor, _currentDirection);
            Console.WriteLine("Best Elevator identified : Elevator {0}{1}\n", id, bestElevator.id);
            bestElevator.moveElevator(_requestedFloor);
            Console.WriteLine("Elevator {0} has arrived to Floor {1}\n", id, _requestedFloor);
            bestElevator.doorsStatus("opened");
            Console.WriteLine("Doors are opening...\n");
            Console.WriteLine("User enters the Elevator...\n");
            bestElevator.doorsStatus("closed");
            Console.WriteLine("Doors are closing...\n");
            bestElevator.moveElevator(_destinationFloor);
            Console.WriteLine("Elevator {0} has arrived to Destination : Floor {1}\n", id, _requestedFloor);
            bestElevator.doorsStatus("opened");
            Console.WriteLine("Doors are opening and user exits the Elevator .....\n\n");
        }

        //This method will determine the best elevator to be send for the current request.
        public void findBestElevator(int _requestedFloor, string _currentDirection)
        {
            int distance = 0;
            int bestDistance = 99;
            if (_requestedFloor == 1)
            {   
                for (int i = 0; i < elevatorList.Count; i++)
                {
                    if (_requestedFloor == elevatorList[i].currentFloor && elevatorList[i].currentDirection == "idle")
                    {
                        bestElevator = elevatorList[i];
                    }
                    else if ((elevatorList[i].currentDirection == "up" || elevatorList[i].currentDirection == "idle") && elevatorList[i].currentFloor <= _requestedFloor)
                    {
                        distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevatorList[i];
                        }
                    }
                    else if ((elevatorList[i].currentDirection == "down" || elevatorList[i].currentDirection == "idle") && elevatorList[i].currentFloor >= _requestedFloor)
                    {
                        distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevatorList[i];
                        }
                    }
                }
            }
            else 
            {   
                for (int i = 0; i < elevatorList.Count; i++)
                {
                    if (_currentDirection == "up" && _currentDirection == elevatorList[i].currentDirection && elevatorList[i].currentFloor <= _requestedFloor)
                    {
                        distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevatorList[i];
                        }
                    }
                    else if (_currentDirection == "down" && _currentDirection == elevatorList[i].currentDirection && elevatorList[i].currentFloor >= _requestedFloor)
                    {
                        distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevatorList[i];
                        }
                    }
                    else if (_requestedFloor == elevatorList[i].currentFloor && elevatorList[i].currentDirection == "idle")
                    {
                        distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevator = elevatorList[i];
                        }
                    }
                }
            }
                
                
            /* or (int i = 0; i < elevatorList.Count; i++)
            {   
                int distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);
                    
                if (elevatorList[i].currentDirection == "idle" && bestDistance >= distance)
                    {
                        bestDistance = distance;
                        bestElevator = elevatorList[i];
                        }
                    }
            } 
            if (bestIdle != null)
            {
                bestElevator = bestCase;
            }
            else
            {
                bestElevator = bestIdle;
            } */
        }
    

         //This method will be used for the requests made on the first floor.
        /* public void assignElevator(int _requestedFloor, string _currentdirection, int _destinationFloor)
        {
            Console.WriteLine("Elevator requested at Lobby !\n");
            Console.WriteLine("...Looking for Best Elevator...\n");
            findBestAssignElevator(1, bestElevator.destinationFloor);
            Console.WriteLine("Best Elevator identified : Elevator {0}{1}\n", id, bestElevator.id);
            bestElevator.moveElevator(_requestedFloor);
            Console.WriteLine("Elevator {0} has arrived to Floor {1}\n", id, _requestedFloor);
            bestElevator.doorsStatus("opened");
            Console.WriteLine("Doors are opening...\n");
            Console.WriteLine("User enters the Elevator...\n");
            bestElevator.doorsStatus("closed");
            Console.WriteLine("Doors are closing...\n");
            bestElevator.moveElevator(_destinationFloor);
            Console.WriteLine("Elevator {0} has arrived to Destination : Floor {1}\n", id, _requestedFloor);
            bestElevator.doorsStatus("opened");
            Console.WriteLine("Doors are opening and user exits the Elevator .....\n\n");
        } */

        //This method will determine the best elevator to be send for the current request.
        public void findBestAssignElevator(int _requestedFloor, int _destinationFloor)
        {
            int distance = 0;
            int bestDistance = 99;
            for (int i = 0; i < floorAmount; i++)
            {
                if (_requestedFloor == 1 && elevatorList[i].currentFloor == _requestedFloor && elevatorList[i].currentDirection == "idle")
                {
                    bestElevator = elevatorList[i];
                }
                else if (_requestedFloor == 1 && (elevatorList[i].currentDirection == "up" || elevatorList[i].currentDirection == "idle") && elevatorList[i].currentFloor <= _requestedFloor)
                {
                    distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        bestElevator = elevatorList[i];
                    }
                }
                else if (_requestedFloor == 1 && (elevatorList[i].currentDirection == "down" || elevatorList[i].currentDirection == "idle") && elevatorList[i].currentFloor >= _requestedFloor)
                {
                    distance = Math.Abs(elevatorList[i].currentFloor - _requestedFloor);

                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        bestElevator = elevatorList[i];
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
            Console.WriteLine("\n\n         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ");
            Console.WriteLine("         <<                                      >>           ");
            Console.WriteLine("         <<   COMMERCIAL CONTROLLER TEST ZONE!   >>           ");
            Console.WriteLine("         <<                                      >>           ");
            Console.WriteLine("         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ");
            
            Battery battery = new Battery(4, 66, 5, 1, -6, 66);
        

            // SCENARIO 1
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

            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n                         SCENARIO 1                         \n");
            Console.WriteLine("  - Elevator B1 at 20th floor going to the 5th floor.");
            Console.WriteLine("  - Elevator B2 at 3rd floor going to the 15th floor.");
            Console.WriteLine("  - Elevator B3 at 13th floor going to RC.");
            Console.WriteLine("  - Elevator B4 at 15th floor going to the 2nd floor.");
            Console.WriteLine("  - Elevator B5 at 6th floor going to RC.\n");
            Console.WriteLine("    Someone at RC wants to go to the 20th floor.\n");
            Console.WriteLine("    Elevator B5 is expected to be sent.");
            Console.WriteLine("\n----------------------------------------------------------\n");
            
            battery.columnList[1].requestElevator(1, "up", 20 );
        

            // SCENARIO 2
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

            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n                         SCENARIO 2                         \n");
            Console.WriteLine("  - Elevator C1 at RC going to the 21st floor (not yet departed).");
            Console.WriteLine("  - Elevator C2 at 23rd floor going to the 28th floor.");
            Console.WriteLine("  - Elevator C3 at 33rd floor going to RC.");
            Console.WriteLine("  - Elevator C4 at 40th floor going to the 24th floor.");
            Console.WriteLine("  - Elevator C5 at 39th floor going to RC.\n");
            Console.WriteLine("    Someone at RC wants to go to the 36th floor.\n");
            Console.WriteLine("    Elevator C1 is expected to be sent.");
            Console.WriteLine("\n----------------------------------------------------------\n");
            
            battery.columnList[2].requestElevator(1, "up", 36 );


            // SCENARIO 3
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
            
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n                         SCENARIO 3                         \n");
            Console.WriteLine("  - Elevator D1 at 58th going to RC.");
            Console.WriteLine("  - Elevator D2 at 50th floor going to the 60th floor.");
            Console.WriteLine("  - Elevator D3 at 46th floor going to the 58th floor.");
            Console.WriteLine("  - Elevator D4 at RC going to the 54th floor.");
            Console.WriteLine("  - Elevator D5 at 60th floor going to RC.\n");
            Console.WriteLine("    Someone at 54e floor wants to go to RC.\n");
            Console.WriteLine("    Elevator D1 is expected to be sent.");
            Console.WriteLine("\n----------------------------------------------------------\n");
            
            
            battery.columnList[3].requestElevator(54, "down", 1);


            // SCENARIO 4
            battery.columnList[0].elevatorList[0].currentDirection = "idle";
            battery.columnList[0].elevatorList[0].currentFloor = -4;
            battery.columnList[0].elevatorList[1].currentDirection = "idle";
            battery.columnList[0].elevatorList[1].currentFloor = 1;
            battery.columnList[0].elevatorList[2].currentDirection = "down";
            battery.columnList[0].elevatorList[2].currentFloor = -3;
            battery.columnList[0].elevatorList[3].currentDirection = "up";
            battery.columnList[0].elevatorList[3].currentFloor = -6;
            battery.columnList[0].elevatorList[4].currentDirection = "down";
            battery.columnList[0].elevatorList[4].currentFloor = -1;

            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n                         SCENARIO 4                         \n");
            Console.WriteLine("  - Elevator A1 “Idle” at SS4.");
            Console.WriteLine("  - Elevator A2 “Idle” at RC.");
            Console.WriteLine("  - Elevator A3 at SS3 going to SS5.");
            Console.WriteLine("  - Elevator A4 at SS6 going to RC.");
            Console.WriteLine("  - Elevator A5 at SS1 going to SS6.\n");
            Console.WriteLine("    Someone at SS3 wants to go to RC.\n");
            Console.WriteLine("    Elevator A4 is expected to be sent.");
            Console.WriteLine("\n----------------------------------------------------------\n");
            

            battery.columnList[0].requestElevator(-3, "up", 1);

        }
    }
}    
