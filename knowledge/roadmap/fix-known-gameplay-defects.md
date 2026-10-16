---
type: "slice"
state: "needs-info"
priority: "candidate"
kind: "bug"
cycle: "11353148-fa6"
provenance: "inferred"
created: "2026-10-16T00:46:12Z"
modified: "2026-10-16T00:46:12Z"
---
# Fix known gameplay defects

**Goal:** DualSlashSword projectiles live their intended lifetime, the mana-drain debuff drains mana, and ReflectionStaff keeps per-item state.

**Stands alone:** Ships or drops without the other items; the fixes touch weapon and player code only, no assets or worldgen.

**Folded:** three same-source defects from `CODE-QUALITY.md` "Known gameplay defects", each a facet of one slice.

- Cited: `Items/Weapons/Melee/DualSlashSword/DualSlashSword.cs:84` — right-click projectile gets lifetime 0.
- Cited: `Items/Weapons/Melee/DualSlashSword/DualSlashSword.cs:116` (also `:124`) — left-click passes a Y coordinate as the lifetime (`ai[1]`).
- Cited: `Player/ManaDrain.cs:16` — `ResetEffects` clears `hasManaDrainDebuff` every tick; confirm whether the buff sets it again before `PostUpdateMiscEffects` runs.
- Cited: `Items/Weapons/Magic/ReflectionStaff/ReflectionStaff.cs:15` — reference-type field shared across item clones.
