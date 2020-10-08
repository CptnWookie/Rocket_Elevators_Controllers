// Go Lang code for Commercial Controller
package main

import (
	"fmt"
)

// Scenario Zone
func main() {
	fmt.Println("Hello World")

	/* fmt.Println("\n\n         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ");
	fmt.Println("         <<                                      >>           ");
	fmt.Println("         <<   COMMERCIAL CONTROLLER TEST ZONE!   >>           ");
	fmt.Println("         <<                                      >>           ");
	fmt.Println("         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           "); */

	//Battery battery = new Battery(4, 66, 5, 1, -6, 66);

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

// Column ...
type Column struct {
	id                      int
	floorAmount             int
	elevatorAmountPerColumn int
	lobby                   int
	minFloor                int
	maxFloor                int
	bestElevator            int
	elevatorList            []Elevator
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
	id        int
	direction string
}

// FloorRequestPanel ...
type FloorRequestPanel struct {
	floorAmount int
}

// FloorDisplay ...
type FloorDisplay struct {
	floorAmount int
}

// Request ...
type Request struct {
	floorAmount int
}
