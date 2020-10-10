// *****************************************************************************************
// * Project           : Rocket Elevators Inc. - Commercial Division
// *
// * Program name      : Commercial_Controller.go
// *
// * Author            : Alexandre Leblanc
// *
// * Date created      : 20100816
// *
// * Purpose           : Code for Commercial products and Solutions
// *
// *****************************************************************************************

package main

import (
	"fmt"
)

// Main Function responsible to execute the program
func main() {
	battery := &Battery{}
	battery.initBattery(1, 4, 66, 5)
	fmt.Println("Battery : ", battery.id)
	for i := 0; i < len(battery.columnList); i++ {
		fmt.Println("Column :", battery.columnList[i].id)
		for j := 0; j < len(battery.columnList[i].elevatorList); j++ {
			fmt.Println("Elevator :", battery.columnList[i].id, battery.columnList[i].elevatorList[j].id)
		}
	}
	for i := 0; i < len(battery.callButtonList); i++ {
		fmt.Println("Call Button :", battery.callButtonList[i].id)
	}

	battery.columnList[0].minMax(-6, -1)
	battery.columnList[1].minMax(2, 20)
	battery.columnList[2].minMax(21, 40)
	battery.columnList[3].minMax(41, 60)

	// Test Zone containing 4 scenarios to test various elements of the program

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

	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("                         SCENARIO 1                       			")
	fmt.Println("  - Elevator B1 at 20th floor going to the 5th floor.				")
	fmt.Println("  - Elevator B2 at 3rd floor going to the 15th floor.				")
	fmt.Println("  - Elevator B3 at 13th floor going to RC.							")
	fmt.Println("  - Elevator B4 at 15th floor going to the 2nd floor.				")
	fmt.Println("  - Elevator B5 at 6th floor going to RC.							")
	fmt.Println("  - Someone at RC wants to go to the 20th floor.					")
	fmt.Println("  - Elevator B5 is expected to be sent.							")
	fmt.Println("-----------------------------------------------------------------	")

	battery.findBestColumn(1, "up", 20)

	// SCENARIO 2
	battery.columnList[2].elevatorList[0].currentDirection = "idle"
	battery.columnList[2].elevatorList[0].currentFloor = 1
	battery.columnList[2].elevatorList[1].currentDirection = "up"
	battery.columnList[2].elevatorList[1].currentFloor = 23
	battery.columnList[2].elevatorList[2].currentDirection = "down"
	battery.columnList[2].elevatorList[2].currentFloor = 33
	battery.columnList[2].elevatorList[3].currentDirection = "down"
	battery.columnList[2].elevatorList[3].currentFloor = 40
	battery.columnList[2].elevatorList[4].currentDirection = "down"
	battery.columnList[2].elevatorList[4].currentFloor = 39

	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("                         SCENARIO 2                         		")
	fmt.Println("  - Elevator C1 at RC going to the 21st floor (not yet departed).	")
	fmt.Println("  - Elevator C2 at 23rd floor going to the 28th floor.				")
	fmt.Println("  - Elevator C3 at 33rd floor going to RC.							")
	fmt.Println("  - Elevator C4 at 40th floor going to the 24th floor.				")
	fmt.Println("  - Elevator C5 at 39th floor going to RC.							")
	fmt.Println("  - Someone at RC wants to go to the 36th floor.					")
	fmt.Println("  - Elevator C1 is expected to be sent.							")
	fmt.Println("-----------------------------------------------------------------	")

	battery.findBestColumn(1, "up", 36)

	// SCENARIO 3
	battery.columnList[3].elevatorList[0].currentDirection = "down"
	battery.columnList[3].elevatorList[0].currentFloor = 58
	battery.columnList[3].elevatorList[1].currentDirection = "up"
	battery.columnList[3].elevatorList[1].currentFloor = 50
	battery.columnList[3].elevatorList[2].currentDirection = "up"
	battery.columnList[3].elevatorList[2].currentFloor = 46
	battery.columnList[3].elevatorList[3].currentDirection = "up"
	battery.columnList[3].elevatorList[3].currentFloor = 1
	battery.columnList[3].elevatorList[4].currentDirection = "down"
	battery.columnList[3].elevatorList[4].currentFloor = 60

	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("                         SCENARIO 3                         		")
	fmt.Println("  - Elevator D1 at 58th going to RC.								")
	fmt.Println("  - Elevator D2 at 50th floor going to the 60th floor.				")
	fmt.Println("  - Elevator D3 at 46th floor going to the 58th floor.				")
	fmt.Println("  - Elevator D4 at RC going to the 54th floor.						")
	fmt.Println("  - Elevator D5 at 60th floor going to RC.							")
	fmt.Println("  - Someone at 54e floor wants to go to RC.						")
	fmt.Println("  - Elevator D1 is expected to be sent.							")
	fmt.Println("-----------------------------------------------------------------	")

	battery.findBestColumn(54, "down", 1)

	// SCENARIO 4
	battery.columnList[0].elevatorList[0].currentDirection = "idle"
	battery.columnList[0].elevatorList[0].currentFloor = -4
	battery.columnList[0].elevatorList[1].currentDirection = "idle"
	battery.columnList[0].elevatorList[1].currentFloor = 1
	battery.columnList[0].elevatorList[2].currentDirection = "down"
	battery.columnList[0].elevatorList[2].currentFloor = -3
	battery.columnList[0].elevatorList[3].currentDirection = "up"
	battery.columnList[0].elevatorList[3].currentFloor = -6
	battery.columnList[0].elevatorList[4].currentDirection = "down"
	battery.columnList[0].elevatorList[4].currentFloor = -1

	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("-----------------------------------------------------------------	")
	fmt.Println("                         SCENARIO 4                         		")
	fmt.Println("  - Elevator A1 “Idle” at SS4.										")
	fmt.Println("  - Elevator A2 “Idle” at RC.										")
	fmt.Println("  - Elevator A3 at SS3 going to SS5.								")
	fmt.Println("  - Elevator A4 at SS6 going to RC.								")
	fmt.Println("  - Elevator A5 at SS1 going to SS6.								")
	fmt.Println("  - Someone at SS3 wants to go to RC.								")
	fmt.Println("  - Elevator A4 is expected to be sent.							")
	fmt.Println("-----------------------------------------------------------------	")

	battery.findBestColumn(-3, "up", 1)
}

// Battery ...
type Battery struct {
	id                      int
	columnAmount            int
	floorAmount             int
	elevatorAmountPerColumn int
	minFloor                int
	maxFloor                int
	bestColumn              int
	columnList              []Column
	callButtonList          []CallButton
}

// Initiating Battery ...
func (b *Battery) initBattery(id int, columnAmount int, floorAmount int, elevatorAmountPerColumn int) {
	b.id = id

	//Initiating Column List ...
	for i := 0; i < columnAmount; i++ {
		b.columnList = append(b.columnList, Column{})
		b.columnList[i].initColumn(i + 1, elevatorAmountPerColumn)
	}

	// Initiating Call Button List ...
	for i := 0; i < floorAmount; i++ {
		if i <= 5 {
			b.callButtonList = append(b.callButtonList, CallButton{i - 6, "up"})
		} else if i < floorAmount-1 {
			b.callButtonList = append(b.callButtonList, CallButton{i - 4, "down"})
		}
	}
}

// Find the Best Column based on the requested floor
func (b *Battery) findBestColumn(requestedFloor int, currentDirection string, destinationFloor int) {
	if requestedFloor != 1 {
		for i := 0; i < len(b.columnList); i++ {
			if requestedFloor <= b.columnList[i].maxFloor && requestedFloor >= b.columnList[i].minFloor {
				b.bestColumn = b.columnList[i].id
				fmt.Println("The selected column is : #", b.bestColumn)
				b.columnList[i].requestElevator(requestedFloor, currentDirection, destinationFloor)
				//fmt.Println("The selected column is ", b.bestColumn)
			}
		}

		// In the event a request for an elevator is made from the Lobby, call assignElevator function.
	} else {
		for i := 0; i < len(b.columnList); i++ {
			if destinationFloor <= b.columnList[i].maxFloor && destinationFloor >= b.columnList[i].minFloor {
				b.bestColumn = b.columnList[i].id
				fmt.Println("The selected column is : #", b.bestColumn)
				b.columnList[i].assignElevator(requestedFloor, currentDirection, destinationFloor)
				//fmt.Println("The selected column is ", b.bestColumn)
			}
		}
	}
	//fmt.Println("The selected column is ", b.bestColumn)
}

// Column ...
type Column struct {
	id                      int
	floorAmount             int
	elevatorAmountPerColumn int
	minFloor                int
	maxFloor                int
	bestElevator            Elevator
	elevatorList            []Elevator
	floorDisplayList        []FloorDisplay
}

// Initiating Column ...
func (c *Column) initColumn(id int, elevatorAmountPerColumn int) {
	c.id = id
	c.bestElevator = Elevator{1, 1, "", 1, "", ""}

	// Creating Elevator List ...
	for i := 0; i < elevatorAmountPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1, 1, "idle", 1, "idle", "closed"})
	}

	// Creating Floor Display indicating the current floor of an elevator
	for i := 1; i < len(c.elevatorList); i++ {
		c.floorDisplayList = append(c.floorDisplayList, FloorDisplay{c.elevatorList[i].currentFloor})
	}
}

func (c *Column) minMax(min int, max int) {
	c.minFloor = min
	c.maxFloor = max
}

// This Function returns the best Elevator based on either requestElevator or assignElevator
/* func (c *Column) bestOfBest(requestedFloor int, currentDirection string, destinationFloor int) {
	fmt.Println("Best Elevator identified : ", c.bestElevator)
	c.bestElevator.moveElevator(requestedFloor)
} */

//This function represents an elevator request on a floor or basement.
func (c *Column) requestElevator(requestedFloor int, currentDirection string, destinationFloor int) {
	fmt.Println("\n...Looking for Best Elevator...")
	c.findBestElevator(requestedFloor, currentDirection)
	c.bestElevator.moveElevator(requestedFloor)
	fmt.Println("\nElevator has arrived at Floor ", requestedFloor)
	c.bestElevator.doorOpenClosed("opened")
	fmt.Println("\n<--<--<-- Doors are opening -->-->-->")
	c.bestElevator.doorOpenClosed("closed")
	fmt.Println("\n-->-->--> Doors are closing <--<--<--")
	c.bestElevator.moveElevator(destinationFloor)
	fmt.Println("\nElevator has arrived at Floor ", destinationFloor)
	c.bestElevator.doorOpenClosed("opened")
	fmt.Println("\n<--<--<-- Doors are opening -->-->-->")
	c.bestElevator.doorOpenClosed("closed")
	fmt.Println("\n-->-->--> Doors are closing <--<--<--")
}

// Elevator Request from the Lobby
func (c *Column) assignElevator(requestedFloor int, currentDirection string, destinationFloor int) {
	c.findBestElevator(requestedFloor, currentDirection)
	fmt.Println("\n...Looking for Best Elevator...")
	c.bestElevator.moveElevator(requestedFloor)
	fmt.Println("\nElevator has arrived at Floor ", requestedFloor)
	c.bestElevator.doorOpenClosed("opened")
	fmt.Println("\n<--<--<-- Doors are opening -->-->-->")
	c.bestElevator.doorOpenClosed("closed")
	fmt.Println("\n-->-->--> Doors are closing <--<--<--")
	c.bestElevator.moveElevator(destinationFloor)
	fmt.Println("\nElevator has arrived at Floor ", destinationFloor)
	c.bestElevator.doorOpenClosed("opened")
	fmt.Println("\n<--<--<-- Doors are opening -->-->-->")
	c.bestElevator.doorOpenClosed("closed")
	fmt.Println("\n-->-->--> Doors are closing <--<--<--")
}



func (c *Column) findBestElevator(requestedFloor int, currentDirection string) {
	distance := 0
	bestDistance := 99

	if requestedFloor == 1 {
		for i := 0; i < len(c.elevatorList); i++ {

			if currentDirection == "up" && currentDirection != c.elevatorList[i].currentDirection && requestedFloor <= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - requestedFloor

				if distance < bestDistance {
					bestDistance = distance
					c.bestElevator = c.elevatorList[i]
				}
			} else if currentDirection == "down" && currentDirection != c.elevatorList[i].currentDirection && requestedFloor >= c.elevatorList[i].currentFloor {
				distance = requestedFloor - c.elevatorList[i].currentFloor

				if distance < bestDistance {
					bestDistance = distance
					c.bestElevator = c.elevatorList[i]
				}
			}
		}
		if c.bestElevator.id != 0 {
			fmt.Println("\nBest Elevator identified : #", c.bestElevator.id)
		} else {
			for i := 0; i < len(c.elevatorList); i++ {
				if currentDirection == "idle" {
					distance = c.elevatorList[i].currentFloor - requestedFloor

					if distance < bestDistance {
						bestDistance = distance
						c.bestElevator = c.elevatorList[i]
					}
				}
			}
			if c.bestElevator.id != 0 {
				fmt.Println("\nBest Elevator identified : #", c.bestElevator.id)
			}
		}
	} else {
		for i := 0; i < len(c.elevatorList); i++ {
			if currentDirection == "up" && currentDirection == c.elevatorList[i].currentDirection && requestedFloor >= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - requestedFloor
				if distance < bestDistance {
					bestDistance = distance
					c.bestElevator = c.elevatorList[i]
				}
			} else if currentDirection == "down" && currentDirection == c.elevatorList[i].currentDirection && requestedFloor <= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - requestedFloor
				if distance < bestDistance {
					bestDistance = distance
					c.bestElevator = c.elevatorList[i]
				}
			}
		}
		if c.bestElevator.id != 0 {
			fmt.Println("\nBest Elevator identified : #", c.bestElevator.id)

		} else {
			for i := 0; i < len(c.elevatorList); i++ {
				if currentDirection == "idle" {
					distance = c.elevatorList[i].currentFloor - requestedFloor

					if distance < bestDistance {
						bestDistance = distance
						c.bestElevator = c.elevatorList[i]
					}
				}
			}
			if c.bestElevator.id != 0 {
				fmt.Println("\nBest Elevator identified : #", c.bestElevator.id)
			}
		}
	}
}

// Elevator ...
type Elevator struct {
	id               int
	currentFloor     int
	currentDirection string
	destinationFloor int
	currentStatus    string
	doorStatus       string
}

func (e *Elevator) moveElevator(destinationFloor int) {
	destinationFloor = e.currentFloor
}

func (e *Elevator) doorOpenClosed(doorStatus string) {
	doorStatus = e.doorStatus
}

// CallButton ...
type CallButton struct {
	id               int
	currentDirection string
}

// FloorDisplay ...
type FloorDisplay struct {
	floorAmount int
}
