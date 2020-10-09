// Go Lang code for Commercial Controller
package main

import (
	"fmt"
)

// Scenario Zone
func main() {
	fmt.Println("Hello World")
	battery := Battery{}
	battery.initBattery(4, 66, 5, 1, -6, 66)
	/* battery.columnList[0].initColumn("A", 66, 5, 1, -6, -1)
	battery.columnList[1].initColumn("B", 66, 5, 1, 2, 20)
	battery.columnList[2].initColumn("C", 66, 5, 1, 21, 40)
	battery.columnList[3].initColumn("D", 66, 5, 1, 41, 60) */

	fmt.Println(battery)

	/* fmt.Println("\n\n         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ");
	fmt.Println("         <<                                      >>           ");
	fmt.Println("         <<   COMMERCIAL CONTROLLER TEST ZONE!   >>           ");
	fmt.Println("         <<                                      >>           ");
	fmt.Println("         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           "); */

	

	// SCENARIO 1
	/* battery.columnList[1].elevatorList[0].currentDirection = "down";
	battery.columnList[1].elevatorList[0].currentFloor = 20;
	battery.columnList[1].elevatorList[1].currentDirection = "up";
	battery.columnList[1].elevatorList[1].currentFloor = 3;
	battery.columnList[1].elevatorList[2].currentDirection = "down";
	battery.columnList[1].elevatorList[2].currentFloor = 13;
	battery.columnList[1].elevatorList[3].currentDirection = "down";
	battery.columnList[1].elevatorList[3].currentFloor = 15;
	battery.columnList[1].elevatorList[4].currentDirection = "down";
	battery.columnList[1].elevatorList[4].currentFloor = 6; */

	/* fmt.Println("\n----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("\n                         SCENARIO 1                         \n");
	fmt.Println("  - Elevator B1 at 20th floor going to the 5th floor.");
	fmt.Println("  - Elevator B2 at 3rd floor going to the 15th floor.");
	fmt.Println("  - Elevator B3 at 13th floor going to RC.");
	fmt.Println("  - Elevator B4 at 15th floor going to the 2nd floor.");
	fmt.Println("  - Elevator B5 at 6th floor going to RC.\n");
	fmt.Println("    Someone at RC wants to go to the 20th floor.\n");
	fmt.Println("    Elevator B5 is expected to be sent.");
	fmt.Println("\n----------------------------------------------------------\n"); */

	//battery.findBestColumn(1, "up", 20);

	// SCENARIO 2
	/* battery.columnList[2].elevatorList[0].currentDirection = "up";
	battery.columnList[2].elevatorList[0].currentFloor = 1;
	battery.columnList[2].elevatorList[1].currentDirection = "up";
	battery.columnList[2].elevatorList[1].currentFloor = 23;
	battery.columnList[2].elevatorList[2].currentDirection = "down";
	battery.columnList[2].elevatorList[2].currentFloor = 33;
	battery.columnList[2].elevatorList[3].currentDirection = "down";
	battery.columnList[2].elevatorList[3].currentFloor = 40;
	battery.columnList[2].elevatorList[4].currentDirection = "down";
	battery.columnList[2].elevatorList[4].currentFloor = 39; */

	/* fmt.Println("\n----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("\n                         SCENARIO 2                         \n");
	fmt.Println("  - Elevator C1 at RC going to the 21st floor (not yet departed).");
	fmt.Println("  - Elevator C2 at 23rd floor going to the 28th floor.");
	fmt.Println("  - Elevator C3 at 33rd floor going to RC.");
	fmt.Println("  - Elevator C4 at 40th floor going to the 24th floor.");
	fmt.Println("  - Elevator C5 at 39th floor going to RC.\n");
	fmt.Println("    Someone at RC wants to go to the 36th floor.\n");
	fmt.Println("    Elevator C1 is expected to be sent.");
	fmt.Println("\n----------------------------------------------------------\n"); */

	//battery.findBestColumn(1, "up", 36 );

	// SCENARIO 3
	/* battery.columnList[3].elevatorList[0].currentDirection = "down";
	battery.columnList[3].elevatorList[0].currentFloor = 58;
	battery.columnList[3].elevatorList[1].currentDirection = "up";
	battery.columnList[3].elevatorList[1].currentFloor = 50;
	battery.columnList[3].elevatorList[2].currentDirection = "up";
	battery.columnList[3].elevatorList[2].currentFloor = 46;
	battery.columnList[3].elevatorList[3].currentDirection = "up";
	battery.columnList[3].elevatorList[3].currentFloor = 1;
	battery.columnList[3].elevatorList[4].currentDirection = "down";
	battery.columnList[3].elevatorList[4].currentFloor = 60; */

	/* fmt.Println("\n----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("\n                         SCENARIO 3                         \n");
	fmt.Println("  - Elevator D1 at 58th going to RC.");
	fmt.Println("  - Elevator D2 at 50th floor going to the 60th floor.");
	fmt.Println("  - Elevator D3 at 46th floor going to the 58th floor.");
	fmt.Println("  - Elevator D4 at RC going to the 54th floor.");
	fmt.Println("  - Elevator D5 at 60th floor going to RC.\n");
	fmt.Println("    Someone at 54e floor wants to go to RC.\n");
	fmt.Println("    Elevator D1 is expected to be sent.");
	fmt.Println("\n----------------------------------------------------------\n"); */

	//battery.findBestColumn(54, "down", 1);

	// SCENARIO 4
	/* battery.columnList[0].elevatorList[0].currentDirection = "idle";
	battery.columnList[0].elevatorList[0].currentFloor = -4;
	battery.columnList[0].elevatorList[1].currentDirection = "idle";
	battery.columnList[0].elevatorList[1].currentFloor = 1;
	battery.columnList[0].elevatorList[2].currentDirection = "down";
	battery.columnList[0].elevatorList[2].currentFloor = -3;
	battery.columnList[0].elevatorList[3].currentDirection = "up";
	battery.columnList[0].elevatorList[3].currentFloor = -6;
	battery.columnList[0].elevatorList[4].currentDirection = "down";
	battery.columnList[0].elevatorList[4].currentFloor = -1; */

	/* fmt.Println("\n----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("\n                         SCENARIO 4                         \n");
	fmt.Println("  - Elevator A1 “Idle” at SS4.");
	fmt.Println("  - Elevator A2 “Idle” at RC.");
	fmt.Println("  - Elevator A3 at SS3 going to SS5.");
	fmt.Println("  - Elevator A4 at SS6 going to RC.");
	fmt.Println("  - Elevator A5 at SS1 going to SS6.\n");
	fmt.Println("    Someone at SS3 wants to go to RC.\n");
	fmt.Println("    Elevator A4 is expected to be sent.");
	fmt.Println("\n----------------------------------------------------------\n"); */

	//battery.findBestColumn(-3, "up", 1);
}

// Battery ...
type Battery struct {
	columnAmount            int
	floorAmount             int
	elevatorAmountPerColumn int
	minFloor                int
	maxFloor                int
	bestColumn              int
	columnList              []Column
	callButtonList          []CallButton
	floorRequestPanelList   []FloorRequestPanel
}

// Initiating Battery ...
func (b *Battery) initBattery(_columnAmount int, _floorAmount int, _elevatorAmountPerColumn int, _lobby int, _minFloor int, _maxfloor int){
		
		//Initiating Column List ...
		for i := 0; i < _columnAmount; i++ {
			//b.columnList = append(b.columnList, Column{})
			//b.columnList[i].initColumn(_id, _floorAmount, _elevatorAmountPerColumn, _lobby, _minFloor, _maxFloor)
			
			if i == 0 {
				b.columnList = append(b.columnList, Column{})
				b.columnList[i].initColumn("A", 66, 5, 1, -6, -1)
			} else if i == 1 {
				b.columnList = append(b.columnList, Column{})
				b.columnList[i].initColumn("B", 66, 5, 1, 2, 20)
			} else if i == 1 {
				b.columnList = append(b.columnList, Column{})
				b.columnList[i].initColumn("C", 66, 5, 1, 21, 40)
			} else {
				b.columnList = append(b.columnList, Column{})
				b.columnList[i].initColumn("D", 66, 5, 1, 41, 60)
			}
		}


		// Initiating Call Button List ...
		for i := 0; i < _floorAmount; i++ {
			if i <= 5 {
				b.callButtonList = append(b.callButtonList, CallButton{i-6, "up"})
			} else if i < _floorAmount-1 {
				b.callButtonList = append(b.callButtonList, CallButton{i-4, "down"})
			}
		}


		/* // Initiating Lobby ...
		for i := 0; i < _lobby; i++ {
			b.floorRequestPanelList = append(b.floorRequestPanelList, FloorRequestPanel{})
			b.floorRequestPanelList[i].initFloorRequestPanel(_floorAmount)
		} */
}

// Find the Best Column based on the requested floor
func (b *Battery) findBestColumn(_requestedFloor int, _currentDirection string, _destinationFloor int) {
	for i := 0; i < len(b.columnList); i++ {
		if _requestedFloor == 1 {
			if _destinationFloor >= b.columnList[i].minFloor && _destinationFloor <= b.columnList[i].maxFloor	{
				fmt.Println("The selected column is \n", b.columnList[i].minFloor);
				b.columnList[i].assignElevator(_requestedFloor, _currentDirection, _destinationFloor);
			}
		} else {
			if (_requestedFloor >= b.columnList[i].minFloor && _requestedFloor <= b.columnList[i].minFloor)	{
				b.columnList[i].requestElevator(_requestedFloor, _currentDirection, _destinationFloor);
			}
		}
	}
}


// Column ...
type Column struct {
	id                      string
	floorAmount             int
	elevatorAmountPerColumn int
	lobby                   int
	minFloor                int
	maxFloor                int
	bestElevator            int
	elevatorList            []Elevator
}

// Initiating Column ...
func (c *Column) initColumn(_id string, _floorAmount int, _elevatorAmountPerColumn int, _lobby int, _minFloor int, _maxFloor int){
		c.id = _id
		fmt.Println("This is a Column")
}

// This Function returns the best Elevator based on either requestElevator or assignElevator
func (c *Column) prints(_requestedFloor int, _currentDirection string, _destinationFloor int) {
	fmt.Println("Best Elevator identified : Elevator {0}{1}\n", id, bestElevator.id)

}

//This method represents an elevator request on a floor or basement.
func (c *Column) requestElevator(_requestedFloor int, _currentDirection string, _destinationFloor int) {
	c.findBestElevatorFloor(_requestedFloor, _currentDirection, _destinationFloor);
	c.prints(_requestedFloor, _currentDirection, _destinationFloor);
	fmt.Println("...Looking for Best Elevator...\n");
	
	
}

// lobby
func (c *Column) assignElevator(_requestedFloor int, _currentDirection string, _destinationFloor int) {
	c.findBestElevatorLobby(_requestedFloor, _currentDirection, _destinationFloor);
	c.prints(_requestedFloor, _currentDirection, _destinationFloor);
	fmt.Println("...Looking for Best Elevator...\n");
}


// Elevator ...
type Elevator struct {
	id               int
	currentFloor     int
	currentDirection string
	destinationFloor int
	currentStatus    string
	doorStatus       string
	request          int
}

// CallButton ...
type CallButton struct {
	id int
	currentDirection string
}

// Initiating Call Button ...
func (c *Column) initCallButton(_id int, _currentFloor int, _currentDirection string, destinationFloor int, _currentStatus string, _doorStatus string, _request int) {
	
	fmt.Println("This is a Call Button")
}
// FloorRequestPanel ...
type FloorRequestPanel struct {
	floorAmount int
}

// Initiation Floor Request Panel ...
func (b *Battery) initFloorRequestPanelList(_floorAmount int) {
	fmt.Println("This is a Floor Request Panel")
}


// FloorDisplay ...
type FloorDisplay struct {
	floorAmount int
}

// Request ...
type Request struct {
	floorAmount int
}
