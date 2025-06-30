using Project.Enums;

namespace Project.Entities;

public class Hero
{
    public required string Name { get; set; }
    public required HeroAttribute Attribute { get; set; }
    public required bool IsMelee { get; set; }
    public required int Health { get; set; }
    public required int Mana { get; set; }
}