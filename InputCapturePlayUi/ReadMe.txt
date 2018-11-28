11/28/2018
This is a very basic implementation of an input player that targets the Snes9x application. This application does not interface with Snes9x, and only checks if it is running before playing back inputs.
The original intent was to have a way to save inputs for later usage.
This was tested on Snex9x v1.56.1.

To use: 
- Set the keys in Snes9x to your desired layout. These keys will be used in the input player. Setting diagonal inputs (for example, down + right) to their own keys may make entering inputs easier.
- Open the Snes9x Input Player
- Enter the desired inputs:
	- Key is the key bound in Snes9x in the first step
	- Input Type is how the input will be played back 
		- Press simply presses the button
		- HoldDown will hold the key down until the same key is released by entering in a Release Input Type
		- Release will release a key that was entered previously with a HoldDown InputType
		- Charge will hold the key for the specified time in the Charge Duration column
	- Delay is how long the input will be delayed after the previous input is played. This is in frames, assuming the game is in 60 frames per second. So, 1f is around 16ms. 
	- Charge Duration is how long a "Charge" input type will be held, in frames. 

Example: 
A hadouken motion should work consistently if entered as follows, assuming no diagonals are mapped: 
Key | Input Type | Delay | Charge Duration
down key | HoldDown | 2 | 
right key | HoldDown | 2 |
down key | Release | 2 | 
punch key | Press | 2 | 
right key | Release | 2 |

Current limitations:
- Playback timing is not 100% correct, resulting in some inputs not being played back correctly
- Assumes game is running at 60 frames per second
- Requires diagonal inputs to be set to their own keys due to some race conditions from the input playback
- Does not actually interface with Snes9x, so there is no access to the configuration, or anything specific per game. Additionally, it does not matter if a game is running on the emulator.
- There is no validation for the inputs entered by the user, so errors will occur if this application is used incorrectly
- The "Press" functionality is inconsistent 