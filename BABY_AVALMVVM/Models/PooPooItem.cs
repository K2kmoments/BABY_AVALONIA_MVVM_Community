namespace BABY_AVALMVVM.Models;

public class PooPooItem
{
    public string? Name { get; set; }
    public string? Icon { get; set; }

    public PooPooItem(string? name, string? icon)
    {
        Name = name;
        Icon = icon;
    }
}