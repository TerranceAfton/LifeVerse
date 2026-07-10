# Character System

**Status:** Stable ✅

**Current Version:** 1.0

**Last Updated:** July 2026

---

## Overview

The Character System controls player movement, animations, interaction states, and character behavior.

The system is designed so that both the player and future NPCs can share the same core architecture whenever possible.

---

## Components

### Character Controller

Handles:

- Walking
- Sprinting
- Gravity
- CharacterController movement

---

### Character Input

Reads player input and provides movement values to the controller.

---

### Character States

Current states:

- Idle
- Walking
- Running
- Sitting

Future states:

- Sleeping
- Working
- Eating
- Driving
- Swimming

---

### Character Animation

Responsible for:

- Blend Tree movement
- Sit animation
- Stand animation
- Future interaction animations

---

### Character Interaction Controller

Executes gameplay interactions.

Current interactions:

- Sit
- Stand

Future interactions:

- Sleep
- Watch TV
- Drive
- Cook
- Shower

---

## Design Goals

- Shared by Player and NPCs
- Modular
- Animation driven
- State driven

---

## Future Expansion

- Inventory
- Equipment
- Health
- Emotions
- Skills
- Personality
