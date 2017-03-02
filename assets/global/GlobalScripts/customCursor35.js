//ATTACH THIS ITEM TO THE CAMERA
//PRESET TO SIZE 35
var yourCursor : Texture2D;  // Your cursor texture
var cursorSizeX : int = 35;  // Your cursor size x
var cursorSizeY : int = 35;  // Your cursor size y
 
function Start()
{
    Screen.showCursor = false;
}
 
function OnGUI()
{
    GUI.DrawTexture (Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, cursorSizeX, cursorSizeY), yourCursor);
}