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
# Restore Magma ore worldgen

**Goal:** Magma ore spawns in newly generated worlds, via a worldgen pass that compiles against tModLoader 1.4.4.

**Stands alone:** Ships or drops without the other items; it touches only `SecretsOfManaWorld.cs` and the ore tile.

- Cited: `SecretsOfManaWorld.cs:2` — whole file is a commented-out 1.3 `ModWorld`, so `Tiles.Ore.MagmaOre.MagmaOre` is never placed (`CODE-QUALITY.md`, Top risks #1). Port to `ModSystem.ModifyWorldGenTasks`.
