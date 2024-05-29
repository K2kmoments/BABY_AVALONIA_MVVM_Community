using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace BABY_AVALONIA_MVVM.ViewModels;

public class LogItemTemplate
{
    public LogItemTemplate(Type modelType, string visibleName, string iconKey)
    {
        LogEntryType = modelType;
        Label = visibleName;

        // Find the Icon by Key and Add it
        Application.Current!.TryFindResource(iconKey, out var res);
        LogItemIcon = (StreamGeometry)res!;
    }

    public string Label { get; }
    public Type LogEntryType { get; }
    public StreamGeometry LogItemIcon { get; set; }
}