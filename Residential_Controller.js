
var elevatorAmount = 2;
var floorAmount = 10;
var direction = "none";
let requestedFloor = 3;


class column {
    constructor(floorAmount, elevatorAmount) {
        console.log('column constructor', floorAmount);
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList = [];
        this.floorButtonList = [];

        for (let i = 1; i <= this.elevatorAmount; i++) {
            let elevator = new elevator(i, "idle", 1, "up", this.floorAmount);
            this.elevatorList.push(elevator);
        }

        for (let i = 0; i < this.floorAmount; i++) {
            if (i == 0) {
                this.floorButtonList.push(new floorButton(i, "up", false));
            } 
            else {
                this.floorButtonList.push(new floorButton(i, "up", false));
                this.floorButtonList.push(new floorButton(i, "down", false));
            }
        }
        
    }
    function requestElevator(requestedFloor, direction) {
        console.log('requestElevator', "ok1");
    }
}



requestElevator(3, "up");  