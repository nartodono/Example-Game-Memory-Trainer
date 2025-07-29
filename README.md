# Example Game Memory Trainer

## ⚠️ Read This

**WARNING:**  
This project is intended for **educational and research purposes only**.  
Do **not** use it to cheat in online/multiplayer games or violate any game's ToS (Terms of Service).  
**Use responsibly and ethically!**

---

## 🧑‍💻 Introduction

This repository demonstrates how to build a **game memory trainer** in C# (WinForms), focusing on real process memory editing in Windows.  
The example uses *Supermarket Simulator v1.0.2 (133)* as the demo target

---

## ✨ Features

- **Automatic game process detection**
- **Edit in-game Money, EXP, and Level** via a simple UI
- **Freeze Money:** lock the value so it never decreases
- Clean, readable, and well-commented code for easy learning
- Great starting point for anyone interested in game hacking, trainers, or the Windows API with C#

---

## 🚀 How to Use

1. **Clone this repository to your computer:**
    ```bash
    git clone https://github.com/nartodono/Example-Game-Memory-Trainer.git
    ```

2. **Open the project folder:**  
   (By default, it will be named `Example-Game-Memory-Trainer`.)

3. **Open `Trainer.sln` using Visual Studio.**

4. **Build and run the project:**  
   - Click the **Start** button or press `F5` in Visual Studio.

5. **Start _Supermarket Simulator v1.0.2 (133)_** on your PC.

6. **Use the trainer app:**  
   The trainer will automatically detect the running game and let you edit Money, EXP, Level, or freeze the money value in real time.

---

> **Please Note:**  
> - This trainer is designed and tested for *Supermarket Simulator v1.0.2 (133)*.  
> - It may **not** work for other versions of the game since those versions have not been tested yet.

---

## Learning Section

You can see the main code logic here:  
[**Form1.cs**](Trainer/Form1.cs)  
You can ignore the other files—those are mostly auto-generated or boilerplate needed to make the program run in Visual Studio.

---

### 🧠 How Does It Work?

This trainer works by accessing the memory of another application (the game), reading, and modifying its values.

1. **Process Detection:**  
   The program first searches for the *Supermarket Simulator* process. It continuously checks every second, so it always knows if the game is open or not.

2. **Pointer Chain Traversal:**  
   If the process is found, the trainer locates the memory addresses for **Money, EXP, and Level** by following a multi-level pointer chain.  
   These pointer chains were discovered using Cheat Engine.  
   *(See the section below: [How to Find the Pointer Chain](#how-to-find-the-pointer-chain))*

3. **Reading & Modifying Memory:**  
   Once the addresses are found, the trainer can read or write the values in real-time.

4. **Why Use a Pointer Chain?**  
   The pointer chain is needed because the actual memory addresses change every time the game starts (dynamic memory allocation). The chain lets us always find the right spot, no matter what address is used this session.

---

### 🖼️ Screenshots

| ![Inactive Trainer](docs/images/unactiveTrainer.png) | ![Active Trainer](docs/images/activeTrainer.png) |
|:--:|:--:|
| *Inactive Trainer* | *Active Trainer* |

![In-game](docs/images/in-game.png)

### How to find the Pointer Chain
