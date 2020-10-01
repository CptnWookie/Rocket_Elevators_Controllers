class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorRequestButtonList = []
        self.bestElevator





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

