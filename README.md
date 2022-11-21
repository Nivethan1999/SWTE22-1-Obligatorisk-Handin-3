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
    Program->> CookController: new Powertube(output,1000)
    UserInterface->>CookController: StartCooking()
    activate CookController
    CookController->> Timer: Start()
    CookController ->>PowerTube:  TurnOn(power)
    deactivate CookController
    activate PowerTube
    PowerTube ->>Output: Logline()
    deactivate PowerTube
    Timer->> CookController: OnTimerExpired()
    activate CookController
    CookController->> PowerTube: TurnOff()
    activate PowerTube
    PowerTube->> Output: Logline()
    deactivate PowerTube
    CookController->> UserInterface: CookingIsDone()
    deactivate CookController


```



Sequence diagram of buzzer feature

place sequence diagram here



#State machine of the user interface
```mermaid
stateDiagram-v2 
%%{init: {'themeVariables': { 'fontSize': '0.8rem'}}}%%
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

