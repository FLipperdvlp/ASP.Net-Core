namespace Library.Entities;

public class Author : BaseEntity
{
    public  required  string    Name        { get; set; }
    public            DateOnly?  DeathDate   { get; set; }
}