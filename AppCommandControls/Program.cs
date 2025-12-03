using AppCommandControls;
using System.Runtime.InteropServices;

[DllImport("user32.dll")]
static extern int GetForegroundWindow();
[DllImport("user32.dll")]
static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
List<AppComandCode> AppComandCodeList = new();
const int WM_APPCOMMAND =   0x319;
var window = GetForegroundWindow();
string command = "";
if(args!=null && args.Length > 0)
{
    for(int i =0; i < args.Length; i++)
    {
        var appCommand = AppComandCode.NONE;
        try
        {
            appCommand = (AppComandCode)System.Enum.Parse(typeof(AppComandCode), args[i]);
        }
        catch (Exception ex)
        {
        
        }
        if (appCommand != AppComandCode.NONE)
        {
            AppComandCodeList.Add(appCommand);
        }
    }
}
foreach(var appCommand in AppComandCodeList)
{
    SendMessage(window, WM_APPCOMMAND, 0, ((int)appCommand) * 65536);
    System.Threading.Thread.Sleep(200);
}