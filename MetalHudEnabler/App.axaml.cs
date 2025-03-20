using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace MetalHudEnablerUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private MetalHudHandler hudhandler = new();
    private NativeMenuItem? checkbox;

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

    private void ChangeValue(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        //function used to first refresh the value on window init
        if(checkbox is null)
        {
            checkbox = (NativeMenuItem)sender;
            UpdateMainText();
        }        
    }

    private void ChangeValue(object? sender, EventArgs e)
    {
        if(checkbox is null) checkbox = (NativeMenuItem)sender;
        hudhandler.ChangeValue();
        UpdateMainText();
    }

    private void UpdateMainText()
    {
        checkbox.IsChecked = MetalHudHandler.GetValue();
    }
}