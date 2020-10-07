using System;
using System.Collections.Generic;

    namespace Rocket_Elevators_Controllers
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Commercial Controller!");
                Battery battery = new Battery(4, 6, 60, 4);
            }

            public class Battery
            {
                public int columnAmount;
                public int basement;
                public int floor;
                public int floorGroup;
                public List<Column> columnList  = new List<Column>();
                public List<FloorCallButton> floorCallButtonList = new List<FloorCallButton>();
                public List<BasementCallButton> basementCallButtonList = new List<BasementCallButton>();
                /* public List<FloorGroup> floorGroupList = new List<FloorGroup>(); */

                
                
                public Battery(int _columnAmount, int _basement, int _floor, int _floorGroup)
                {
                    columnAmount = _columnAmount;
                    basement = _basement;
                    floor = _floor;
                    floorGroup = _floorGroup;
                    
                    Console.WriteLine("COLUMN LIST :");
                    for (int i = 0; i < columnAmount; i++)
                    {
                        columnList.Add(new Column(i+1, _floor, 6, 60, 5));
                        Console.WriteLine("Column {0}", columnList[i].id);
                    }
 
                    Console.WriteLine("\nFLOOR CALL BUTTON LIST :");
                    for (int i = 0; i < floor-1; i++)
                    {                        
                        floorCallButtonList.Add(new FloorCallButton(i+2, "DOWN"));
                        Console.WriteLine("Floor Call Button {0}", floorCallButtonList[i].id);
                    }

                    Console.WriteLine("\nBASEMENT CALL BUTTON LIST :");
                    for (int i = 0; i < basement; i++)
                    {
                        basementCallButtonList.Add(new BasementCallButton(i+1, "UP"));
                        Console.WriteLine("Basement Call Button {0}", basementCallButtonList[i].id);
                    }

                    /* Console.WriteLine("\nFLOOR GROUP LIST :");
                    for (int i = 0; i <= floor; i++)
                    {
                        foreach (var column in columnList)
                        {
                            if (i > 1 && i < 21)
                            {
                            floorGroupList.Add(new FloorGroup(i+1));
                            Console.WriteLine("FloorGroup {0}", floorGroupList[i].id);
                            }
                            if (i >  && i < 21)
                            {
                            floorGroupList.Add(new FloorGroup(i+1));
                            Console.WriteLine("FloorGroup {0}", floorGroupList[i].id);
                            }
                        }
                    } */
                }
            }

            public class Column
            {
                public int id;
                public bool idle;
                public int floor;
                public int minFloor;
                public int maxFloor;
                public int elevatorAmountPerColumn;
                public List<Elevator> elevatorList = new List<Elevator>();
                

                public Column(int _id, int _floor, int _minFloor, int _maxFloor, int _elevatorAmountPerColumn)
                {
                    id = _id;
                    floor = _floor;
                    minFloor = _minFloor;
                    maxFloor = _maxFloor;
                    elevatorAmountPerColumn = _elevatorAmountPerColumn;
                    idle = true;
                    
                    
                    for (int i = 0; i < elevatorAmountPerColumn; i++)
                    {
                        elevatorList.Add(new Elevator(i+1/* , _direction, _status, _floor, _requestedFloor, _doorStatus */));
                        Console.WriteLine("Elevator {0}{1}", id, elevatorList[i].id);
                    }
                }
            }

            public class Elevator
            {
                public int id;
                public string direction;
                public string status;
                public int floor;
                public int requestedFloor;
                public string doorStatus;


                public Elevator(int _id, string _direction, string _status, int _floor, int _requestedFloor, string _doorStatus)
                {
                    id = _id;
                    direction = _direction;
                    status = _status;
                    floor = _floor;
                    requestedFloor = _requestedFloor;
                    doorStatus = _doorStatus;

                }
            }

            public class FloorCallButton
            {
                public int id;
                public string direction;

                public FloorCallButton(int _id, string _direction)
                {
                    id = _id;
                    direction = _direction;
                }
            }

            public class BasementCallButton
            {
                public int id;
                public string direction;

                public BasementCallButton(int _id, string _direction)
                {
                    id = _id;
                    direction = _direction;
                }
            }

            /* public class FloorGroup
            {
                public int id;


                public FloorGroup(int _id)
                {
                    id = _id;
                }
            } */
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        }
        
    }
