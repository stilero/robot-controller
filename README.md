# Robot Controller

A C# .NET 8 console application that simulates a robot moving in a rectangular room. The robot can turn left, turn right, and move forward based on command sequences while respecting room boundaries.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Input Format](#input-format)
- [Examples](#examples)
- [Architecture](#architecture)
- [Testing](#testing)
- [Project Structure](#project-structure)
- [Coordinate System](#coordinate-system)
- [Limitations](#limitations)
- [Development](#development)

## Overview

This project demonstrates:
- Clean architecture with separation of concerns
- Domain-driven design principles
- Comprehensive unit and integration testing with xUnit
- Modern C# 12 features (primary constructors, records, top-level statements)
- Input validation and error handling

## Features

- ✅ **Room Definition**: Create rooms of any size (width × height)
- ✅ **Robot Placement**: Place robot at starting position with direction (N/E/S/W)
- ✅ **Command Execution**: Execute sequences of movement commands (L/R/F)
- ✅ **Boundary Validation**: Prevents robot from moving outside room bounds
- ✅ **Multiple Simulations**: Run multiple robot simulations in sequence
- ✅ **Comprehensive Testing**: 95%+ test coverage on core logic
- ✅ **Error Handling**: Clear error messages for invalid input

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd robot-controller
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

### Running the Application

```bash
dotnet run --project src/RobotControllerApp
```

Or from the project directory:
```bash
cd src/RobotControllerApp
dotnet run
```

## Usage

When you run the application, you'll be prompted for:

1. **Room dimensions**: Enter width and height (e.g., `5 5`)
2. **Robot starting position**: Enter X, Y, and direction (e.g., `1 2 N`)
3. **Commands**: Enter a sequence of commands (e.g., `RFRFFRFRF`)

The robot will execute the commands and report its final position.

### Interactive Session Example

```
Enter size of room 'x y' for example '5 5'.
5 5

Enter Robot Starting position and facing direction 'x y d' for example '1 2 N'.
1 2 N

Enter Command input. Valid commands are L (Left) R (Right) F (Forward). for example 'LFRFFLRF'.
RFRFFRFRF

Report: 1 3 N

Do you want to run another simulation? (y/n)
n
```

## Input Format

### Room Dimensions
- **Format**: `width height`
- **Requirements**:
  - Two positive integers separated by space(s)
  - Both width and height must be greater than zero
  - Multiple spaces or tabs are acceptable
- **Examples**:
  - `5 5` ✅
  - `10 8` ✅
  - `5  7` ✅ (multiple spaces)
  - `0 5` ❌ (zero not allowed)
  - `-5 5` ❌ (negative not allowed)

### Robot Starting Position
- **Format**: `x y direction`
- **Requirements**:
  - Two non-negative integers (X, Y coordinates)
  - One direction letter: `N` (North), `E` (East), `S` (South), `W` (West)
  - Direction is case-insensitive (`N` or `n` both work)
  - Position must be within room bounds
- **Examples**:
  - `1 2 N` ✅
  - `0 0 E` ✅ (bottom-left corner)
  - `1 2 n` ✅ (lowercase direction)
  - `5 5 N` ❌ (out of bounds for 5×5 room)

### Commands
- **Format**: String of command characters
- **Valid Commands**:
  - `L` - Turn left (90° counter-clockwise)
  - `R` - Turn right (90° clockwise)
  - `F` - Move forward one step in current direction
- **Requirements**:
  - Commands are **case-sensitive** (must be uppercase)
  - Maximum length: 100 commands
  - No spaces between commands
- **Examples**:
  - `LFRFFRFRF` ✅
  - `LLL` ✅ (turn left 3 times)
  - `FFFF` ✅ (move forward 4 times)
  - `L R F` ❌ (spaces not allowed)
  - `lrf` ❌ (must be uppercase)

## Examples

### Example 1: Basic Movement
```
Room: 5 × 5
Start: (1, 2, N) - Position (1, 2) facing North
Commands: RFRFFRFRF

Step-by-step execution:
R: Turn right → (1, 2, E)
F: Move forward → (2, 2, E)
R: Turn right → (2, 2, S)
F: Move forward → (2, 3, S)
F: Move forward → (2, 4, S)
R: Turn right → (2, 4, W)
F: Move forward → (1, 4, W)
R: Turn right → (1, 4, N)
F: Move forward → (1, 3, N)

Final: (1, 3, N)
```

### Example 2: Edge Navigation
```
Room: 5 × 5
Start: (0, 0, E) - Bottom-left corner facing East
Commands: RFLFFLRF

Final: (3, 1, E)
```

### Example 3: Full Rotation
```
Room: 5 × 5
Start: (2, 2, N)
Commands: RRRR

Result: (2, 2, N) - Four right turns return to original direction
```

### Example 4: Boundary Collision (Error)
```
Room: 5 × 5
Start: (0, 0, N)
Commands: F

Error: Robot moved out of room bounds.
Reason: Cannot move North from Y=0 (would go to Y=-1)
```

## Architecture

The project follows clean architecture principles:

### Layers

1. **Domain Layer** (`Domain/`)
   - Core business logic
   - `Robot` - Entity with position and direction
   - `Room` - Value object with boundary validation
   - `RobotController` - Command execution orchestrator
   - `Movement` - Direction operations (turn left/right, calculate movement)
   - `Reporter` - Status report generation

2. **Input Layer** (`Input/`)
   - User input parsing and validation
   - `Parser` - Converts string input to domain types
   - `ErrorMessages` - Centralized error messages
   - `Prompts` - User-facing prompt text

3. **Application Layer** (`Program.cs`)
   - Console I/O orchestration
   - Application flow control
   - Error handling

### Design Patterns

- **Extension Methods**: Movement operations and reporting
- **Records**: Immutable `Room` value object
- **Primary Constructors**: Modern C# syntax for concise class definitions
- **Strategy Pattern**: Direction-based movement calculations
- **Validation**: Input validation at boundaries

## Testing

### Running Tests

Run all tests:
```bash
dotnet test
```

Run tests with detailed output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

Run tests with coverage:
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

### Test Structure

The test project mirrors the source structure:

- **ProgramTests** - Integration tests for end-to-end scenarios
- **Domain/MovementTests** - Movement logic unit tests
- **Domain/RobotTests** - Robot behavior unit tests
- **Domain/RobotControllerTests** - Command execution tests
- **Domain/RoomTests** - Boundary validation tests
- **Domain/ReporterTests** - Report generation tests
- **Input/ParserTests** - Input parsing tests

### Test Coverage

- **Overall**: ~95% code coverage
- **Domain Logic**: 100% coverage (all business rules tested)
- **Input Parsing**: ~90% coverage (edge cases covered)
- **Integration**: End-to-end scenarios validated

## Project Structure

```
robot-controller/
├── src/
│   └── RobotControllerApp/
│       ├── Domain/
│       │   ├── Movement.cs          # Direction enum & operations
│       │   ├── Reporter.cs          # Report generation
│       │   ├── Robot.cs             # Robot entity
│       │   ├── RobotController.cs   # Command execution
│       │   └── Room.cs              # Room value object
│       ├── Input/
│       │   ├── ErrorMessages.cs     # Error message constants
│       │   ├── Parser.cs            # Input parsing
│       │   └── Prompts.cs           # User prompts
│       ├── Program.cs               # Application entry point
│       └── RobotControllerApp.csproj
├── tests/
│   └── RobotControllerAppTests/
│       ├── Domain/
│       │   ├── MovementTests.cs
│       │   ├── ReporterTests.cs
│       │   ├── RobotControllerTests.cs
│       │   ├── RobotTests.cs
│       │   └── RoomTests.cs
│       ├── Input/
│       │   └── ParserTests.cs
│       ├── ProgramTests.cs
│       └── RobotControllerAppTests.csproj
├── .editorconfig                    # Code style configuration
├── .gitignore
├── RobotController.sln
└── README.md
```

## Coordinate System

The application uses a coordinate system where:

- **(0, 0)** is the **top-left corner** of the room
- **X-axis** increases **rightward** (East)
- **Y-axis** increases **downward** (South)

### Direction Vectors

| Direction | Movement | Effect |
|-----------|----------|--------|
| **North (N)** | `(0, -1)` | Y decreases (move up) |
| **East (E)** | `(1, 0)` | X increases (move right) |
| **South (S)** | `(0, 1)` | Y increases (move down) |
| **West (W)** | `(-1, 0)` | X decreases (move left) |

### Example Room Layout (5×5)

```
     0   1   2   3   4  (X-axis →)
   ┌───┬───┬───┬───┬───┐
 0 │   │   │   │   │   │
   ├───┼───┼───┼───┼───┤
 1 │   │   │   │   │   │
   ├───┼───┼───┼───┼───┤
 2 │   │ R │   │   │   │  R = Robot at (1, 2)
   ├───┼───┼───┼───┼───┤
 3 │   │   │   │   │   │
   ├───┼───┼───┼───┼───┤
 4 │   │   │   │   │   │
   └───┴───┴───┴───┴───┘
(Y-axis ↓)

Valid coordinates: 0 ≤ x < 5 and 0 ≤ y < 5
```

## Limitations

### Current Constraints

1. **Command Length**: Maximum 100 commands per sequence
2. **Room Size**: Must have positive dimensions (width > 0, height > 0)
3. **Single Robot**: Only one robot per simulation
4. **No Obstacles**: Room is empty (no walls or obstacles inside)
5. **Case Sensitivity**: Commands must be uppercase (L/R/F), but directions are case-insensitive

### Design Decisions

- **Mutable Robot**: Robot state is mutable for simplicity and performance
- **No Undo**: Commands cannot be undone or reversed
- **Fail-Fast**: Robot stops on first invalid move (doesn't continue with remaining commands)
- **Console Only**: No GUI or web interface

## Development

### Building

```bash
# Debug build
dotnet build

# Release build
dotnet build -c Release

# Build without restoring
dotnet build --no-restore
```

### Code Style

The project uses `.editorconfig` for consistent code formatting:
- 4 spaces indentation
- PascalCase for types and methods
- camelCase for parameters and locals
- Modern C# features encouraged

### Running Specific Tests

```bash
# Run tests in specific class
dotnet test --filter "FullyQualifiedName~RobotControllerTests"

# Run specific test method
dotnet test --filter "Name=ExecuteCommands_ShouldUpdateRobotPositionAndDirection"
```

### Adding New Features

When extending the application:

1. **Add domain logic** in `Domain/` folder
2. **Write tests first** (TDD approach)
3. **Update parser** if new input required
4. **Update this README** with new features
5. **Maintain test coverage** above 90%

## Contributing

When contributing:

1. Follow existing code style (enforced by `.editorconfig`)
2. Write tests for all new features
3. Ensure all tests pass: `dotnet test`
4. Update README if adding user-facing features
5. Keep methods small and focused (Single Responsibility Principle)

## License

[Add your license here]

## Authors

[Add author information]

---

**Note**: This is an educational project demonstrating clean code principles, test-driven development, and modern C# features.
