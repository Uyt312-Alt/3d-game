# Setup Guide

## How to Import into Unity

1. Download `Source code (zip)` from the [Releases](https://github.com/Uyt312-Alt/3d-game/releases) page.
2. Extract the zip — you will get a folder called `3d-game-v1.0.0`.
3. Open **Unity Hub** → click **Open** → browse to that extracted folder → click **Open**.
4. Unity will import the project. Use **Unity 2022.3 LTS** or newer.
5. In the Project window, go to `Assets/Scenes/` and open `MainScene`.
6. Press **Play** to test.

## Scene Setup Checklist
- [ ] Create Player capsule: add `CharacterController`, `PlayerMovement`, `ParkourController`, `PlayerHealth`
- [ ] Add child Camera with `FirstPersonCamera` script
- [ ] Add child sword mesh with `PlayerCombat` script
- [ ] Create Enemy prefabs: add `NavMeshAgent`, `EnemyAI`, `EnemyHealth`, tag as `Enemy`
- [ ] Bake NavMesh: Window → AI → Navigation
- [ ] Add Canvas UI Slider, wire up `HealthUI`
