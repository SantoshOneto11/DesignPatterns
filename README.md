# DesignPatterns

**A simple repository containing various Design Patterns examples built in Unity 6.**

## Table of Contents

*   [Introduction](#introduction)
*   [Patterns Implemented](#patterns-implemented)
    *   [Factory Pattern](#factory-pattern)
    *   [Flyweight Pattern](#flyweight-pattern)
    *   [Object Pooling](#object-pooling)
    *   [MV Pattern (Model-View)](#mv-pattern-model-view)
    *   [Observer Pattern](#observer-pattern)
    *   [Hotline Miami Enemy AI Behavior](#hotline-miami-enemy-ai-behavior)
*   [Getting Started](#getting-started)
*   [Documentation](#documentation)

## Introduction

This project demonstrates the use of popular design patterns in Unity to provide efficient and scalable solutions to common development challenges. Each pattern is implemented as a demo to showcase its functionality and use cases.

## Patterns Implemented

### 1. Factory Pattern
- **Description**: This pattern defines an interface for creating an object but allows subclasses to alter the type of objects that will be created. It is useful for encapsulating the instantiation logic and promoting loose coupling.
- **Demo**: See the `FactoryPattern` folder for implementation examples.

### 2. Flyweight Pattern
- **Description**: This pattern is used to minimize memory usage by sharing common data among similar objects. It is especially useful in scenarios where many similar objects are created.
- **Demo**: Check the `Flyweight` folder for the demonstration.

### 3. Object Pooling
- **Description**: This pattern is used to manage the allocation and deallocation of objects to improve performance and resource management. Instead of creating and destroying objects repeatedly, a pool of objects is maintained.
- **Demo**: Look at the `IObjectPool` folder for implementation details also there is another bonous Demo for Object Pooling for which you can find out the folder 'Poolin'.

### 4. MV Pattern (Model-View)
- **Description**: This pattern separates the representation of information from the user’s interaction with it. It enhances the organization of code and enables better maintenance and scalability.
- **Demo**: The `MVP` folder contains a simple example of this structure.

### 5. Observer Pattern
- **Description**: This pattern allows an object (the subject) to maintain a list of its dependents (observers) and notify them of state changes. It is useful for creating a subscription model where changes in one part of the system can notify other parts.
- **Demo**: See the `Observer` folder for the demonstration.

### 6. Hotline Miami Enemy AI Behavior
- **Description**: A small demo that replicates the movement patterns of enemy AI from the Hotline Miami game. It showcases behavior like patrolling, chasing, inspecting, and attacking the player.
- **Demo**: Check the `HotlineMiamiAI` folder for the implementation.

### 7. Utility
- **Description**: This section includes a custom logger that extends Unity's built-in Debug class. The custom logger provides enhanced functionality, allowing for greater flexibility and customization options over standard logging practices. Features include color-coding for different log levels and categorization options to facilitate better organization of log messages.
- **Demo**: Refer to the `Utility` folder for the implementation. You can either integrate the script into your Unity project or copy the code directly; both methods will function seamlessly.

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/DesignPatterns.git
