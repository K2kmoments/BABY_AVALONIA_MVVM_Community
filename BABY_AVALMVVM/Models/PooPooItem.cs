namespace BABY_AVALONIA_MVVM.Models;

public class PooPooItem
{
    public string? Name { get; set; }
    public string? IconString { get; set; }

    public PooPooItem(string? name)
    {
        Name = name;
        
    }
}