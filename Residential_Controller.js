
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('COLUMN INITIALIZED\n');
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList = [];
        this.callButtonList = [];
        this.floorRequestButtonList = [];
        this.bestElevator;

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
                
        console.log("ELEVATORS LIST");
        console.table(this.elevatorList);
        console.log("CALL BUTTON LIST");
        console.table(this.callButtonList);
        console.log("FLOOR REQUEST BUTTON LIST");
        console.table(this.floorRequestButtonList);
        
    }
    
    //CallButton pressed on floor
    requestElevator(floor, direction) {

        console.log("...Looking for Best Elevator...\n");

        this.bestElevator = this.findBestElevator(floor, direction);
        
        console.log("Best Elevator identified  :  Elevator " + this.bestElevator.id);
        console.log("\n---> Call Button pressed on Floor " + floor + " <---\n");
        
        this.bestElevator.requestList.push(floor);
        this.bestElevator.moveElevator();
        
        return this.bestElevator;
    }
        
    //Find the Best Elevator to Send to Call Button Floor 
    findBestElevator(floor, direction) {
        
        for (let i = 0; i < this.elevatorList.length; i++) {
            
            if (floor === this.elevatorList[i].position && this.elevatorList[i].status === "idle") {
                var bestCase = this.elevatorList[i];
            }
            else if (direction === "up" && (this.elevatorList[i].direction === "up" || this.elevatorList[i].status === "idle") && this.elevatorList[i].position <= floor){
                var bestCase = this.elevatorList[i];
                
            }
            else if (direction === "down" && (this.elevatorList[i].direction === "down" || this.elevatorList[i].status === "idle") && this.elevatorList[i].position >= floor){
                var bestCase = this.elevatorList[i];
            }
        }

        let minDistance = 999;
        let bestDistance = 11;
        for (let  i = 0; i < this.elevatorList.length; i++) {
            let distance = Math.abs(this.elevatorList[i].position - floor);
            
            if (this.elevatorList[i].direction === "idle" && bestDistance >= distance) {
                minDistance = distance;
                var bestIdle = this.elevatorList[i];
            }
        }
        
        if (bestCase != null) {
            return bestCase;
        } else {
            return bestIdle;
        }
         
    }

 
    //FloorButton pressed inside Elevator
    requestFloor(elevator, floor) {
        console.log("\n---> Floor Button # " + floor + " pressed <---\n");
        elevator.requestList.push(floor);
        elevator.moveElevator();
    }
}


class Elevator {
    constructor(id, status, position, direction, floor, doors) {
        //console.log('elevator constructor', id, status, position, direction, floor, doors);
        this.id = id;
        this.status = status;
        this.position = position;
        this.direction = direction;
        this.floor = floor;
        this.doors = doors;
        this.requestList = [];
    }

    //Move Elevator
    moveElevator(status, direction) {
        console.log("Elevator " + this.id + " Doors -----> Closed\n")
        var elevatorStatus = this.status;
        var elevatorDirection = this.direction;
        var previousPosition = this.position;
        while (this.requestList.length != 0) {
            
            if (this.position > this.requestList[0]) {
                console.log("Elevator " + this.id + " is moving down ... currently at Floor " + this.position);
                elevatorStatus = "moving";
                elevatorDirection = "down";
                this.status = elevatorStatus;
                this.direction = elevatorDirection;
                this.position--;
            } 
            else if (this.position < this.requestList[0]) {
                console.log("Elevator " + this.id + " is moving up ... currently at Floor " + this.position);
                elevatorStatus = "moving";
                elevatorDirection = "up";
                this.status = elevatorStatus;
                this.direction = elevatorDirection;
                this.position++;
            } 
            else if (this.position == this.requestList[0]) {
                elevatorStatus = "idle";
                elevatorDirection = "idle";
                console.log("\nElevator " + this.id + " arrived at Floor " + this.position);
                console.log("\nElevator " + this.id + " Doors -----> Opened ")
                this.status = elevatorStatus;
                this.direction = elevatorDirection;
                this.requestList.splice(0, 1);   

                return status, direction;
            }
            
            if (previousPosition != this.position) {
                previousPosition = this.position;
            }
        }
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



/* #################################### TEST ZONE ####################################*/
var column1 = new Column(10, 2);

/* SCENARIO 1 */
function scenario1() {
    console.log("\n-----------------------\n");
    console.log("SCENARIO 1\n");
    column1.elevatorList[0].id = "A";
    column1.elevatorList[0].position = 2;
    column1.elevatorList[0].direction = 'idle';
    column1.elevatorList[0].status = 'idle';
    column1.elevatorList[0].floor = 3;
    column1.elevatorList[1].id = "B";
    column1.elevatorList[1].position = 6;
    column1.elevatorList[1].direction = 'idle';
    column1.elevatorList[1].status = 'idle';
    column1.elevatorList[1].floor = 3;

    console.log("/// FIRST CALL ///");
    console.log("  - Elevator A is Idle at floor 2.");
    console.log("  - Elevator B is Idle at floor 6.");
    console.log("  - Someone is on floor 3 and wants to go to the 7th floor.");
    console.log("  - Elevator A is expected to be sent.");
    console.log("/// FIRST CALL ///\n");

    var elevator = column1.requestElevator(3, "up");
    column1.requestFloor(elevator, 7);
      
};


/* SCENARIO 2 */
function scenario2() {
    console.log("\n-----------------------\n");
    console.log("SCENARIO 2\n");
    column1.elevatorList[0].id = "A";
    column1.elevatorList[0].position = 10;
    column1.elevatorList[0].direction = 'idle';
    column1.elevatorList[0].status = 'idle';
    column1.elevatorList[0].floor = 1;
    column1.elevatorList[1].id = "B";
    column1.elevatorList[1].position = 3;
    column1.elevatorList[1].direction = 'idle';
    column1.elevatorList[1].status = 'idle';
    column1.elevatorList[1].floor = 1;

    console.log("/// FIRST CALL ///");
    console.log("  - Elevator A is Idle at floor 10.");
    console.log("  - Elevator B is idle at floor 3");
    console.log("  - Someone is on the 1st floor and requests the 6th floor.");
    console.log("  - Elevator B should be sent.");
    console.log("/// FIRST CALL ///\n");

    var elevator = column1.requestElevator(1, "up");
    column1.requestFloor(elevator, 6);

    for (var i of column1.elevatorList) {
        i.moveElevator();
    };

    console.log("\n/// SECOND CALL ///");
    console.log("  - 2 minutes later, someone else is on the 3rd floor and requests the 5th floor.");
    console.log("  - Elevator B should be sent.");
    console.log("/// SECOND CALL ///\n");

    elevator = column1.requestElevator(3, "up");
    column1.requestFloor(elevator, 5);

    for (var i of column1.elevatorList) {
        i.moveElevator();
    }; 

    console.log("\n/// THIRD CALL ///");
    console.log("  - Finally, a third person is at floor 9 and wants to go down to the 2nd floor.");
    console.log("  - Elevator A should be sent.");
    console.log("/// THIRD CALL ///\n");

    elevator = column1.requestElevator(9, "down");
    column1.requestFloor(elevator, 2);
    
};


/* SCENARIO 3 */
function scenario3() {
    console.log("\n-----------------------\n");
    console.log("SCENARIO 3\n");
    column1.elevatorList[0].id = "A";
    column1.elevatorList[0].position = 10;
    column1.elevatorList[0].direction = 'idle';
    column1.elevatorList[0].status = 'idle';
    column1.elevatorList[0].floor = 3;
    column1.elevatorList[1].id = "B";
    column1.elevatorList[1].position = 3;
    column1.elevatorList[1].requestList = [6];
    column1.elevatorList[1].direction = 'up';
    column1.elevatorList[1].status = 'moving';
    column1.elevatorList[1].floor = 6;

    console.log("/// FIRST CALL ///");
    console.log("  - Elevator A is Idle at floor 10.");
    console.log("  - Elevator B is Moving from floor 3 to floor 6.");
    console.log("  - Someone is on floor 3 and requests the 2nd floor.");
    console.log("  - Elevator A should be sent.");
    console.log("/// FIRST CALL ///\n");

    var elevator = column1.requestElevator(3, "down");
    column1.requestFloor(elevator, 2);
    

    for (var i of column1.elevatorList) {
        i.moveElevator();
    };

    console.log("\n/// SECOND CALL ///");
    console.log("  - 5 minutes later, someone else is on the 10th floor and wants to go to the 3rd.");
    console.log("  - Elevator B should be sent.");
    console.log("/// SECOND CALL ///\n");
    
    elevator = column1.requestElevator(10, "down");
    column1.requestFloor(elevator, 3);
    
    console.log("\n\n\nTEST COMPLETED !!!!")
};


scenario1();
scenario2();
scenario3();

    

/* #################################### TEST ZONE ####################################*/