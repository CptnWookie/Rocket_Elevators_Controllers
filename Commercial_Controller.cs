using System;
using System.Collections.Generic;

    namespace Rocket_Elevators_Controllers
    {
        class Commercial_Controller
        {
            static void Main(string[] args)
            {
                Battery bat = new Battery(4, 66, 3);

                foreach (Column col in bat.columnList)
                {
                    Console.WriteLine("Column" + col.id);
                }

                /* for (int i = 0; i < bat.columnList.Count; i++)
                {
                    Console.WriteLine("iteration {0}, element id {1}", i, bat.columnList[i].id);
                } */

                Console.WriteLine("Commercial Controller!");
                Console.ReadKey();
            }

            class Battery
            {
                public int columnAmount;
                public int floorAmount;
                public int floorGroup;
                public int elevatorAmountPerColumn;
                public string direction;
                public List<Column> columnList  = new List<Column>();
                public List<CallButton> callButtonList = new List<CallButton>();
                public List<FloorGroup> floorGroupList = new List<FloorGroup>();

                
                public Battery(int _columnAmount, int _floorAmount, int _elevatorAmountPerColumn)
                {
                    columnAmount = _columnAmount;
                    floorAmount = _floorAmount;
                    elevatorAmountPerColumn = _elevatorAmountPerColumn;

                    for (int i = 1; i <= columnAmount; i++)
                    {
                        columnList.Add(new Column(i));
                        
                    }
                }
            }

            class Column
            {
                public int id;
                

                public Column(int _id)
                {
                    id = _id;
                }

            }

            class Elevator
            {
                
            }

            class CallButton
            {

            }

            class FloorGroup
            {

            }
        }
    }
