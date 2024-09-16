# CHEST-SYSTEM
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

## PROJECT SCREENSHOTS
![Screenshot 2024-09-16 200329](https://github.com/user-attachments/assets/c5377563-533a-4c22-b605-f2d7d2ca32bb)
![Screenshot 2024-09-16 200349](https://github.com/user-attachments/assets/e1e13b7a-6627-4ca1-98ad-884bb893229a)
![Screenshot 2024-09-16 200428](https://github.com/user-attachments/assets/67475ab5-a955-43c6-be6f-8d27432ae597)
---

## GamePlay Video
https://github.com/user-attachments/assets/7e10f6c3-83b1-4eec-a8bf-0cc486d0d880
