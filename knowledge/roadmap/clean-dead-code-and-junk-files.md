---
type: "slice"
state: "needs-info"
priority: "candidate"
kind: "chore"
cycle: "11353148-fa6"
provenance: "inferred"
created: "2026-10-16T00:46:12Z"
modified: "2026-10-16T00:46:12Z"
---
# Clean dead code and junk files

**Goal:** The repo carries no commented-out 1.3 boilerplate, empty stubs, or junk files, and the misspelled `TheDestoryer` is renamed.

**Stands alone:** Ships or drops without the other items; it changes no behavior.

**Cycle rationale:** The cycle holds four slices, one over the soft cap of three; the four have distinct sources and file sets (worldgen, defect fixes, dead code, art), and none passes the fold test against another.

- Cited: `CODE-QUALITY.md` Maintainability grade C — 7 commented-out-code findings (`Items/ItemTemplate.cs:1`, `Items/Weapons/ProjectileTemplate.cs:1`, `Items/Armor/Magma/MagmaGreaves.cs:23`, `Items/Weapons/Melee/TheDestroyer/TheDestoryer.cs:37`, `Items/Weapons/Melee/TheTruePath/TheTruePath.cs:37`, `Items/Armor/Magma/MagmaHelmet.cs:31`, and the worldgen file owned by [[restore-magma-ore-worldgen]]).
- Cited: empty files `NPCS/Enemies/aerfasd`, `NPCS/Friendlies/E` (0 bytes, verified), plus empty stubs `Items/Weapons/Ranger/Gun/Gun.cs`, `Items/Weapons/Summon/HellHoundStaff/HellHoundStaff.cs`, `HellHoundMinion.cs`, and tracked `desktop.ini`.
- Cited: `Items/Weapons/Melee/TheDestroyer/TheDestoryer.cs:10` — name misspelling; the rename must move `TheDestoryer.png` too.
