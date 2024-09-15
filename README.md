# Game-Inventory-System
This project aims to recreate the a Chest System using various design patterns in code.
---

## Features
- Chests has a cost. Checks for conditions when COINS / GEMS are not enough.
- Queue : Chests automatically adds themselves into a Queue for unlocking and gets triggered when the current chest timer reaches 0.
- Unlock Now  : Chests , while unlocking can be unlocked instantly using Gems.
- Undo : If Gems are accidentally spent on a chest, You can Revert that action using the Undo Button.
---

## Patterns Used
 - **ScriptableObjects** : Nested Scriptable Objects for different types of Chest Configurations (Common, Mini, Rare, Legendary).
 - **MVC Pattern**       : Implemented for Chest MVC.
 - **State Pattern**     : Customized State Machine for different Chest States (LOCKED, QUEUED, UNLOCKING, OPEN)
 - **Command Pattern**   : Customized Command Invoker to perform Undo Service.
 - **Services**          : Communicate with each other using A Service Locator to perform operations. e.g CommandService, ChestService, PopupService, AudioService etc.
---


### WorkFlow Architecture
