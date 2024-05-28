using System;
using SQLite;

namespace BABY_AVALMVVM.Models;

public abstract class DatabaseEntryBase
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; } = "UndefinedEntry";
    public DateTime LogCreationDateTime { get; set; }

}