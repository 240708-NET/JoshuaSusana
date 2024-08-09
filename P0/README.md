# No Limit Texas Hold'em 

## Overview

This project is a C# implementation of a No Limit Texas Hold'em poker game. The game includes core features such as card dealing, hand evaluation, betting, and determining the winner based on poker hand rankings. It is designed to be a foundational implementation that can be expanded with additional features or adapted for various platforms.

## Features

- **Card Class**: Represents the data structure of a card, including suit and rank.
- **Deck Class**: Handles business logic related to deck initialization, card shuffling, and dealing.
- **HandRank Enum**: Provides an easy way to compare poker hand rankings.
- **HandEvaluator Class**: Implements game logic to evaluate poker hands, such as royal flushes and four of a kind.
- **Game Logic**: Includes betting mechanics, dealing hole cards, and managing community cards within the `Program` class.
- **Error Handling**: Manages invalid inputs and edge cases to ensure smooth gameplay.
- **User Interface**: A simple text-based interface for player interaction and game flow.

## Technologies Used

- **C#**: Core programming language used for the project.
- **.NET Framework**: Used to structure and compile the project.
- **Visual Studio**: Integrated development environment (IDE) for coding, building, and debugging.

## Getting Started

### Prerequisites

- Install **Visual Studio 2019** or later.
- Ensure the **.NET Framework** is installed on your machine.

### Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/JoshuaSusana/P0/NoLimitTexasHoldem.git
    ```
2. Open the solution file (`NoLimitTexasHoldem.sln`) in Visual Studio.
3. Build the solution to restore NuGet packages and compile the project.
4. Run the application from Visual Studio by pressing `F5` or selecting `Start Debugging`.

## Usage

- Run the program and follow the on-screen prompts to play No Limit Texas Hold'em.
- Players can bet, check, fold, or raise during their turn.
- The game evaluates hands and determines the winner based on standard poker hand rankings.

## Contributors

- **Joshua Susana** - Developer
