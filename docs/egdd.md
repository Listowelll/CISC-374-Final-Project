# Big‑O Heist — Educational Game Design Document (EGDD) v1.2

## 1. Elevator Pitch

**Big‑O Heist** is a fast‑paced educational game where players identify the Big‑O time complexity of algorithm snippets under intense time pressure—complete with an animated hacker avatar and a ticking bomb ready to explode if they hesitate too long.

---

## 2. Core Gameplay Mechanics

1. **Level Structure**

   * 3 Levels, each with 5 questions. Background and treasure chest style change per level.
   * Correct answers open the chest and play a success sound; wrong answers or time‑outs trigger a failure panel with an explanation.

2. **Time Pressure**

   * 20 seconds per question (configurable). A visible countdown and bomb shake build urgency.
   * Pause/Resume button halts both timer and animations.

3. **Instant Feedback**

   * Correct → Chest opens, “ding” SFX, 1-second delay, next question.
   * Wrong/Time-out → “buzz” SFX, failure panel overlays with textual explanation.

4. **Audio**

   * BGM looped background music.
   * SFX: click, correct ding, wrong buzz, victory fanfare.

---

## 3. Learning Objectives

* **Classify Complexity**: Accurately identify O(1), O(log n), O(n), O(n log n) from code examples.
* **Decide Under Pressure**: Make fast algorithmic judgments with a ticking clock.
* **Reinforce with Explanation**: Immediate, meaningful feedback on wrong answers deepens understanding.

---

## 4. Target Audience & Context

* **Who**: High-school CS students, undergraduates, coding-bootcamp learners, interview-prep candidates.
* **Where**: CS classrooms, coding clubs, online learning platforms, interview practice sessions.

---

## 5. Level & Scene Design

| Level   | Background Scene        | Chest Style      | Focus                           |
| ------- | ----------------------- | ---------------- | ------------------------------- |
| Level 1 | Tropical Island at Dawn | Wooden Chest     | O(1) & O(n) (constant & linear) |
| Level 2 | Jungle Ruins            | Metal Chest      | O(log n) & divide-and-conquer   |
| Level 3 | Cyber Cave              | Futuristic Chest | Sorting & advanced structures   |
| Victory | Starry Night Shore      | Golden Chest     | Full completion reward screen   |

---

## 6. User Interface Layout

1. **Start Screen**

   * Title: **WISE PIRATE – USE YOUR WEAPON: BIG‑O**
   * **START** button

2. **In-Game HUD**

   * Top-left: Pause/Resume button
   * Top-right: Countdown timer (numeric + progress bar)
   * Center: Question text + four answer buttons
   * Bottom: Treasure chest image

3. **Failure Panel (Overlay)**

   * Semi-transparent dark background
   * Title: **TREASURE HUNT FAILED**
   * Explanation text (white, readable)
   * **RESTART** button

4. **Victory Panel**

   * Title: **YOU FOUND THE TREASURE!**
   * Victory animation + **RESTART** button

---

## 7. Key Systems & Scripts

| Component     | Script             | Responsibility                                      |
| ------------- | ------------------ | --------------------------------------------------- |
| Game Flow     | GameManager.cs     | Level progression, question loading, chest control  |
| UI Rendering  | UIManager.cs       | Display question/options, highlight answer result   |
| Timer         | TimerController.cs | Countdown logic, pause/resume, timeout detection    |
| Failure Panel | FailPanel.cs       | Show explanation, handle restart/close              |
| Chest UI      | SimpleChestUI.cs   | Swap chest sprites (closed/open)                    |
| Audio         | AudioManager.cs    | Play BGM, SFX (correct, wrong, victory)             |
| Data Model    | QuestionData.cs    | Holds question, options, correct index, explanation |

---

## 8. Sample Question Data

```csharp
new QuestionData {
  question     = "What is the Big‑O of linear search?",
  options      = new[] { "O(1)", "O(log n)", "O(n)", "O(n log n)" },
  correctIndex = 2,
  explanation  = "Linear search checks each element once, so the time grows linearly ⇒ O(n)."
},
```

Total: 15 questions. Difficulty ramps from O(1)/O(n) up to O(n log n) and advanced topics.

---

## 9. Interaction Flow

1. **Press START**

   * Hide the start screen
   * Show the in-game HUD

2. **New Question**

   * Close the chest (swap to closed sprite)
   * Reset timer to 20 seconds
   * Display question text and four answer buttons

3. **Player Answers**

   * **Correct**

     1. Play “ding” SFX
     2. Open the chest (swap to open sprite)
     3. Wait 1 second, then load the next question or advance level
   * **Wrong** or **Timeout**

     1. Play “buzz” SFX
     2. Show Failure Panel with explanation text

4. **RESTART** (in Failure or Victory Panel)

   * Reload the scene back to the Start Screen

5. **After Level 3 Completion**

   * Show Victory Panel
   * Play victory fanfare SFX

---

## 10. Art & Audio Assets

| Asset Type      | Filename(s)                                                            | Path              |
| --------------- | ---------------------------------------------------------------------- | ----------------- |
| Backgrounds     | `BG_Level1.png`, `BG_Level2.png`, `BG_Level3.png`                      | `Assets/Sprites/` |
| Treasure Chests | `chest_closed.png`, `chest_open.png`                                   | `Assets/Sprites/` |
| UI Panels       | `Start_BG.png`, `Fail_BG.png`, `Victory_BG.png`                        | `Assets/Sprites/` |
| Music (BGM)     | `bgm_loop.mp3`                                                         | `Assets/Audio/`   |
| Sound Effects   | `sfx_click.wav`, `sfx_correct.wav`, `sfx_wrong.wav`, `sfx_victory.wav` | `Assets/Audio/`   |

---

## 11. Future Extensions

* **Practice Mode**

  * Unlimited time per question
  * No failure (informational feedback only)

* **Leaderboard**

  * Track top players by speed and accuracy
  * Support daily, weekly, and all-time rankings

* **Multiplayer Race**

  * Real-time head-to-head Big-O challenges
  * First correct answer wins the round

* **Mobile Support**

  * Responsive touch-friendly UI
  * Adaptive layouts for various aspect ratios
