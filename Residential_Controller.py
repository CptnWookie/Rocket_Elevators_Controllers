
class Column:
    def __init__(self, floorAmount, elevatorAmount):
        print('Column : ', floorAmount, 'Floors and', elevatorAmount, 'Elevators')
        self.floorAmount = floorAmount
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorRequestButtonList = []
    
        
        print('\nELEVATOR LIST :')
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


    def requestElevator(self, floor, direction):
        
        print('...Looking for Best Elevator...\n')

        self.bestElevator = self.findBestElevator(floor, direction)

        print('Best Elevator identified  :  Elevator {}'.format(self.bestElevator.id))
        print('\n---> Call Button pressed on Floor {}'.format(floor), '<---\n')

        self.bestElevator.requestList.append(floor)
        self.bestElevator.moveElevator(floor)
        
        return self.bestElevator


    def findBestElevator(self, floor, direction):
        #print('Find Best Elevator')
        
        bestCase = None
        for i in range(len(self.elevatorList)):

            if floor == self.elevatorList[i].position and self.elevatorList[i].direction == 'idle':
                bestCase = self.elevatorList[i]

            elif direction == 'up' and (self.elevatorList[i].direction == 'up' or self.elevatorList[i].direction == 'idle') and self.elevatorList[i].position <= floor:
                bestCase = self.elevatorList[i]

            elif direction == 'down' and (self.elevatorList[i].direction == 'down' or self.elevatorList[i].direction == 'idle') and self.elevatorList[i].position <= floor:
                bestCase = self.elevatorList[i]

        minDistance = 999
        bestDistance = 11
        
        bestIdle = None
        for i in range(len(self.elevatorList)):
            distance = abs(self.elevatorList[i].position - floor)
            if self.elevatorList[i].direction == 'idle' and bestDistance >= distance:
                minDistance = distance
                bestIdle = self.elevatorList[i]
            

        if bestCase is not None:
            return bestCase
        else: 
            return bestIdle
            
       
    def requestFloor(self, elevator, floor):
        print('\n---> Floor Button #', floor, "pressed <---\n")
        elevator.requestList.append(floor)
        elevator.moveElevator(floor)
        

class Elevator:
    def __init__(self, _id):
        #print('Elevator : ')
        self.id = _id
        self.status = 'idle'
        self.position = 1
        self.direction = 'idle'
        self.floor = None
        self.doors = 'closed'
        self.requestList = []


    def moveElevator(self, position):
        previousPosition = self.position
        elevatorStatus = self.status
        elevatorDirection = self.direction
        
        
        while len(self.requestList) != 0:
            if self.position > self.requestList[0]:
                print('Elevator', self.id, 'is moving down ... currently at Floor', self.position)
                elevatorStatus = 'moving'
                elevatorDirection = 'down'
                self.status = elevatorStatus
                self.direction = elevatorDirection
                self.position -= 1

            elif self.position < self.requestList[0]:
                print('Elevator', self.id, 'is moving up ... currently at Floor', self.position)
                elevatorStatus = 'moving'
                elevatorDirection = 'up'
                self.status = elevatorStatus
                self.direction = elevatorDirection
                self.position += 1

            elif self.position == self.requestList[0]:
                elevatorStatus = 'idle'
                elevatorDirection = 'idle'
                print('\nElevator', self.id, 'arrived at Floor', self.position)
                del self.requestList[0]

                return self.status, self.direction

            if previousPosition is not self.position:
                previousPosition = self.position


class CallButton:
    def __init__(self, _id, floor, direction):
        #print('Call Button')
        self.id = _id
        self.direction = direction
        self.floor = floor

class FloorRequestButton:
    def __init__(self, _id, floorAmount):
        #print('Floor Request Button')
        self.id = _id
        self.floorAmount = floorAmount



######################### TEST ZONE #########################
column = Column(10, 2)
if __name__ == "__main__":
    
    def scenario1():
        print('\n-----------------------\n')
        print('SCENARIO 1\n')
        column.elevatorList[0].id = "A"
        column.elevatorList[0].position = 2
        column.elevatorList[0].direction = 'idle'
        column.elevatorList[0].status = 'idle'
        column.elevatorList[0].floor = 3
        column.elevatorList[1].id = "B"
        column.elevatorList[1].position = 6
        column.elevatorList[1].direction = 'idle'
        column.elevatorList[1].status = 'idle'
        column.elevatorList[1].floor = 3
        
        print("/// FIRST CALL ///")
        print("  - Elevator A is Idle at floor 2.")
        print("  - Elevator B is Idle at floor 6.")
        print("  - Someone is on floor 3 and wants to go to the 7th floor.")
        print("  - Elevator A is expected to be sent.")
        print("/// FIRST CALL ///\n")    
        elevator = column.requestElevator(3, 'up')
        column.requestFloor(elevator, 7)


    def scenario2():
        
        print('\n-----------------------\n')
        print('SCENARIO 2\n')
        column.elevatorList[0].id = "A"
        column.elevatorList[0].position = 10
        column.elevatorList[0].direction = 'idle'
        column.elevatorList[0].status = 'idle'
        column.elevatorList[0].floor = 1
        column.elevatorList[1].id = "B"
        column.elevatorList[1].position = 3
        column.elevatorList[1].direction = 'idle'
        column.elevatorList[1].status = 'idle'
        column.elevatorList[1].floor = 1

        print("/// FIRST CALL ///")
        print("  - Elevator A is Idle at floor 10.")
        print("  - Elevator B is idle at floor 3")
        print("  - Someone is on the 1st floor and requests the 6th floor.")
        print("  - Elevator B should be sent.")
        print("/// FIRST CALL ///\n")
        elevator = column.requestElevator(1, 'up')
        column.requestFloor(elevator, 6)

        print("\n/// SECOND CALL ///")
        print("  - 2 minutes later, someone else is on the 3rd floor and requests the 5th floor.")
        print("  - Elevator B should be sent.")
        print("/// SECOND CALL ///\n")
        column.elevatorList[1].position = 6
        column.elevatorList[1].direction = 'idle'
        column.elevatorList[1].status = 'idle'
        elevator = column.requestElevator(3, 'up')
        column.requestFloor(elevator, 5)

        print("\n/// THIRD CALL ///")
        print("  - Finally, a third person is at floor 9 and wants to go down to the 2nd floor.")
        print("  - Elevator A should be sent.")
        print("/// THIRD CALL ///\n")
        column.elevatorList[0].position = 10
        column.elevatorList[0].direction = 'idle'
        column.elevatorList[0].status = 'idle'
        elevator = column.requestElevator(9, 'down')
        column.requestFloor(elevator, 2)


    def scenario3():   
        
        print('\n-----------------------\n')
        print('SCENARIO 3\n')
        column.elevatorList[0].id = "A"
        column.elevatorList[0].position = 10
        column.elevatorList[0].direction = 'idle'
        column.elevatorList[0].status = 'idle'
        column.elevatorList[0].floor = 3
        column.elevatorList[1].id = "B"
        column.elevatorList[1].position = 3
        column.elevatorList[1].requestList = [6]
        column.elevatorList[1].direction = 'up'
        column.elevatorList[1].status = 'moving'
        column.elevatorList[1].floor = 6
        
        print("/// FIRST CALL ///")
        print("  - Elevator A is Idle at floor 10.")
        print("  - Elevator B is Moving from floor 3 to floor 6.")
        print("  - Someone is on floor 3 and requests the 2nd floor.")
        print("  - Elevator A should be sent.")
        print("/// FIRST CALL ///\n")
        elevator = column.requestElevator(3, 'down')
        column.requestFloor(elevator, 2)

        print("\n/// SECOND CALL ///")
        print("  - 5 minutes later, someone else is on the 10th floor and wants to go to the 3rd.")
        print("  - Elevator B should be sent.")
        print("/// SECOND CALL ///\n")
        column.elevatorList[1].position = 6
        column.elevatorList[1].direction = 'idle'
        column.elevatorList[1].status = 'idle'
        elevator = column.requestElevator(10, 'down')
        column.requestFloor(elevator, 3)


        print("\n\n\n!!!!!!!!!!! TEST COMPLETED !!!!!!!!!!!")

scenario1()
scenario2()
scenario3()    