# 2048-Clone
### (2020) 2D Mobile Puzzle

<p>A clone of the game 2048 made for fun and to learn android app development - as with the real game, the aim is to combine numbers by swiping until the number 2048 is reached. The game can be reset and two random start positions are chosen, and the game keeps track of the highest achieved score. The player loses if they swipe in a direction where no blocks can move.</p>
				<p>Blocks are kept track of using coordinate-based object names, and when combining their position and colour lerps to their target values smoothly.</p>
				<p>One particular challenge was preventing empty spaces being left if all blocks move at the same time - my solution was to handle block movement column-by-column starting from the target direction, this resulted in no gaps being left.</p>
				<p>All assets for the game were made by myself with the exception of the font.</p>

## Technologies/Techniques used:
  <ul>
    <li>Touch gestures as input</li>
    <li>Mobile deployment using Android SDK</li>
    <li>Sprite creation, animation, and interpolation</li>
  </ul>

## Gallery:
<picture>
<img src="https://github.com/JamesMartinGithub/2048-Clone/assets/45734948/209640d4-44ce-4347-b793-abdf075cbeea" width="311" height="174" style="display:inline-block">
</picture>
<picture>
<img src="https://github.com/JamesMartinGithub/2048-Clone/assets/45734948/e210f232-c722-482a-917c-bec393532b28" width="311" height="174" style="display:inline-block">
</picture>
<picture>
<img src="https://github.com/JamesMartinGithub/2048-Clone/assets/45734948/87060cef-2f8a-4861-bbe7-5a4d5e3b2157" width="311" height="174" style="display:inline-block">
</picture>
