This system uses the players action to determine a "time multiplier", which can be used to determine the action speed of enemies and effects. If the player doesn't act, neither does the affected entities.

Setup:
Create a System Handler for your project (Menu: Time Multiplier/Handler)
Almost all components will need a reference to this handler.

Add a game object into your scene with a TMBrain component.

If one of your scripts need to reference the Time Multiplier, have it use the GetFirstBrain() method for a reference to the brain, and then the GetMultiplier() method of the brain.


Use:
TM2dPlayerMovement serves as an example of how the movement speed of the player can be a static value that determines the time multiplier.

The TMEvent class and its inheritors can be used to generate Scriptable Objects. Each player action/ability should have its own TMEvent. 
Call the ActivateEvent() passing a reference to the System Handler each time the ability is used. This will send the event to the TMBrain, which keeps track of it until its duration is over. 
Activating the same ability again while it's event is still active will RESTART the effect, not add a separate instance.