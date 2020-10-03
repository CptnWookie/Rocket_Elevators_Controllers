<h4>################################ Residential_Controller ################################</h4>

To Access The JavaScript Version -----> [CLICK HERE](https://github.com/CptnWookie/Rocket_Elevators_Controllers/blob/master/Residential_Controller.js)

To Access The Python Version -----> [CLICK HERE](https://github.com/CptnWookie/Rocket_Elevators_Controllers/blob/master/Residential_Controller.py)


<h2>How-To</h2>
In order to test this code, you'll need to install the Visual Studio Code Extension called "Code Runner". Which can be found in the Extension tad on the left section of the software.

Then, if you open the Residential_Controller.js, you have access to the code itself.

Next step to be able to visualize (see bellow for examples) what this javascript does, simply click on the "Play" sign (triangle pointing to the right) located at the top of your window.

In the event that you don't see anything, make sure you select the "OUPUT" tab.

If everything works, you should see the following items being generated:

<h4>################################ Residential_Controller ################################</h4>

COLUMN INITIALIZED                                              <---- A Column has been generated.

ELEVATORS LIST                                                  <---- An Elevators List has generated with their 
                                                                      respective attributes.

CALL BUTTON LIST                                                <---- A Call Button List has been generated with their 
                                                                      respective attributes.

FLOOR REQUEST BUTTON LIST                                       <---- A Floor Request Button List has been generated with 
                                                                      their respective attributes.

-----------------------         

SCENARIO 1                                                      <---- Name of the Scenario.

/// FIRST CALL ///
  - Elevator A is Idle at floor 2.
  - Elevator B is Idle at floor 6.                              <---- Scenario 1 Information.
  - Someone is on floor 3 and wants to go to the 7th floor.
  - Elevator A is expected to be sent.
/// FIRST CALL ///

...Looking for Best Elevator...                                 <---- requestElevator Function is called.

Best Elevator identified  :  Elevator A                         <---- findBestElevator Function is called.

---> Call Button pressed on Floor 3 <---                        

Elevator A is moving up ... currently at Floor 2                <---- moveElevator function is called.

Elevator A arrived at Floor 3                                   <---- The Elevator is on the requested Floor.

---> Floor Button # 7 pressed <---                              <---- requestFloor function is called.

Elevator A is moving up ... currently at Floor 3
Elevator A is moving up ... currently at Floor 4                <---- moveElevator function is called.
Elevator A is moving up ... currently at Floor 5                      and displays each floors
Elevator A is moving up ... currently at Floor 6

Elevator A arrived at Floor 7                                   <---- the elevator has reached his destination.

-----------------------

TEST COMPLETED !!!!                                             <---- End of the TEST ZONE







