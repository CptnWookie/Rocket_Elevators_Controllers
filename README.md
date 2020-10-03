################################ Residential_Controller ################################

To Access The JavaScript Version -----> CLICK HERE

To Access The Python Version -----> CLICK HERE

In order to test this code, you'll need to install the Visual Studio Code Extension called "Code Runner". Which can be found in the Extension tad on the left section of the software.

Then, if you open the Residential_Controller.js, you have access to the code itself.

Next step to be able to visualize (see bellow for examples) what this javascript does, simply click on the "Play" sign (triangle pointing to the right) located at the top of your window.

In the event that you don't see anything, make sure you select the "OUPUT" tab.

If everything works, you should see the following items being generated:

################################ Residential_Controller ################################

(tables only displayed in JavaScript)

COLUMN INITIALIZED        <------ A Column has been generated.

ELEVATORS LIST            <------ An Elevators List has generated with their respectives attributes.
┌─────────┬─────────────┬────────┬──────────┬───────────┬───────┬──────────┬─────────────┐
│ (index) │     id      │ status │ position │ direction │ floor │  doors   │ requestList │
├─────────┼─────────────┼────────┼──────────┼───────────┼───────┼──────────┼─────────────┤
│    0    │ 'elevator1' │ 'idle' │    1     │  'none'   │  10   │ 'closed' │     []      │
│    1    │ 'elevator2' │ 'idle' │    1     │  'none'   │  10   │ 'closed' │     []      │
└─────────┴─────────────┴────────┴──────────┴───────────┴───────┴──────────┴─────────────┘
CALL BUTTON LIST          <------ A Call Button List has been generated with their respectives attributes.
┌─────────┬────────────────────┬───────────┬───────┐
│ (index) │         id         │ direction │ floor │
├─────────┼────────────────────┼───────────┼───────┤
│    0    │  'callButtonUP1'   │   'up'    │   1   │
│    1    │ 'callButtonDOWN2'  │  'down'   │   2   │
│    2    │  'callButtonUP2'   │   'up'    │   2   │
│    3    │ 'callButtonDOWN3'  │  'down'   │   3   │
│    4    │  'callButtonUP3'   │   'up'    │   3   │
│    5    │ 'callButtonDOWN4'  │  'down'   │   4   │
│    6    │  'callButtonUP4'   │   'up'    │   4   │
│    7    │ 'callButtonDOWN5'  │  'down'   │   5   │
│    8    │  'callButtonUP5'   │   'up'    │   5   │
│    9    │ 'callButtonDOWN6'  │  'down'   │   6   │
│   10    │  'callButtonUP6'   │   'up'    │   6   │
│   11    │ 'callButtonDOWN7'  │  'down'   │   7   │
│   12    │  'callButtonUP7'   │   'up'    │   7   │
│   13    │ 'callButtonDOWN8'  │  'down'   │   8   │
│   14    │  'callButtonUP8'   │   'up'    │   8   │
│   15    │ 'callButtonDOWN9'  │  'down'   │   9   │
│   16    │  'callButtonUP9'   │   'up'    │   9   │
│   17    │ 'callButtonDOWN10' │  'down'   │  10   │
└─────────┴────────────────────┴───────────┴───────┘
FLOOR REQUEST BUTTON LIST <------ A Floor Request Button List has been generated with their respectives attributes.
┌─────────┬─────────────────┬─────────────┐
│ (index) │       id        │ floorAmount │
├─────────┼─────────────────┼─────────────┤
│    0    │ 'floorButton1'  │      1      │
│    1    │ 'floorButton2'  │      2      │
│    2    │ 'floorButton3'  │      3      │
│    3    │ 'floorButton4'  │      4      │
│    4    │ 'floorButton5'  │      5      │
│    5    │ 'floorButton6'  │      6      │
│    6    │ 'floorButton7'  │      7      │
│    7    │ 'floorButton8'  │      8      │
│    8    │ 'floorButton9'  │      9      │
│    9    │ 'floorButton10' │     10      │
└─────────┴─────────────────┴─────────────┘

-----------------------         

SCENARIO 1                                                      <---- Name of the Scenario.

/// FIRST CALL ///
  - Elevator A is Idle at floor 2.
  - Elevator B is Idle at floor 6.                              <---- Scenario 1 Informations.
  - Someone is on floor 3 and wants to go to the 7th floor.
  - Elevator A is expected to be sent.
/// FIRST CALL ///

...Looking for Best Elevator...                                 <---- requestElevator Function is called.

Best Elevator identified  :  Elevator A                         <---- findBestElevator Function is called.

---> Call Button pressed on Floor 3 <---                        

Elevator A is moving up ... currently at Floor 2                <---- moveElevator function is called.

Elevator A arrived at Floor 3                                   <---- The elevater is on the Call Button Floor.

---> Floor Button # 7 pressed <---                              <---- requestFloor function is called.

Elevator A is moving up ... currently at Floor 3
Elevator A is moving up ... currently at Floor 4                <---- moveElevator function is called.
Elevator A is moving up ... currently at Floor 5                      and displays each floors
Elevator A is moving up ... currently at Floor 6

Elevator A arrived at Floor 7                                   <---- the elevator has reached his destination.

-----------------------

TEST COMPLETED !!!!                                             <---- End of the TEST ZONE







