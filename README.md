
# 🐦 ML-Agents Flappy Bird | AI Playing Flappy Bird in Unity



> An experimental project using **Unity + ML-Agents Toolkit** to train an AI agent capable of playing a simplified version of the classic **Flappy Bird** game.

---

## 🎯 Purpose

The goal of this project is to explore **Machine Learning applied to games**, using **Reinforcement Learning** to teach an AI agent how to play Flappy Bird autonomously.

This is an **educational project focused on learning, experimentation, and AI development within game environments**, using Unity's **ML-Agents Toolkit**.

---

## 🔥 Features

- ✅ Fully functional Flappy Bird environment built in Unity.
- ✅ AI agent implemented with ML-Agents.
- ✅ Reward system to train the agent to jump at the right moments.
- ✅ Training configuration files (.yaml).
- ✅ Training monitoring with TensorBoard.
- ✅ Documented common errors, challenges, and solutions encountered during the process.

---

## 🚧 Project Status

> 🔧 **Work in progress and continuously improving.**  
The agent has learned the basic behaviors but is still being trained to improve performance.

---

## 💡 Key Learnings & Challenges

During development, I faced several challenges, including:

- ⚙️ **Version conflicts** between ML-Agents, Python, and Unity.
- 🐍 Environment setup issues with virtual environments and terminal variables.
- 🔧 Frequent dependency errors and API connection issues.
- 🧠 Fine-tuning hyperparameters and deeply understanding reinforcement learning in practice.

All steps are documented to help others on this journey.

---

## 🧠 Technologies & Tools

- 🎮 **Unity** (recommended version in `/docs`)
- 🤖 **ML-Agents Toolkit**
- 🐍 **Python 3.10.9**
- 📊 **TensorFlow** + **TensorBoard**
- 🔗 Homebrew (MacOS) or equivalent package managers
- 💻 Terminal (UNIX-based or Windows equivalent)

---

## 🚀 Getting Started

### 🔥 Prerequisites:

- Unity (check recommended version in `/docs`)
- Python 3.10.9 installed
- ML-Agents installed via pip

### 💻 Installation:

1. Clone this repository:  
```bash
git clone https://github.com/DanielaDoliveira/flappy-bird-machine-learning
```

2. Open the project folder in Unity.

3. Set up a Python virtual environment:  
```bash
python -m venv flappy-env
source flappy-env/bin/activate  # (Mac/Linux)  
flappy-env\Scripts\activate   # (Windows)
```

4. Install ML-Agents:  
```bash
pip install mlagents
```

5. Open the Unity project.

6. Start training from the terminal:  
```bash
mlagents-learn flappy-config.yaml --run-id=FlappyRun
```

7. Press **Play** in Unity to connect the environment.

---


## 🐞 Known Issues

- ⚠️ Training can be slow on machines without a dedicated GPU.
- ⚠️ Version conflicts between Unity and ML-Agents are common. Check the official compatibility guide [here](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md).

---

## ✨ Contributing

Feel free to open **Issues**, suggest improvements, or submit **Pull Requests**! 🚀

---

## 📝 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---
