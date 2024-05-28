using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace BABY_AVALMVVM.ViewModels;

public class LogItemTemplate
{
    
    public string Label { get; }
    public Type LogEntryType { get; }
    public StreamGeometry LogItemIcon { get; set; }

    public LogItemTemplate(Type modelType, string visibleName, string iconKey)
    {
        LogEntryType = modelType;
        Label = visibleName;

        // Find the Icon by Key and Add it
        Application.Current!.TryFindResource(iconKey, out var res);
        LogItemIcon = (StreamGeometry)res!;
    }
}