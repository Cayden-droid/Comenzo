<!-- ecorn: ecorn-code-quality | generated 2026-10-16T00:35:36Z | commit e85bdf7937958f31bf90e19dce0c2d480dc06044 --> <!-- cspell:disable-line -->
# Audit report — Comenzo

_Adapters matched: none (C# / tModLoader has no adapter; generic checks only)._

## Executive summary

**Overall grade: C**

Preflight skipped: no adapter matched a C# stack; small-project exception applies (44 source files, under the 50-file gate), so only generic structural checks ran.

- **Scope examined:** working tree at HEAD plus uncommitted changes — 44 `.cs` files, 38 `.png` files, project config.
- **Not examined:** C# idioms, performance, test checks, tech-debt anti-patterns — no adapter supplies them.
- **Build state (outside this sweep):** last local build had 0 errors and 0 warnings; tModLoader's `client.log` shows a clean load. No source changed since.

The mod builds and loads, but about a quarter of its C# files are dead weight: wholly commented-out files, 1.3-era boilerplate blocks, and empty stubs. Maintainability grades C on that count alone. There are no tests, which is ungraded here because no adapter covers C#.

**Critical blockers:**
- No blocking findings.

**Known gameplay defects (ungraded, outside the generic sweep):**
- `SecretsOfManaWorld.cs:2` — ore worldgen commented out, so Magma ore never spawns.
- `Items/Weapons/Melee/DualSlashSword/DualSlashSword.cs:84` — right-click projectile gets lifetime 0.
- `Items/Weapons/Melee/DualSlashSword/DualSlashSword.cs:116` — left-click passes a Y coordinate as lifetime (also `:124`).
- `Player/ManaDrain.cs:16` — flag reset every tick, so drain never applies.
- `Items/Weapons/Magic/ReflectionStaff/ReflectionStaff.cs:15` — reference-type field shared across item clones.

## Section 1 — Idioms & performance

(adapter not present — section skipped)

## Section 2 — Maintainability

**Grade: C**

_Reason (`ecorn section-grade`): 14 findings across 1 adapter slot — 3 or more per adapter. Generic findings are fed through the rubric's idiom-count slot, the only count input it has._

### Top risks
1. `SecretsOfManaWorld.cs:2` — entire file is a commented-out 1.3 `ModWorld`; the only ore source is dead.
2. `Items/Armor/Magma/MagmaGreaves.cs:23` — ~110 lines of commented 1.3 `item.*` field lists bury 6 live assignments.
3. `Items/ItemTemplate.cs:1` and `Items/Weapons/ProjectileTemplate.cs:1` — whole-file commented templates shipped as source.

### All findings

#### Commented-out code (7)

- `SecretsOfManaWorld.cs:2` — [dead-artifact] Whole file commented out (42/42 non-blank lines); port to `ModSystem.ModifyWorldGenTasks` or delete.
- `Items/ItemTemplate.cs:1` — [dead-artifact] Whole file commented out (134 non-blank lines); move to docs or delete.
- `Items/Weapons/ProjectileTemplate.cs:1` — [dead-artifact] Whole file commented out; it is an `ExampleMod` copy (`:8`). Delete.
- `Items/Armor/Magma/MagmaGreaves.cs:23` — [dead-artifact] Commented field-list blocks at `:23-40`, `:42-54`, `:56-72`, `:74-93`, `:125-139`; keep only live lines.
- `Items/Weapons/Melee/TheDestroyer/TheDestoryer.cs:37` — [dead-artifact] Commented blocks at `:37-69`, `:71-85`, `:122-136`; same boilerplate.
- `Items/Weapons/Melee/TheTruePath/TheTruePath.cs:37` — [dead-artifact] Commented blocks at `:37-49`, `:51-69`, `:71-85`, `:122-136`.
- `Items/Armor/Magma/MagmaHelmet.cs:31` — [dead-artifact] 15-line commented block at `:31-45`.

#### Empty, stub, and junk files (6)

- `NPCS/Enemies/aerfasd` — [dead-artifact] 0-byte tracked file with a non-conforming name; delete.
- `NPCS/Friendlies/E` — [dead-artifact] 0-byte tracked file with a non-conforming name; delete.
- `Items/Weapons/Ranger/Gun/Gun.cs:8` — [dead-artifact] Empty namespace stub; implement or delete.
- `Items/Weapons/Summon/HellHoundStaff/HellHoundStaff.cs:1` — [dead-artifact] Empty namespace stub.
- `Items/Weapons/Summon/HellHoundStaff/HellHoundMinion.cs:1` — [dead-artifact] Empty namespace stub.
- `desktop.ini` — [dead-artifact] Tracked Windows Explorer metadata; delete and add to `.gitignore`.

#### Naming (1)

- `Items/Weapons/Melee/TheDestroyer/TheDestoryer.cs:10` — [naming] File and class `TheDestoryer` misspell their folder `TheDestroyer`; renaming must move `TheDestoryer.png` too.

Checks with no findings:
- **File size:** largest file is `NPCS/Friendlies/Merchant.cs` at 342 lines, under 500.
- **Directory sprawl:** no directory exceeds 50 source files.
- **Backup files:** no `*.bak`, `*.old`, or `*.orig` files.
- **Gitignored-but-tracked:** `git ls-files -ci --exclude-standard` returns nothing.

## Section 3 — Test suite health

(adapter not present — section skipped)

- Test-to-source ratio: 0 (0 test files / 44 source files)
- Coverage: not captured
- Disabled tests: 0

No adapter supplies C# test checks, so this section is ungraded. The mod has no tests of any kind.

## Section 4 — Principle conformance

(no knowledge/principle/ — section skipped)

## Tech Debt

(adapter not present — section skipped)
