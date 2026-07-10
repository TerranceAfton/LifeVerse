# Interaction System

**Status:** Stable ✅

**Current Version:** 2.0

**Last Updated:** July 2026

---

## Overview

The Interaction System provides a reusable framework that allows the player to interact with world objects.

The system is object-independent, meaning new interactable objects can be added without modifying the core interaction framework.

---

## Workflow

Player

↓

Interaction Input

↓

Interaction Detector

↓

Current Interactable

↓

Interact()

---

## Components

### IInteractable

Defines the interaction interface.

Every interactable object must provide:

- Interaction Name
- CanInteract()
- Interact()

---

### Interaction Detector

Responsibilities:

- Detect nearby interactables
- Filter parent objects
- Filter by interaction angle
- Select closest valid interactable

---

### Interaction Input

Responsibilities:

- Detect interaction input
- Execute interaction
- Validate interactables

---

### Interaction Prompt

Displays:

[E] Sit

[E] Open Door

Future examples:

[E] Sleep

[E] Watch TV

[E] Drive

---

## Current Interactables

- Chair
- Door

---

## Developer Tools

Current debug features:

- Interaction radius visualization
- Forward direction visualization
- Current interactable visualization

---

## Design Goals

- Reusable
- Expandable
- Simple
- Object-independent
- NPC compatible

---

## Future Expansion

- Interaction priorities
- Line of sight checks
- Highlight outlines
- Context actions
- NPC interaction support
