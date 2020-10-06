using System;
using System.Collections.Generic;

    namespace Rocket_Elevators_Controllers
    {
        class Commercial_Controller
        {
            static void Main(string[] args)
            {
                Battery bat = new Battery(4, 66, 4);
                CallButton callBut = new CallButton(66);

                foreach (Column column in bat.columnList)
                {
                    Console.WriteLine("Column" + column.id);
                }

                /* for (int i = 0; i < bat.columnList.Count; i++)
                {
                    Console.WriteLine("iteration {0}, element id {1}", i, bat.columnList[i].id);
                } */

                Console.WriteLine("Commercial Controller!");
                //Console.ReadKey();
            }

            class Battery
            {
                public int columnAmount;
                public int floorAmount;
                public int floorGroup;
                public List<Column> columnList  = new List<Column>();
                public List<CallButton> callButtonList = new List<CallButton>();
                public List<FloorGroup> floorGroupList = new List<FloorGroup>();

                
                
                public Battery(int _columnAmount, int _floorAmount, int _floorGroup)
                {
                    columnAmount = _columnAmount;
                    floorAmount = _floorAmount;
                    floorGroup = _floorGroup;
                    
                    
                    for (int i = 0; i < columnAmount; i++)
                    {
                        columnList.Add(new Column(i));
                        Console.WriteLine("columnList");
                    }

                    for (int i = 0; i < floorAmount; i++)
                    {
                        callButtonList.Add(new CallButton(i));
                        Console.WriteLine("callButtonList");
                    }

                    for (int i = 0; i < columnAmount; i++)
                    {
                        floorGroupList.Add(new FloorGroup(i));
                        Console.WriteLine("floorGroupList");
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
