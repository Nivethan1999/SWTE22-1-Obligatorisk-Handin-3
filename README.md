# SWTE22-1-Obligatorisk-Handin-3

ClassDiagram of the MicrowaveOven handout
```mermaid
classDiagram
CookController<-->UserInterface
CookController<-->Timer
CookController-->PowerTube
CookController-->Display
UserInterface-->Display
UserInterface-->Light
UserInterface..>Button
UserInterface..>Door
UserInterface<--Button
UserInterface<--Door
Light-->Output
Display-->Output
PowerTube-->Output
```

ClassDiagram with the Buzzer added
```mermaid
classDiagram
CookController<-->UserInterface
CookController<-->Timer
CookController-->PowerTube
CookController-->Display
UserInterface-->Buzzer
UserInterface-->Display
UserInterface-->Light
UserInterface..>Button
UserInterface..>Door
UserInterface<--Button
UserInterface<--Door
Light-->Output
Display-->Output
PowerTube-->Output
Buzzer-->Output
```


SequenceDIagram with the Powertube power configurable
```mermaid
sequenceDiagram
    Program->>CookController: new Powertube(output,1000)
    User->>PowerButton: Press Power Button
    PowerButton->>UserInterface: OnPowerPressed()
    UserInterface->>CookController: GetMaximumPower()

   


```


Sequence diagram of buzzer feature
```mermaid
sequenceDiagram

participant C as Cook Controller
participant B as Buzzer
participant O as Output

C->>C: CookingIsDone()
C->>B: Buzz()
B->>O: OutputLine()

```

SequenceDiagram for TimeCooking
```mermaid
sequenceDiagram
        UserInterFace->>CookController: addTimer()
        CookController->>+Timer: setTimer()
        CookController->>+Display: ShowTimer()
        Display->>+Output: LogLine()
    
```

SequenceDiagram for secondButton
```mermaid
sequenceDiagram
    User-)secondButton Button: User press second button
        activate secondButton Button
    secondButton Button->>UserInterface:  OnTimeSecondPressed()
    activate UserInterface
    alt state = SETPOWER
    UserInterface->>UserInterface: Change state to SETTIME
    else state = SETTIME
    UserInterface->>UserInterface: Increment time
    else state = COOKING
    UserInterface->>CookController: addTimer()
    deactivate secondButton Button
        CookController->>Timer: Set timeRemaining 

    end
    UserInterface-)Display:  ShowTime()
    Display-)Ouput: LogLine()
```

#State machine of the user interface
```mermaid
stateDiagram-v2 
Ready: Ready
SetPower: Set Power
SetTime: Set Time
Cooking: Cooking
DoorOpen: Door Opened

% Ready
[*] --> Ready
Ready --> SetPower :Press Powerbutton /</br> Display Power

Ready --> DoorOpen: DoorOpens/</br>Turn On Light


% SetPower
SetPower --> SetTime: Time button pressed /</br> Display time

SetPower --> Ready :Start-Cancel Button Pressed / </br> Reset Values,</br> Clear Display

SetPower --> SetPower: Press Power Button/</br> Increase Power,</br> Display Power

SetPower --> DoorOpen: DoorIsOpened/ </br> Reset Values,</br> Clear Display,</br> Turn On Light


% SetTime
SetTime --> Cooking: Start-Cancel Button Pressed/</br>Start Cooking,</br> Turn On Light

SetTime --> SetTime: TimeButtonPressed/</br> Increase Time,</br> Display Time

SetTime --> DoorOpen: DoorIsOpened/ </br>Reset Values,</br> Clear Display,</br> Turn On Light


% Cooking
Cooking --> Ready: Cooking Finished/</br> Reset Values,</br> Clear Display,</br> TurnOffLight

Cooking --> Ready: Start-Cancel Button Pressed/</br> Stop Cooking,</br>Reset Values,</br>Clear Display,</br> TurnOffLight

Cooking --> DoorOpen: DoorIsOpened/ </br>Stop Cooking,</br> Reset Values,</br> Clear Display

Cooking --> Cooking: TimeButtonPressed/ </br> increased timeRemaining


% DoorOpen
DoorOpen --> Ready: DoorIsClosed/</br>Turn Off Light


```

## Links
[Overleaf](https://www.overleaf.com/1737167548rmbtcmxshxtp)

