
class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorRequestButtonList = []
        
        print('ELEVATOR LIST :')
        i = 0
        while i < self.elevatorAmount:
            elevator = Elevator('Elevator {}'.format(i + 1))
            self.elevatorList.append(elevator)
            print(self.elevatorList[i].id)
            i += 1
        
        print('')
        print('FLOOR REQUEST BUTTON LIST :')
        for i in range(10):
            floorRequestButton = FloorRequestButton(i + 1, self.floorAmount)
            self.floorRequestButtonList.append(floorRequestButton)
            print('FloorRequestButton', self.floorRequestButtonList[i].id)

        print('')
        print('CALL BUTTON LIST :')
        for i in range(self.floorAmount):
            if i == 0:
                callButton = CallButton (i + 1, 'off', 'up')
                self.callButtonList.append(callButton)
                print('CallButton up {}'.format(self.callButtonList[i].id))
            
            elif i == 9:
                callButton = CallButton(i + 1, 'down', 'off')
                self.callButtonList.append(callButton)
                print('CallButton Down {}'.format(self.callButtonList[i].id))

            else:
                callButton = CallButton(i + 1, 'down', 'up')
                self.callButtonList.append(callButton)
                print('CallButton Down|Up {}'.format(self.callButtonList[i].id))


            


class Elevator:
    def __init__(self, _id):
        self.id = _id
        self.status = 'idle'
        self.position = 1
        self.direction = 'idle'
        self.floor = None
        self.doors = 'closed'
        self.requestList = []

class CallButton:
    def __init__(self, _id, floor, direction):
        self.id = _id
        self.direction = direction
        self.floor = floor

class FloorRequestButton:
    def __init__(self, _id, floorAmount):
        self.id = _id
        self.floorAmount = floorAmount


c = Column(10, 2)