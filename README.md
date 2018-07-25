# unity_3D
Beleg im Modul Computergrafik, SS2018

Das Spiel

Ziel unserer Belegarbeit ist die Entwicklung von einem 3D-Spiel. Das Spiel soll sowohl als Single Player, als auch im Multiplayer bedienbar sein. 
Der Player soll Coins sammeln, die sich an verschiedenen Positionen in der Szene befinden.
Auf dem Weg soll der Player Enemies vermeiden und kann Power-Ups verwenden, um den Weg zur Münze zu beschleunigen.

Input

- Richtung über Mausbewegung
- W für Walk
- Spacebar für Springen
- Shift für Rennen


Player


Unser Player ist ein Goblin und verfügt über folgende Fähigkeiten: Spazieren (walk), Laufen (run), Sterben (die), Springen (jump), Stehen (idle). Dafür wurde ein Asset aus dem Unity AssetStore verwendet. Die Animationen und die Wirkung von treffenden Elementen (onCollision Verhalten) wurden nach unseren Vorstellungen für das Spiel angepasst. 

Sekundäre Objekte


Folgende Elemente wurden als sekundäre Objekte verwendet:
Mushrooms (fertiges Asset)
  - Rot: Erhöhen die Geschwindigkeit (3x schneller)
  - Blau: Erhöhe die Sprunghöhe (5x höher)
Ghost (fertiges Asset)
  - Bewegen sich diagonal und oben/unten
Coins (Realisiert durch Component)
  - Rotieren in der Umgebung um sich selbst

Szene/Umgebung

Die Szene besteht aus einem Plane, auf dem ein Terrain (wurde mithilfe von standard Unity Funktionen erzeugt) angeschlossen wurde. Auf der Szene befinden sich Naturelemente und Häuser, die aus dem Unity AssetStore als fertige Prefabs übernommen wurden. Diese Elemente sind bezüglich ihrer Form mit einem Box, Sphere oder Mesh-Collider ausgestattet worden, damit der Spieler nicht durch die Objekte laufen kann.

Quellen

Spielelemente - alle Spielelemente, die nicht selbst konfiguriert wurden, sind aus dem Unity AssetStore übernommen worden

Main Character:
 - Goblin Robber: https://assetstore.unity.com/packages/3d/characters/humanoids/goblin-robber-66959
Sekundäre Elemente:
- Level1 Monster Pack (https://assetstore.unity.com/packages/3d/characters/creatures/level-1-monster-pack-77703)
Power-Ups:
- Mushroom monster Pack (https://assetstore.unity.com/packages/3d/characters/creatures/fantasy-mushroom-mon-115406)
Terrainelemente:
- Grass road race (https://assetstore.unity.com/packages/3d/environments/roadways/grass-road-race-46974)
- Low Poly free Pack (https://assetstore.unity.com/packages/category/low-poly-free-pack-63714)
- AsseLevel 1 Monster Pack (https://assetstore.unity.com/packages/3d/characters/creatures/level-1-monster-pack-77703)
- Medieval Stone Keep Pack (https://assetstore.unity.com/packages/3d/environments/medieval-stone-keep-56596)
- Free Trees Pack (https://assetstore.unity.com/packages/3d/vegetation/trees/free-trees-103208)
QS Materials Nature - Pack Grass (https://assetstore.unity.com/packages/2d/textures-materials/qs-materials-nature-pack-grass-vol-1-21113)
- Medieval House Pack (https://assetstore.unity.com/packages/3d/environments/fantasy/medieval-house-24040)
- Medieval fantasy house Pack (https://assetstore.unity.com/packages/3d/environments/fantasy/medieval-fantasy-house-31856)
- Max Adventure Model Pack (was used by game developing, not in play version) (https://assetstore.unity.com/packages/3d/characters/humanoids/max-adventure-model-3012)
Design:
- Fotos: pixaby (https://pixabay.com/de/hintergrundbild-fantasie-b%C3%A4ume-see-3507320)
- Fonts: 1001fonts (https://www.1001fonts.com/carolingia-bigfoot-font.html)
