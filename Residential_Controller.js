
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('column constructor', floorAmount, elevatorAmount);
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList = [];
        this.callButtonList = [];
        this.floorRequestButtonList = [];
        this.distanceList = [];

        for (let i = 1; i <= this.elevatorAmount; i++) {
            let elevator = new Elevator("elevator"+i, "idle", 1, "none", 10, "closed");
            this.elevatorList.push(elevator);
        }
        
        for (let i = 1; i <= this.floorAmount; i++) {
            if (i == 1) {
                let callButton = new CallButton("callButtonUP"+i, i, "up", false);
                this.callButtonList.push(callButton);
            } 
            else if (i == 10) {
                let callButton = new CallButton("callButtonDOWN"+i, i, "down", false);
                this.callButtonList.push(callButton);
            }    
            else {
                this.callButtonList.push(new CallButton("callButtonDOWN"+i, i, "down", false));
                this.callButtonList.push(new CallButton("callButtonUP"+i, i, "up", false));
            }
        }
        
        for (let i = 1; i <= this.floorAmount; i++) {
            let floorRequestButton = new FloorRequestButton("floorButton"+i, i);
            this.floorRequestButtonList.push(floorRequestButton);
        }
        
        for (let i = 1; i <= this.elevatorAmount; i++) {
            let distance = new Distance("distance" + i);
            this.distanceList.push(distance);
        }

        console.log("ELEVATORS LIST");
        console.table(this.elevatorList);
        console.log("CALL BUTTON LIST");
        console.table(this.callButtonList);
        console.log("FLOOR REQUEST BUTTON LIST");
        console.table(this.floorRequestButtonList);
        console.log("DISTANCE LIST");
        console.table(this.distanceList);
    }
    
    //CallButton pressed on floor
    requestedElevator(floor, direction) {
        console.log("REQUESTED ELEVATOR");
        var bestElevator = this.findBestElevator(floor, direction);
        console.log("Elevator" + bestElevator.id + " has been requested");
        bestElevator.moveElevator(floor);
        
        
    
    }
        
    //Find the Best Elevator to Send to Call Button Floor 
    findBestElevator(floor, direction) {
               
        let bestCase = null;

        for (var i = 0; i < this.elevatorList.length; i++) {
            var difference = Math.abs(this.elevatorList[i].position - floor);
            //console.log(difference);
            if (direction === "up" && this.elevatorList[i].direction === "up" && this.elevatorList[i].position <= floor) {
                bestCase = this.elevatorList[i];
            } 
            if (direction === "down" && this.elevatorList[i].direction === "down" && this.elevatorList[i].position >= floor) {
                bestCase = this.elevatorList[i];
            }
            if (direction === "up" && this.elevatorList[i].direction === "none" && this.elevatorList[i].position <= floor) {
                bestCase = this.elevatorList[i];
            }
            if (direction === "down" && this.elevatorList[i].direction === "none" && this.elevatorList[i].position >= floor) {
                bestCase = this.elevatorList[i];
            }  
            //else {
                //bestCase = Math.min(this.elevatorList[i].distance);
            //}
            
            var bestElevator = bestCase;
        
        
        }
        //console.log(bestElevator);
        return bestElevator;
    }

// ---------------------------------- SECTION TO FIX IN COLUMN CLASS ---------------------------------- 
    //FloorButton pressed inside Elevator
    requestedFloor(Elevator, floor) {
        console.log("REQUESTED FLOOR");

        if(floor < Elevator.position) {
            bestElevator.move(floor, 'down', 'moving');
        }
        else {
            bestElevator.move(floor, 'up', 'moving');
            console.log('Move to requested floor');
        }
        return requestedFloor;   
    }
//---------------------------------- SECTION TO FIX IN COLUMN CLASS ---------------------------------- 

}


class Elevator {
    constructor(id, status, position, direction, floor, doors, distance) {
        console.log('elevator constructor', id, status, position, direction, floor, doors, distance);
        this.id = id;
        this.status = status;
        this.position = position;
        this.direction = direction;
        this.floor = floor;
        this.doors = doors;
        this.distance = distance;
        
        
        
    }

    //Move Elevator
    moveElevator(floor) {
        console.log()
        var bestElevatorFloor = Elevator.floor;
        if ((floor - bestElevatorFloor) > 0) {
            this.potition ++;
        }
        else {
            this.position --;
        }
        //console.log(moveElevator);
    }
}

class CallButton {
    constructor(id, floor, direction) {
        this.id = id;
        this.direction = direction;
        this.floor = floor;
    }
}


class FloorRequestButton {
    constructor(id, floorAmount) {
        this.id = id;
        this.floorAmount = floorAmount;
    }
}


class Distance {
    constructor(id, distance) {
        this.id = id;
        this.distance = distance;
    }
}



/* #################################### TEST ZONE ####################################*/
var column1 = new Column(10, 2);
column1.elevatorList[0].id = "A";
column1.elevatorList[0].position = 2;
column1.elevatorList[0].direction = 'none';
column1.elevatorList[0].status = 'idle';
column1.elevatorList[0].floor = 3;
column1.elevatorList[0].distance = Math.abs(column1.elevatorList[0].position - column1.elevatorList[0].floor);
column1.elevatorList[1].id = "B";
column1.elevatorList[1].position = 7;
column1.elevatorList[1].direction = 'none';
column1.elevatorList[1].status = 'idle';
column1.elevatorList[1].floor = 3;
column1.elevatorList[1].distance = Math.abs(column1.elevatorList[1].position - column1.elevatorList[1].floor);

column1.requestedElevator(3, "up");
column1.findBestElevator(3, "up");


/* SCENARIO 1 */



/* #################################### TEST ZONE ####################################*/