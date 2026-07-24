# LifeVerse Devlog

## Version 0.3.2 - Household Storage & Inventory UI

**Release Date:** July 23, 2026

---

# Overview

This milestone focused on completing the first fully functional inventory user interface for LifeVerse.

While the previous milestone established the backend inventory architecture, players had no direct way to interact with their inventory during gameplay.

Version **0.3.2** bridges that gap by introducing a modular, event-driven user interface that connects the Input System, EventBus, UIManager, and Inventory Window into a clean and scalable architecture.

Although the inventory currently serves as the player's personal inventory, the systems completed during this milestone lay the foundation for future household storage, refrigerators, cabinets, dressers, bookshelves, and every other inventory-based interface in the game.

---

# New Features

## Inventory Window

Implemented the first functional Inventory Window for LifeVerse.

Players can now open their inventory during gameplay using the Inventory input action.

The inventory window is fully integrated into the UI framework and refreshes automatically whenever it is opened.

---

## Event-Driven Inventory UI

Rather than directly opening UI windows from the input system, inventory interaction now follows an event-driven workflow.

```text
Player Input
      │
      ▼
InputService
      │
      ▼
InventoryPressedEvent
      │
      ▼
EventBus
      │
      ▼
InventoryUIController
      │
      ▼
UIManager
      │
      ▼
InventoryWindow
```

This architecture keeps gameplay systems independent while making the UI significantly easier to maintain and expand.

---

## Inventory Input Action

Added a dedicated Inventory action to the Gameplay input map.

This allows players to access their inventory without coupling gameplay input directly to the user interface.

Future UI windows—including Skills, Careers, Relationships, Build Mode, and Create-a-Verse—can reuse this same architecture.

---

## Inventory UI Controller

Implemented a dedicated `InventoryUIController`.

This controller listens for `InventoryPressedEvent` through the EventBus and delegates window management to the UIManager.

Separating input handling from UI logic keeps each system focused on a single responsibility and simplifies future development.

---

## Automatic Inventory Refresh

The Inventory Window now refreshes its contents every time it is opened.

This ensures the displayed inventory always reflects the player's current inventory data without requiring manual updates elsewhere in the project.

---

# Architecture Improvements

Several UI systems were expanded and refined during this milestone.

The inventory workflow now has clear responsibilities between:

- Input Service
- InventoryPressedEvent
- EventBus
- InventoryUIController
- UIManager
- InventoryWindow
- InventoryUI

This event-driven design establishes a reusable pattern that future gameplay windows will follow throughout the project.

---

# Testing

The completed inventory interface was tested by verifying:

- Inventory input detection
- Inventory event publishing
- EventBus communication
- Inventory UI Controller event handling
- UIManager window registration
- Inventory window opening
- Automatic inventory refresh
- Window visibility during gameplay

All tests completed successfully.

---

# Next Milestone

The next milestone will focus on expanding the inventory system into fully functional household storage.

Development will begin with:

- Inventory Toggle
- Refrigerator Storage
- Cabinet Storage
- Pantry Storage
- Bookshelves
- Dressers
- Drag & Drop Item Transfers
- Dual Inventory Windows
- Item Tooltips

Once complete, players will be able to transfer items between themselves and household furniture, creating the first complete household storage gameplay loop in LifeVerse.

---

# Closing Thoughts

The Household Storage & Inventory UI milestone represents another major step toward building a scalable life simulation.

Although the visible gameplay changes are relatively small, the underlying architecture is one of the most important improvements made to the project so far.

By introducing an event-driven UI framework, LifeVerse now has a reusable foundation for every major gameplay window the game will eventually include—from inventories and storage to careers, relationships, skills, phones, Build Mode, and Create-a-Verse.

With both the inventory backend and frontend now complete, development can shift toward creating meaningful gameplay systems that allow players to store, organize, and interact with objects throughout the world.

This milestone strengthens the foundation of LifeVerse and prepares the project for the next phase of household simulation and player interaction.
