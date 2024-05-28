using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace BABY_AVALMVVM.ViewModels;

public class NavItemTemplate
{
    
    public string VisibleName { get; }
    public Type ModelType { get; }
    public StreamGeometry ListItemIcon { get; set; }

    public NavItemTemplate(Type modelType, string visibleName, string iconKey)
    {
        ModelType = modelType;
        VisibleName = visibleName;

        // Find the Icon by Key and Add it
        Application.Current!.TryFindResource(iconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;
    }
}