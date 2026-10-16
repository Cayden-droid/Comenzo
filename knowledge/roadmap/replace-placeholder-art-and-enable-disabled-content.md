---
type: "slice"
state: "needs-info"
priority: "candidate"
kind: "enhancement"
cycle: "11353148-fa6"
provenance: "inferred"
created: "2026-10-16T00:46:12Z"
modified: "2026-10-16T00:46:12Z"
---
# Replace placeholder art and enable disabled content

**Goal:** Every placeholder sprite is replaced with real art, and the content disabled for lack of art (Merchant, KillerRabbitFeed, BUNY) autoloads again.

**Stands alone:** Ships or drops without the other items; it is art plus removing `[Autoload(false)]` and the placeholder `Texture` overrides.

- Cited: `NPCS/Friendlies/Merchant.cs:29` — `[Autoload(false)]` until the `Merchant_Gore_*` gores exist.
- Cited: `Items/Weapons/Summon/KillerRabbitFeed/KillerRabbitFeed.cs:11` and `BUNY.cs:6` — `[Autoload(false)]` pending sprites.
- Cited: placeholder vanilla textures at `NPCS/Enemies/SkeletonKnight/SkeletonKnight.cs:13`, `Buffs/WhipDebuff.cs:15`, `Projectiles/MagmaArrow.cs:13`, `Items/Weapons/Ranger/LongBow/LongBow.cs:12`, `Items/Weapons/Magic/ReflectionStaff/ReflectionStaffProjectile.cs:12`.
