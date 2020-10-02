class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorRequestButtonList = []
        self.bestElevator

        i = 1
        while i <= self.elevatorAmount:
            print('new Elevator')
            elevator = Elevator('Elevator' + i, 'idle', 1, 'none', 10, 'closed')
            self.elevatorList.append(elevator)
            i += 1

        print(self.elevatorList)


        for floorAmount in range (1,11):
            print(floorAmount)
            floorRequestButton = FloorRequestButton(id, floorAmount)
            self.floorRequestButtonList.append(floorRequestButton)

        print(self.floorRequestButtonList)

        for floorAmount in range(1,11):



class Elevator:
    def __init__(self, id, status, position, direction, floor, doors):
        self.id = id
        self.status = status
        self.position = position
        self.direction = direction
        self.floor = floor
        self.doors = doors
        self.requestList = []



class CallButton:
    def __init__(self, id, floor, direction):
        self.id = id
        self.direction = direction
        self.floor = floor



class FloorRequestButton:
    def __init__(self, id, floorAmount):
        self.id = id
        self.floorAmount = floorAmount

