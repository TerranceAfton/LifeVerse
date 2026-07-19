# Changelog

All notable changes to LifeVerse will be documented in this file.

> Version numbers follow the project's milestone-based development cycle.

# CHANGELOG

## [0.3.0] - 2026-07-19

### Added

#### Household Interaction Framework

- Added `InteractionDetector`
- Added reusable `InteractionController`
- Added generic `IInteractable` interface
- Added reusable appliance interaction architecture
- Added dynamic interaction names
- Added context-sensitive household interaction prompts
- Added parent object detection
- Added closest interactable selection

#### Furniture Framework

- Added `ApplianceInteractable`
- Added reusable appliance base class
- Expanded the furniture framework to support future household objects
- Improved reusable interaction architecture for appliances

#### Kitchen

- Added `Refrigerator`
- Added refrigerator open interaction
- Added refrigerator close interaction
- Added dynamic interaction prompt switching
- Added first interactive household appliance

### Changed

#### Interaction Architecture

- Refactored household interactions to use a single interaction pipeline
- Improved interaction execution using `InteractionController`
- Improved prompt refresh timing after interactions
- Expanded the reusable interaction framework for future household furniture
- Improved interaction scalability for additional appliance types

#### Furniture Architecture

- Reorganized furniture scripts into reusable base classes
- Improved separation between interaction logic and object-specific behavior
- Designed appliance interactions for future storage, cooking, and electronic systems

### Fixed

#### Interaction

- Fixed duplicate interaction execution caused by the legacy `InteractionInput` system
- Fixed refrigerator opening and closing from a single interaction
- Fixed conflicting interaction components running simultaneously
- Fixed interaction prompt updates after appliance state changes

#### Debugging

- Removed obsolete interaction debugging components
- Removed temporary interaction logging
- Removed stack trace debugging after testing
- Cleaned up interaction testing code

### Tested

- Verified refrigerator interaction
- Verified repeated open / close interaction cycle
- Verified interaction prompt updates
- Verified appliance interaction state changes
- Verified interaction detection
- Verified interaction controller execution
- Verified reusable appliance interaction framework

## [0.2.9] - 2026-07-18

### Added

#### Inventory Foundation

- Added reusable inventory framework
- Added `ItemDefinition`
- Added `InventoryItem`
- Added `InventorySlot`
- Added `InventoryContainer`
- Added `PlayerInventory`
- Added `InventoryUI`
- Added inventory event system
- Added stackable item support
- Added inventory update notifications

#### World Items

- Added `WorldItem`
- Added `ItemPickup`
- Added world item interaction
- Added automatic inventory integration
- Added item collection workflow

#### Interaction Improvements

- Added `InteractionController`
- Added interaction support for world items
- Added reusable interaction pipeline between world objects and inventory
- Added support for future interactive furniture and household objects

### Changed

#### Interaction Architecture

- Improved interaction workflow by separating detection, prompts, and interaction execution
- Expanded the reusable `IInteractable` framework
- Improved interaction scalability for future gameplay systems

#### Inventory Architecture

- Implemented a modular inventory foundation designed for future expansion
- Separated inventory data from gameplay interactions
- Designed the inventory system to support future unlimited inventory functionality

### Fixed

#### Inventory

- Fixed `ItemDefinition` assignment issues during item pickup
- Fixed inventory initialization problems
- Improved inventory reliability when collecting world items

#### Interaction

- Fixed interaction flow between world items and player inventory
- Resolved duplicate interaction handling during testing

### Tested

- Verified world item pickup
- Verified inventory updates
- Verified inventory event notifications
- Verified interaction prompts
- Verified repeated item collection
- Verified inventory persistence during gameplay

## [0.2.8] - 2026-07-17

### Added

#### Gameplay UI Framework
- Added reusable UI framework foundation
- Added `UIManager`
- Added `UIWindow`
- Added `UIWindowType`
- Added `UIElement`
- Added `SleepWindow`

#### Interaction Prompt System
- Added reusable interaction prompt system
- Added `PromptData`
- Added `InteractionPrompt`
- Added `PromptManager`
- Added automatic interaction prompts
- Added contextual interaction text using `InteractionName`
- Added automatic prompt hiding when no interactable is detected

### Changed

#### UI Architecture
- Refactored interaction prompt system into reusable UI components
- Separated gameplay logic from prompt presentation
- Improved interaction prompt architecture using:
  - InteractionDetector
  - InteractionPromptUI
  - PromptData
  - InteractionPrompt

#### Performance
- Optimized prompt updates to refresh only when the current interactable changes
- Reduced unnecessary UI updates

### Tested

- Bed interaction prompts
- Chair interaction prompts
- Door interaction prompts
- Prompt show/hide behavior
- Interaction prompt updates between interactables

## [0.2.7] - 2026-07-14
## Added
- Bed sleeping framework
- Wake-up interaction
- Energy recovery while sleeping
- Character state synchronization with simulation
- Time acceleration during sleep

## Improved
- Needs System sleep behavior
- Character interaction flow
- Simulation integration
- Time Service integration

## Fixed
- Character state synchronization
- Sleep state detection
- Needs simulation during sleep

## Cleanup
- Removed temporary debugging
- Cleaned simulation logging
- Cleaned TimeService logging

## [0.2.6] - 2026-07-13

### Added

- Integrated sleep system with the Time Service.
- Added simulation time acceleration while sleeping.
- Added automatic return to normal simulation speed when waking up.

### Changed

- Refactored `BedInteractable` to use `CharacterStateController` as the single source of truth.
- Removed redundant sleep state tracking from `BedInteractable`.
- Improved sleep interaction architecture.
- Improved simulation time integration for future gameplay systems.

### Fixed

- Fixed bed interaction requiring multiple wake-up interactions.
- Fixed sleep state synchronization between the character and bed.
- Fixed interaction state inconsistencies during sleep and wake transitions.

### Tested

- Verified sleep interaction.
- Verified wake up interaction.
- Verified simulation time acceleration while sleeping.
- Verified simulation time returns to normal after waking.
- Verified repeated sleep and wake interaction cycle.

## [0.2.5] - 2026-07-11

### Added

- Introduced the Furniture Framework.
- Added `SeatingInteractable` base class.
- Added `BenchInteractable`.
- Added `SofaInteractable`.
- Added `BedInteractable`.
- Added sleeping interaction.
- Added wake up interaction.
- Added `Sleep()` to `CharacterInteractionController`.
- Added `WakeUp()` to `CharacterInteractionController`.

### Changed

- Refactored `ChairInteractable` to inherit from `SeatingInteractable`.
- Improved furniture interaction architecture.
- Expanded reusable interaction framework for future seating furniture.

### Tested

- Verified chair interactions.
- Verified bench interactions.
- Verified sofa interactions.
- Verified bed interactions.
- Verified sleep and wake interaction cycle.

## [0.2.4] - 2026-07-09

### Added
- Interaction System v2
- Interaction angle filtering
- Closest interactable selection
- Interaction debug visualization

### Improved
- Interaction detection accuracy
- Multi-object interaction support
- Developer debugging tools

## [0.2.3] - 2026-07-08

### Added
- Furniture Interaction System v1
- Prototype Chair Interaction
- SeatPoint-based seating architecture
- Sitting Idle state
- Stand Up interaction
- Movement locking while seated

### Changed
- Updated character interaction workflow
- Improved player state transitions
- Updated Player Animator state machine

### Fixed
- Automatic return to locomotion after sitting
- Movement while seated
- Character state transition handling

---

## [0.2.2] - 2026-07-06

### Added
- LifeVerse Camera Controller
- Camera-relative movement
- Unity New Input System integration
- CameraTarget architecture
- Visual parent object for character models
- Development archive
- Milestone 1 screenshots
- Milestone 1 gameplay recordings

### Changed
- Migrated player input to Unity's New Input System
- Reorganized player hierarchy
- Improved third-person controller architecture
- Improved camera system
- Updated project documentation
- Updated README

### Fixed
- Character walking backwards
- Character model orientation
- Camera spawning in front of the player
- Camera rotation issues
- Camera-relative movement bugs
- Mixed input system issues

---

## [0.2.1] - 2026-07-04

### Added
- Mixamo humanoid character integration
- Humanoid Avatar configuration
- Animator Controller
- Animation Blend Tree
- Idle animation
- Walk animation
- Run animation
- Character Animation Controller
- Character State System foundation

### Changed
- Player architecture
- Character hierarchy
- Animation workflow
- Character movement and animation integration

### Fixed
- Mixamo Avatar configuration issues
- Blend Tree setup
- Animation controller integration

---

## [0.2.0] - Gameplay Foundation - 2026-07-03

### Added
- Third-person Character Controller
- Character movement system
- Sprint functionality
- Gravity system
- Character Movement Settings
- Cinemachine third-person camera
- Interaction framework
- Interaction detection system
- Interaction input system
- Test interactable objects
- Chair interaction prototype
- Context-sensitive interaction UI
- World testing scene

### Changed
- Character controller responsiveness
- Camera follow behavior
- Interaction workflow

### Fixed
- Camera follow issues
- Character movement bugs
- Interaction detection problems

---

## [0.1.2] - Simulation Foundation

### Added
- Needs System
- Hunger
- Energy
- Fun
- Social
- Need decay system
- Simulation update loop
- Character framework
- Character Manager
- Time progression
- Simulation Manager

### Changed
- Simulation architecture
- Character update pipeline

---

## [0.1.1] - Engine Foundation

### Added
- Bootstrap System
- Service Registry
- Configuration System
- Logging System
- Scene Management
- Project folder structure
- Initial testing scene
- Core game initialization

### Changed
- Project architecture
- Service initialization
- Startup workflow

---

## [0.1.0] - Project Initialization

### Added
- Unity project created
- Git repository initialized
- GitHub repository created
- Initial project structure
- README
- .gitignore
- Basic documentation
- Version control workflow

### Notes
- Initial public project setup.
