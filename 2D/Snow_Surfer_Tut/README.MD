# 🏂 Snow Surfer - 2D

![Unity Version](https://img.shields.io/badge/Unity-6-lightgrey)
![C#](https://img.shields.io/badge/Language-C%23-blue)
![License](https://img.shields.io/badge/License-MIT-green)

**Snow Surfer** is a 2D physics-based side-scrolling game built in Unity. The goal is to carve down the mountain slopes, land sick flips, and reach the finish line without crashing your head into the snow!

This project is part of a GameDev 2D course tutorial, heavily focusing on Unity's physics engine, applying forces, and triggering visual effects.

---

## 🎮 Gameplay Highlights

- **Physics-Driven Movement:** Utilizes Unity's `SurfaceEffector2D` for smooth sliding and momentum building across the snowy terrain.
- **Trick System:** Apply torque to rotate the character in mid-air to perform flips.
- **Crash Mechanics:** Precision head collision detection that instantly triggers a wipeout and reloads the level.
- **Visual Polish:** Integrated Unity Particle Systems for realistic snow trails while riding and impact effects upon crashing.

---

## 🛠️ Technologies & Concepts Used

- **Engine:** Unity 6
- **Language:** C#
- **Key Concepts Learned:**
  - `Rigidbody2D.AddTorque()` for rotational movement in mid-air.
  - `SurfaceEffector2D` for frictionless, directional movement along terrain.
  - Playing and controlling **Particle Systems** via C# scripts.
  - `OnCollisionEnter2D` and `OnTriggerEnter2D` for finish lines and crash detection.
  - `SceneManager` to reload the current level upon a wipeout.

---

## 🕹️ Controls

| Action | Key Binding |
| :--- | :--- |
| **Lean Back (Rotate Left)** | `Left Arrow` or `A` |
| **Lean Forward (Rotate Right)** | `Right Arrow` or `D` |
| **Speed Boost** | `Up Arrow` or `W` |
| **Go Down** | `Down Arrow` or `S` |

---

## 🚀 Installation & Setup

To run this project locally on your machine:

1. Clone this repository:
   ```bash
   git clone [https://github.com/IshitvaPandeyDev/GameDev-Courses.git](https://github.com/IshitvaPandeyDev/GameDev-Courses.git)
   ```
2. Open **Unity Hub**.
3. Click on **Open** -> **Add project from disk**.
4. Navigate to the `2D/Snow-Surfer-Tut` folder inside the cloned repository and select it.
5. Open the `Level1` scene located in the `Assets/Scenes` folder.
6. Press the **Play** button at the top of the Unity Editor to test the game!

---

## 👨‍💻 Author

**Ishitva Pandey**
- GitHub: [@IshitvaPandeyDev](https://github.com/IshitvaPandeyDev)

*This project is based on 2D Game Development coursework and tutorials.*
