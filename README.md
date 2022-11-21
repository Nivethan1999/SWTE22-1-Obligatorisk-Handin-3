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

## Links
[Overleaf](https://www.overleaf.com/1737167548rmbtcmxshxtp)

