
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
        console.table(this.elevatorList);
        console.table(this.floorRequestButtonList);
        console.table(this.callButtonList);
    }
    
    //CallButton pressed on floor
    requestedElevator(floor, direction) {
        console.log('requestedElevator', "Steak");
        var bestElevator = this.findBestElevator(floor, direction);
        //bestElevator.floor = this.move(Elevator, floor);
        console.log('Elevator ' + Elevator.id + ' has been requested');
        return bestElevator;
    }
        
    //Find the Best Elevator to Send to Call Button Floor 
    findBestElevator(floor, direction) {
        console.log('findBestElevator', "Blé d'inde");
        
        let bestElevator = null;

        for (var i = 0; i < this.elevatorList.length; i++) {
            var difference = Math.abs(this.elevatorList[i].position - floor);

            if (direction === 'up' && this.elevatorList[i].elevatorDirection === 'up' && this.elevatorList[i].position >= floor) {
                bestElevator = this.elevatorList[i];
            } 
            else if (direction === 'down' && this.elevatorList[i].elevatorDirection === 'down' && this.elevatorList[i].position >= floor) {
                    bestElevator = difference;
            }
        }
    }



// ---------------------------------- SECTION TO FIX ---------------------------------- 


    //FloorButton pressed inside Elevator
    requestedFloor(Elevator, floor) {
        console.log('requestedFloor', "Patate");

        if(floor < Elevator.position) {
            bestElevator.move(floor, 'down', 'moving');
        }
        else {
            bestElevator.move(floor, 'up', 'moving');
            console.log('Move to requested floor');
        }
        return requestedFloor;   
    }

    
//---------------------------------- SECTION TO FIX ---------------------------------- 

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
    }

    //Move Elevator
    move(floor) {
        if ((floor - bestElevator.floor) > 0) {
            this.potition ++;
        }
        else {
            this.position --;
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

var requestElevator = column1.requestedElevator(2, 'up');
var requestFloor = column1.requestedFloor(Elevator, 5);
var bestElevator = column1.findBestElevator(3, 'up');







/* #################################### TEST ZONE ####################################*/