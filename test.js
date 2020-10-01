
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('column constructor', floorAmount, elevatorAmount);
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

        console.log("INIT ELEVATOR REQUEST...");
        console.log("LOOKING FOR BEST ELEVATOR...")
        

        this.bestElevator = this.findBestElevator(floor, direction);
        console.log("BEST ELEVATOR FOUND...");
        console.log("Elevator " + this.bestElevator.id + " is requested at Floor " + floor);
        
        this.bestElevator.requestList.push(floor);
        this.bestElevator.moveElevator();
        return this.bestElevator;
    }
        
    //Find the Best Elevator to Send to Call Button Floor 
    findBestElevator(floor, direction) {
        
        for (let i = 0; i < this.elevatorList.length; i++) {
            //let distance = Math.abs(this.elevatorList[i].position - floor);

            if (floor === this.elevatorList[i].position && this.elevatorList[i].direction === "idle") {
                //console.log(bestCase);
                var bestCase = this.elevatorList[i];
            }
            else if (direction === "up" && (this.elevatorList[i].direction === "up" || this.elevatorList[i].direction === "idle") && this.elevatorList[i].position <= floor){
                //console.log(bestCase);
                var bestCase = this.elevatorList[i];
                //bestDistance = distance;
            }
            else if (direction === "down" && (this.elevatorList[i].direction === "down" || this.elevatorList[i].direction === "idle") && this.elevatorList[i].position >= floor){
                //console.log(bestCase);
                var bestCase = this.elevatorList[i];
                //bestDistance = distance;
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
        //console.log(bestIdle);
        if (bestCase != null) {
            return bestCase;
        } else {
            return bestIdle;
        }
         
    }

 
    //FloorButton pressed inside Elevator
    requestFloor(elevator, floor) {
        console.log("REQUESTED FLOOR : " + floor);
        
        elevator.requestList.push(floor);
        elevator.moveElevator();
    }
}


class Elevator {
    constructor(id, status, position, direction, floor, doors) {
        console.log('elevator constructor', id, status, position, direction, floor, doors);
        this.id = id;
        this.status = status;
        this.position = position;
        this.direction = direction;
        this.floor = floor;
        this.doors = doors;
        this.requestList = [];
       
    }

    //Move Elevator
    moveElevator() {
        var previousPosition = this.position;
        while (this.requestList.length != 0) {
            if (this.potition > this.requestList[0]){
                this.position--;
            } 
            else if (this.position < this.requestList[0]) {
                this.position++;
            } 
            else if (this.position == this.requestList[0]) {
                console.log("Elevator " + this.id + " arrived at Floor " + this.position);
                this.requestList.splice(0, 1);
            }

            if (previousPosition != this.position) {
                console.log("... now on Floor Level " + this.position + " ...");
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

    var elevator = column1.requestElevator(1, "up");
    column1.requestFloor(elevator, 6);
    
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

    var elevator = column1.requestElevator(3, "down");
    column1.requestFloor(elevator, 2);

    for (var i of column1.elevatorList) {
        i.moveElevator();
    };

    elavator = column1.requestElevator(10, "down");
    column1.requestFloor(elevator, 3);
    
};


scenario1();
scenario2();
scenario3();

/* #################################### TEST ZONE ####################################*/