using System.Diagnostics;

namespace MetalHudEnablerUI;

public class MetalHudHandler
{
    public void ChangeValue()
    {
        if(GetValue()) Disable();
        else Enable();
    }
    
    private static Process CreateCommand()
    {
        Process proc = new Process ();
        proc.StartInfo.FileName = "/bin/zsh";
        proc.StartInfo.UseShellExecute = true; 
        proc.StartInfo.UserName = System.Environment.UserName;
        return proc;
    }

    public static bool GetValue()
    {
        Process proc = CreateCommand();
        proc.StartInfo.Arguments = "-c \"/bin/launchctl getenv MTL_HUD_ENABLED\"";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.Start();
        return proc.StandardOutput.ReadLine() == "1";
    }

    

    private void Enable()
    {
        Process proc = CreateCommand();
        proc.StartInfo.Arguments = "-c \"/bin/launchctl setenv MTL_HUD_ENABLED 1\"";
        proc.Start();
    }

    private void Disable()
    {
        Process proc = CreateCommand();
        proc.StartInfo.Arguments = "-c \"/bin/launchctl setenv MTL_HUD_ENABLED 0\"";
        proc.Start();
    }
}