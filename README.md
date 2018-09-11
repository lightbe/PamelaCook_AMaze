# A Maze Starter Project

This project is part of [Udacity](https://www.udacity.com "Udacity - Be in demand")'s [VR Developer Nanodegree](https://www.udacity.com/course/vr-developer-nanodegree--nd017). This project is being submitted for iOS with the minimum version of 10.0. Testing is being done using an iPhone 6 Plus running the latest stable version of iOS 11.

To play: Read the instruction text box. Click the instruction text box to begin. Navigate the maze by clicking the green waypoints along the way. There are seven coins that can be collected. The goal is to unlock and open the temple door. The key must be collected and the door clicked to open the door. To start over click the green text above the treasure chest.

## Versions
- Unity 2017.2.0f3
- GVR Unity SDK v1.70.0

## Observation(s)
- I defined Key.keyCollected and set it to true to fulfill the rubric requirement. However when I run the maze I see the following warning message in the console: **Assets/UdacityVR/Scripts/Key.cs(10,10): warning CS0414: The private field `Key.keyCollected' is assigned but its value is never used**. 

## Credits
- Audio of crickets chirping created by [CGEffex](https://freesound.org/people/CGEffex/) was downloaded from [Freesound](https://freesound.org/), a collaborative database of Creative Commons Licensed sounds. The WAV file was converted to MP3 to help with optimization.

## Extras
- Added a StartGame prefab with instructions on how to play.
- Limit the raising of the door in the Door script.
- Added two float variables to the Waypoint script to set the camera height for all Waypoints in method **Click()** to limit the lifting of the head. One is used to control the height of the camera for all waypoints except the one on the doorsteps. The other is added to first variable for a higher camera height at the waypoint on the doorsteps.
- Added a Timer script which displays the elapsed time, the coin count and when the Key is collected. The Coin script increments the coin count when collected.
- Display message **GET THE KEY!** for 64 frames (approx. 2 seconds) when a locked door is clicked.