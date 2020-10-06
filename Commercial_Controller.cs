using System;
using System.Collections;
using System.Collections.Generic;

    namespace Rocket_Elevators_Controllers
    {
        public class Commercial_Controller
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Commercial Controller!");
                Battery battery = new Battery(4, 6, 66, 4);
                //CallButton callBut = new CallButton(66);    
                
                
            }

            public class Battery
            {
                public int columnAmount;
                public int basementAmount;
                public int floorAmount;
                public int floorGroup;
                public List<Column> columnList  = new List<Column>();
                public List<CallButton> callButtonList = new List<CallButton>();
                public List<FloorGroup> floorGroupList = new List<FloorGroup>();

                
                
                public Battery(int _columnAmount, int _basementAmount, int _floorAmount, int _floorGroup)
                {
                    columnAmount = _columnAmount;
                    basementAmount = _basementAmount;
                    floorAmount = _floorAmount;
                    floorGroup = _floorGroup;
                    
                    Console.WriteLine("COLUMN LIST :");
                    for (int i = 0; i < columnAmount; i++)
                    {
                        columnList.Add(new Column(i+1, _floorAmount, 6, 66, 5));
                        Console.WriteLine("Column {0}", columnList[i].id);
                    }
                    
                    Console.WriteLine("\nBASEMENT CALL BUTTON LIST :");
                    for (int i = 0; i < basementAmount; i++)
                    {
                        callButtonList.Add(new CallButton(i+1));
                        Console.WriteLine("Basement Call Button {0}", callButtonList[i].id);
                    }

                    Console.WriteLine("\nFLOOR CALL BUTTON LIST :");
                    for (int i = 1; i < floorAmount; i++)
                    {
                        callButtonList.Add(new CallButton(i));
                        Console.WriteLine("Floor Call Button {0}", callButtonList[i].id);
                    }

                    Console.WriteLine("\nFLOOR GROUP LIST :");
                    for (int i = 0; i < columnAmount; i++)
                    {
                        floorGroupList.Add(new FloorGroup(i+1));
                        Console.WriteLine("FloorGroup {0}", floorGroupList[i].id);
                    }
                }
            }

            public class Column
            {
                public int id;
                public bool idle;
                public int floorAmount;
                public int minFloor;
                public int maxFloor;
                public int elevatorAmountPerColumn;
                public List<Elevator> elevatorList = new List<Elevator>();
                

                public Column(int _id, int _floorAmount, int _minFloor, int _maxFloor, int _elevatorAmountPerColumn)
                {
                    id = _id;
                    floorAmount = _floorAmount;
                    minFloor = _minFloor;
                    maxFloor = _maxFloor;
                    elevatorAmountPerColumn = _elevatorAmountPerColumn;
                    idle = true;
                    

                    for (int i = 0; i < elevatorAmountPerColumn; i++)
                    {
                        elevatorList.Add(new Elevator(i));
                    }
                }
            }

            public class Elevator
            {
                public int id;


                public Elevator(int _id)
                {
                    id = _id;
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

            public class FloorGroup
            {
                public int id;


                public FloorGroup(int _id)
                {
                    id = _id;
                }
            }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        }
    }
