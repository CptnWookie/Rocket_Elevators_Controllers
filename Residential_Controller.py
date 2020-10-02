
class Column:
    def __init__(self, floorAmount, elevatorAmount):
        #print('Column : ', floorAmount, 'Floors and ', elevatorAmount, 'Elevators')
        self.floorAmount = floorAmount
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorRequestButtonList = []
        
        #print('ELEVATOR LIST :')
        i = 0
        while i < self.elevatorAmount:
            elevator = Elevator('Elevator {}'.format(i + 1))
            self.elevatorList.append(elevator)
            #print(self.elevatorList[i].id)
            i += 1
        
        #print('')
        #print('FLOOR REQUEST BUTTON LIST :')
        for i in range(10):
            floorRequestButton = FloorRequestButton(i + 1, self.floorAmount)
            self.floorRequestButtonList.append(floorRequestButton)
            #print('FloorRequestButton', self.floorRequestButtonList[i].id)

        #print('')
        #print('CALL BUTTON LIST :')
        for i in range(self.floorAmount):
            if i == 0:
                callButton = CallButton (i + 1, 'off', 'up')
                self.callButtonList.append(callButton)
                #print('CallButton up {}'.format(self.callButtonList[i].id))
            
            elif i == 9:
                callButton = CallButton(i + 1, 'down', 'off')
                self.callButtonList.append(callButton)
                #print('CallButton Down {}'.format(self.callButtonList[i].id))

            else:
                callButton = CallButton(i + 1, 'down', 'up')
                self.callButtonList.append(callButton)
                #print('CallButton Down|Up {}'.format(self.callButtonList[i].id))



        def requestElevator(floor, direction):
            #print('Request Elevator Function')
            
            self.bestElevator = self.findBestElevator(floor, direction)

            self.bestElevator.requestList.append(floor)
            self.bestElevator.moveElevator()


        def findBestElevator(floor, direction):
            i = 0
            for i in range(self.elevatorList[i]):
                if floor == self.elevatorList[i].position and self.elevatorList[i].direction == 'idle':
                    bestCase = self.elevatorList[i]
                elif direction == 'up' and (self.elevatorList[i].direction == 'up' or self.elevatorList[i].direction == 'idle') and self.elevatorList[i].position <= floor:
                    bestCase = self.elevatorList[i]
                elif direction == 'down' and (self.elevatorList[i].direction == 'down' or self.elevatorList[i].direction == 'idle') and self.elevatorList[i].position <= floor:
                    bestCase = self.elevatorList[i]

                minDistance = 999
                bestDistance = 11
                i = 0
                for i in range (self.elevatorList[i]):
                    distance = abs(self.elevatorList[i].position - floor)
                    if self.elevatorList[i].direction == 'idle' and bestDistance >= distance:
                        minDistance = distance
                        bestIdle = self.elevatorList[i]
                    
                if bestCase is not None:
                    return bestCase
                else: 
                    return bestIdle
                
       
        def requestFloor(elevator, floor):
            elevator.requestList.append(floor)
            elevator.moveElevator()
        

class Elevator:
    def __init__(self, _id):
        self.id = _id
        self.status = 'idle'
        self.position = 1
        self.direction = 'idle'
        self.floor = None
        self.doors = 'closed'
        self.requestList = []


    def moveElevator(self, position):
        previousPosition = self.position

        
        while range(self.requestList[0]) != 0:
            if self.position > self. requestList[0]:
                self.position-1

            elif self.position < self.requestList[0]:
                self.position+1

            elif self.position == self.requestList[0]:
                self.requestList.splice(0,1)

            if previousPosition is not self.position:
                previousPosition = self.position


class CallButton:
    def __init__(self, _id, floor, direction):
        self.id = _id
        self.direction = direction
        self.floor = floor

class FloorRequestButton:
    def __init__(self, _id, floorAmount):
        self.id = _id
        self.floorAmount = floorAmount


#    !!!!!   SCENARIO RESTANT À FAIRE FONCTIONNER     !!!!!    #
######################### TEST ZONE #########################


if __name__ == "__main__":

    def scenario1():
        columnScenario1 = Column(10, 2)
        print('\n -----------SCENARIO 1-----------')
        columnScenario1.elevatorList[0].position = 2
        columnScenario1.elevatorList[1].position = 6

        elevator = columnScenario1.requestElevator(3, 'up')
        elevator.requestedFloor(7)


    def scenario2():
        columnScenario2 = Column(10, 2)
        print('\n -----------SCENARIO 2-----------')
        columnScenario2.elevatorList[0].position = 10
        columnScenario2.elevatorList[1].position = 3

        elevator = columnScenario2.requestElevator(1, 'up')
        elevator.requestedFloor(6)
        elevator = columnScenario2.requestElevator(3, 'up')
        elevator.requestedFloor(5)
        elevator = columnScenario2.requestElevator(9, 'down')
        elevator.requestedFloor(2)


    def scenario3():   
        columnScenario3 = Column(10, 2)
        print('\n -----------SCENARIO 3-----------')
        columnScenario3.elevatorList[0].position = 10
        columnScenario3.elevatorList[1].position = 3
        columnScenario3.elevatorList[1].direction = 'up'
        
        elevator = columnScenario3.requestElevator(3, 'down')
        elevator.requestedFloor(2)

        columnScenario3.elevatorList[0].moveElevator(6)
        
        elevator = columnScenario3.requestElevator(10, 'down')
        elevator.requestedFloor(3)


scenario1()
scenario2()
scenario3()