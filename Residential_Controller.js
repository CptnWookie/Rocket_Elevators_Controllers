
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('column constructor', floorAmount, elevatorAmount);
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList = [];
        this.callButtonList = [];
        this.floorRequestButtonList = [];

        for (let i = 1; i <= this.elevatorAmount; i++) {
            let elevator = new Elevator("elevator"+i, "idle", 1, "none", 10, "closed");
            this.elevatorList.push(elevator);
        }
        
        for (let i = 1; i <= this.floorAmount; i++) {
            if (i == 1) {
                let callButton = new CallButton("callButtonUP"+i, "up", false);
                this.callButtonList.push(callButton);
            } 
            else if (i == 10) {
                let callButton = new CallButton("callButtonDOWN"+i, "down", false);
                this.callButtonList.push(callButton);
            }    
            else {
                this.callButtonList.push(new CallButton("callButtonDOWN"+i, "down", false));
                this.callButtonList.push(new CallButton("callButtonUP"+i, "up", false));
            }
        }
        

        for (let i = 1; i <= this.floorAmount; i++) {
            let floorRequestButton = new FloorRequestButton("floorButton"+i, i);
            this.floorRequestButtonList.push(floorRequestButton);
            }
        console.table(this.elevatorList);
        console.table(this.floorRequestButtonList);
        console.table(this.callButtonList);
    }
}


class Elevator {
    constructor(id, status, position, direction, floorAmount, doors) {
        console.log('elevator constructor', id, status, position, direction, floorAmount, doors);
        this.id = id;
        this.status = status;
        this.position = position;
        this.direction = direction;
        this.floorAmount = floorAmount;
        this.doors = doors;
    }
}

class CallButton {
    constructor(id, floorAmount) {
        this.id = id;
        this.floorAmount = floorAmount;
    }
}


class FloorRequestButton {
    constructor(id, floorAmount) {
        this.id = id;
        this.floorAmount = floorAmount;
        
    }
}


/*
function requestElevator(requestedFloor, direction) {
        var bestElevator = this.findBestElevator(requestedFloor, direction);
        bestElevator.addFloorToList(requestedFloor);
        selected_ebestElevatorlevator.activateInsideButton(requestedFloor);
}
*/  

/*
function findBestElevator(requestedFloor, direction, position) {
    console.log(findBestElevator, "Patate")

    var maxDistance = 10;
    var requestedFloor = null;
    
    for (i = 0; i < this.column.elevatorList.length; i++) {
        var distanceFloorElevator = Math.abs(requestedFloor - this.elevatorList[i].currentFloor);
        //if ()
    }
   return bestElevator;
}
*/

/*
findBestElevator();
requestElevator();
*/


var column1 = new Column(10, 2);
//var elevator1 = new Elevator(elevator1, "online", 1, "none", 2, "closed");
//var elevator2 = new Elevator(elevator2, "idle", 10, "none", 2, "closed");
//var elevatorAmount = 2;
//var floorAmount = 10;
//var direction = "none";
//let requestedFloor = 3;

