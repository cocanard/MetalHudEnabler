using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace MetalHudEnablerUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); 
    }

    private MetalHudHandler hudhandler = new();

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }
        
        base.OnFrameworkInitializationCompleted();
    }

    private void OnExit(object? _, EventArgs __)
    {
        Environment.Exit(0);
    }

    private NativeMenuItem? item;

    private void ChangeValue(object? sender, EventArgs e)
    {
        hudhandler.ChangeValue();
        UpdateMainText();
    }

    private void UpdateMainText(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (item != null) return;
        item = (NativeMenuItem)sender;
        UpdateMainText();
    }
    

    private void UpdateMainText()
    {
        item.Header = "Hud is " + (MetalHudHandler.GetValue() ? "enabled" : "disabled");
    }
}