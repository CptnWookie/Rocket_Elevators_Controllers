// ****************************************************************************************** \\
// * Project           : Rocket Elevators Inc. - Commercial Division						* \\
// *																						* \\
// * Program name      : Commercial_Controller.go											* \\
// *																						* \\
// * Author            : Alexandre Leblanc													* \\
// *																						* \\
// * Date created      : 20100816															* \\
// *																						* \\
// * Purpose           : Code for Commercial products and Solutions							* \\
// *																						* \\
// ****************************************************************************************** \\

package main

import (
	"fmt"
)

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
func (b *Battery) initBattery(columnAmount int, floorAmount int, elevatorAmountPerColumn int, lobby int, minFloor int, maxfloor int) {

	//Initiating Column List ...
	for i := 0; i < columnAmount; i++ {
		//b.columnList = append(b.columnList, Column{})
		//b.columnList[i].initColumn(id, floorAmount, elevatorAmountPerColumn, lobby, minFloor, maxfloor)

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
		fmt.Println("This is a Column")
	}

	// Initiating Call Button List ...
	for i := 0; i < floorAmount; i++ {
		if i <= 5 {
			b.callButtonList = append(b.callButtonList, CallButton{i - 6, "up"})
		} else if i < floorAmount-1 {
			b.callButtonList = append(b.callButtonList, CallButton{i - 4, "down"})
		}
	}

	/* // Initiating Lobby ...
	for i := 0; i < lobby; i++ {
		b.floorRequestPanelList = append(b.floorRequestPanelList, FloorRequestPanel{})
		b.floorRequestPanelList[i].initFloorRequestPanel(floorAmount)
	} */
}

// Find the Best Column based on the requested floor
func (b *Battery) findBestColumn(requestedFloor int, currentDirection string, destinationFloor int) {
	for i := 0; i < len(b.columnList); i++ {
		if requestedFloor == 1 {
			if destinationFloor >= b.columnList[i].minFloor && destinationFloor <= b.columnList[i].maxFloor {
				fmt.Println("The selected column is ", b.columnList[i].minFloor)
				b.columnList[i].assignElevator(requestedFloor, currentDirection, destinationFloor)
			}
		} else {
			if requestedFloor >= b.columnList[i].minFloor && requestedFloor <= b.columnList[i].minFloor {
				b.columnList[i].requestElevator(requestedFloor, currentDirection, destinationFloor)
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
	bestElevator            Elevator
	elevatorList            []Elevator
}

// Initiating Column ...
func (c *Column) initColumn(id string, floorAmount int, elevatorAmountPerColumn int, lobby int, minFloor int, maxFloor int) {
	c.id = id
	c.bestElevator = Elevator{}

	// Creating Elevator List ...
	for i := 0; i < elevatorAmountPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1, 1, "idle", 1, "idle", "closed"})
	}
	fmt.Println("This is an Elevator")
}

// This Function returns the best Elevator based on either requestElevator or assignElevator
func (c *Column) bestOfBest(requestedFloor int, currentDirection string, destinationFloor int) {
	fmt.Println("Best Elevator identified : Elevator")
	c.bestElevator.moveElevator(_currentFloor)
}

//This function represents an elevator request on a floor or basement.
func (c *Column) requestElevator(requestedFloor int, currentDirection string, destinationFloor int) {
	c.findBestElevatorFloor(requestedFloor, currentDirection, destinationFloor)
	c.bestOfBest(requestedFloor, currentDirection, destinationFloor)
	fmt.Println("...Looking for Best Elevator...")

}

// This function returns the Best Elevator for a request made on a floor or basement.
func (c *Column) findBestElevatorFloor(requestedFloor int, currentDirection string, destinationFloor int) {
	distance := 0
	bestDistance := 99
	for i := 0; i < len(c.elevatorList); i++ {
		if currentDirection == "up" && currentDirection == c.elevatorList[i].currentDirection && c.elevatorList[i].currentFloor <= requestedFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor
			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if currentDirection == "down" && currentDirection == c.elevatorList[i].currentDirection && c.elevatorList[i].currentFloor >= requestedFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor
			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if requestedFloor == c.elevatorList[i].currentFloor && c.elevatorList[i].currentDirection == "idle" {
			distance = c.elevatorList[i].currentFloor - requestedFloor
			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		}
	}
	//c.bestElevator.requestList = append(c.bestElevator.requestList, Request{requestedFloor})
	//c.bestElevator.requestList = append(c.bestElevator.requestList, Request{destinationFloor})
}

// Elevator Request from the Lobby
func (c *Column) assignElevator(requestedFloor int, currentDirection string, destinationFloor int) {
	c.findBestElevatorLobby(requestedFloor, currentDirection, destinationFloor)
	c.bestOfBest(requestedFloor, currentDirection, destinationFloor)
	fmt.Println("...Looking for Best Elevator...")
}

func (c *Column) findBestElevatorLobby(requestedFloor int, currentDirection string, destinationFloor int) {
	distance := 0
	bestDistance := 99
	for i := 0; i < len(c.elevatorList); i++ {

		if currentDirection == "up" && currentDirection == c.elevatorList[i].currentDirection && c.elevatorList[i].destinationFloor >= destinationFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor

			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if currentDirection == "up" && currentDirection == c.elevatorList[i].currentDirection && c.elevatorList[i].destinationFloor >= destinationFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor

			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		}

		if (c.elevatorList[i].currentDirection == "up" || c.elevatorList[i].currentDirection == "idle") && c.elevatorList[i].currentFloor <= requestedFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor

			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if (c.elevatorList[i].currentDirection == "up" || c.elevatorList[i].currentDirection == "idle") && c.elevatorList[i].currentFloor <= requestedFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor

			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if (c.elevatorList[i].currentDirection == "down" || c.elevatorList[i].currentDirection == "idle") && c.elevatorList[i].currentFloor >= requestedFloor {
			distance = c.elevatorList[i].currentFloor - requestedFloor

			if distance < bestDistance {
				bestDistance = distance
				c.bestElevator = c.elevatorList[i]
			}
		} else if requestedFloor == c.elevatorList[i].currentFloor && c.elevatorList[i].currentDirection == "idle" {
			c.bestElevator = c.elevatorList[i]
		}
	}
	//c.bestElevator.requestList = append(c.bestElevator.requestList, Request{requestedFloor})
	//c.bestElevator.requestList = append(c.bestElevator.requestList, Request{destinationFloor})
}

// Elevator ...
type Elevator struct {
	id               int
	currentFloor     int
	currentDirection string
	destinationFloor int
	currentStatus    string
	doorStatus       string
	//request          int
	//requestList      []Request
}

//Initiating Elevator ...
func (e *Elevator) doorOpenClosed(currentFloor) {
	c.requestedFloor = currentFloor
}

// Initiating Elevator ...
/* func (e *Elevator) moveElevator(_currentStatus string, currentDirection string, _currentFloor int) {
//fmt.Println("-->-->--> Doors are closing <--<--<--")
/* elevatorStatus := e.currentStatus
elevatorDirection := e.currentDirection
previousPosition := e.currentFloor */

/* for len(e.requestList) != 0 {
		if e.currentFloor > e.requestList[0] {
			//fmt.Println("Elevator {0}{1} is moving down ... currently at Floor {2}", columnId, id, currentFloor)
			elevatorStatus = "moving"
			elevatorDirection = "down"
			e.currentStatus = elevatorStatus
			e.currentDirection = elevatorDirection
			if e.currentFloor == 1 {
				e.currentFloor--
			}
			e.currentFloor--

		} else if e.currentFloor < e.requestList[0] {
			//fmt.Println("Elevator {0}{1} is moving up ... currently at Floor {2}", columnId, id, currentFloor)
			elevatorStatus = "moving"
			elevatorDirection = "up"
			e.currentStatus = elevatorStatus
			e.currentDirection = elevatorDirection
			if e.currentFloor == -1 {
				e.currentFloor++
			}
			e.currentFloor++
		} else if e.currentFloor == e.requestList[0] {
			elevatorStatus = "idle"
			elevatorDirection = "idle"
			//fmt.Println("\nElevator {0}{1} has arrived at Floor {2}\n", columnId, id, currentFloor)
			c.bestElevator.doorOpenClosed("Opened")
			//fmt.Println("<--<--<-- Doors are opening -->-->-->\n")
			//fmt.Println("User enters the Elevator...\n");
			doorOpenClosed("closed")
			//fmt.Println("-->-->--> Doors are closing <--<--<--\n")
			currentStatus = elevatorStatus
			currentDirection = elevatorDirection

			requestList.RemoveRange(0, 1)
		}

		if previousPosition != currentFloor {
			previousPosition = currentFloor
		}
	}
} */

func (e *Elevator) doorOpenClosed(doorStatus string) {
	doorStatus = e.doorStatus
}

// CallButton ...
type CallButton struct {
	id               int
	currentDirection string
}

// Initiating Call Button ...
func (c *Column) initCallButton(id int, _currentFloor int, currentDirection string, destinationFloor int, _currentStatus string, _doorStatus string, _request int) {

	fmt.Println("This is a Call Button")
}

// FloorRequestPanel ...
type FloorRequestPanel struct {
	floorAmount int
}

// Initiation Floor Request Panel ...
func (b *Battery) initFloorRequestPanelList(floorAmount int) {
	fmt.Println("This is a Floor Request Panel")
}

// FloorDisplay ...
type FloorDisplay struct {
	floorAmount int
}

// Request ...
type Request struct {
	floorAmount int
	requestList []Request
}

// Scenario Zone
func main() {
	fmt.Println("Hello World")
	battery := Battery{}
	battery.initBattery(4, 66, 5, 1, -6, 66)
	//battery.columnList[0].initColumn("A", 66, 5, 1, -6, -1)
	//battery.columnList[1].initColumn("B", 66, 5, 1, 2, 20)
	//battery.columnList[2].initColumn("C", 66, 5, 1, 21, 40)
	//battery.columnList[3].initColumn("D", 66, 5, 1, 41, 60)

	fmt.Println(battery)

	fmt.Println("         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ")
	fmt.Println("         <<                                      >>           ")
	fmt.Println("         <<   COMMERCIAL CONTROLLER TEST ZONE!   >>           ")
	fmt.Println("         <<                                      >>           ")
	fmt.Println("         <<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>           ")

	// SCENARIO 1
	battery.columnList[1].elevatorList[0].currentDirection = "down"
	battery.columnList[1].elevatorList[0].currentFloor = 20
	battery.columnList[1].elevatorList[1].currentDirection = "up"
	battery.columnList[1].elevatorList[1].currentFloor = 3
	battery.columnList[1].elevatorList[2].currentDirection = "down"
	battery.columnList[1].elevatorList[2].currentFloor = 13
	battery.columnList[1].elevatorList[3].currentDirection = "down"
	battery.columnList[1].elevatorList[3].currentFloor = 15
	battery.columnList[1].elevatorList[4].currentDirection = "down"
	battery.columnList[1].elevatorList[4].currentFloor = 6

	/* fmt.Println("----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("                         SCENARIO 1                         ");
	fmt.Println("  - Elevator B1 at 20th floor going to the 5th floor.");
	fmt.Println("  - Elevator B2 at 3rd floor going to the 15th floor.");
	fmt.Println("  - Elevator B3 at 13th floor going to RC.");
	fmt.Println("  - Elevator B4 at 15th floor going to the 2nd floor.");
	fmt.Println("  - Elevator B5 at 6th floor going to RC.");
	fmt.Println("    Someone at RC wants to go to the 20th floor.");
	fmt.Println("    Elevator B5 is expected to be sent.");
	fmt.Println("----------------------------------------------------------"); */

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

	/* fmt.Println("----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("                         SCENARIO 2                         ");
	fmt.Println("  - Elevator C1 at RC going to the 21st floor (not yet departed).");
	fmt.Println("  - Elevator C2 at 23rd floor going to the 28th floor.");
	fmt.Println("  - Elevator C3 at 33rd floor going to RC.");
	fmt.Println("  - Elevator C4 at 40th floor going to the 24th floor.");
	fmt.Println("  - Elevator C5 at 39th floor going to RC.");
	fmt.Println("    Someone at RC wants to go to the 36th floor.");
	fmt.Println("    Elevator C1 is expected to be sent.");
	fmt.Println("----------------------------------------------------------"); */

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

	/* fmt.Println("----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("                         SCENARIO 3                         ");
	fmt.Println("  - Elevator D1 at 58th going to RC.");
	fmt.Println("  - Elevator D2 at 50th floor going to the 60th floor.");
	fmt.Println("  - Elevator D3 at 46th floor going to the 58th floor.");
	fmt.Println("  - Elevator D4 at RC going to the 54th floor.");
	fmt.Println("  - Elevator D5 at 60th floor going to RC.");
	fmt.Println("    Someone at 54e floor wants to go to RC.");
	fmt.Println("    Elevator D1 is expected to be sent.");
	fmt.Println("----------------------------------------------------------"); */

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

	/* fmt.Println("----------------------------------------------------------");
	fmt.Println("----------------------------------------------------------");
	fmt.Println("                         SCENARIO 4                         ");
	fmt.Println("  - Elevator A1 “Idle” at SS4.");
	fmt.Println("  - Elevator A2 “Idle” at RC.");
	fmt.Println("  - Elevator A3 at SS3 going to SS5.");
	fmt.Println("  - Elevator A4 at SS6 going to RC.");
	fmt.Println("  - Elevator A5 at SS1 going to SS6.");
	fmt.Println("    Someone at SS3 wants to go to RC.");
	fmt.Println("    Elevator A4 is expected to be sent.");
	fmt.Println("----------------------------------------------------------"); */

	//battery.findBestColumn(-3, "up", 1);
}
