using AppCommandControls;
using System.Runtime.InteropServices;

[DllImport("user32.dll")]
static extern int GetForegroundWindow();
[DllImport("user32.dll")]
static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

const int WM_APPCOMMAND =   0x319;
var window = GetForegroundWindow();
var command =   args[0];
var appCommand =  AppComandCode.NONE;

switch (command)
{
    case "previous":
        Console.WriteLine($"command:  {command}");
        appCommand =  AppComandCode.MEDIA_PREVIOUSTRACK;
        break;
    case "play/pause":
        Console.WriteLine($"command:  {command}");
        appCommand = AppComandCode.MEDIA_PLAY_PAUSE;
        break;
    case "next":
        Console.WriteLine($"command:  {command}");
        appCommand = AppComandCode.MEDIA_NEXTTRACK;
        break;
    case "up":
        Console.WriteLine($"command:  {command}");
        appCommand = AppComandCode.VOLUME_UP;
        break;
    case "down":
        Console.WriteLine($"command:  {command}");
        appCommand = AppComandCode.VOLUME_DOWN;
        break;
    case "mute":
        Console.WriteLine($"command:  {command}");
        appCommand = AppComandCode.VOLUME_MUTE;
        break;
    default:
        Console.WriteLine($"command not recognized: {command}");
        break;
}
if (appCommand != AppComandCode.NONE)
{
    SendMessage(window, WM_APPCOMMAND, 0, ((int)appCommand) * 65536);
}