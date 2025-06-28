using Project.Enums;

namespace Project.Entities;

public class HeroesDataBase
{
    public static List<Hero> Heroes =
    [
        new Hero
        {
            Name = "Axe",
            Attribute = HeroAttribute.Strength,
            IsMelee = true,
            Health = 700,
            Mana = 291
        },
        new Hero
        {
            Name = "Juggernaut",
            Attribute = HeroAttribute.Agility,
            IsMelee = true,
            Health = 600,
            Mana = 267
        },
        new Hero
        {
            Name = "Crystal Maiden",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 520,
            Mana = 351
        },
        new Hero
        {
            Name = "Invoker",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 560,
            Mana = 339
        },
        new Hero
        {
            Name = "Phantom Assassin",
            Attribute = HeroAttribute.Agility,
            IsMelee = true,
            Health = 620,
            Mana = 267
        },
        new Hero
        {
            Name = "Pudge",
            Attribute = HeroAttribute.Strength,
            IsMelee = true,
            Health = 740,
            Mana = 243
        },
        new Hero
        {
            Name = "Sniper",
            Attribute = HeroAttribute.Agility,
            IsMelee = false,
            Health = 560,
            Mana = 291
        },
        new Hero
        {
            Name = "Storm Spirit",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 560,
            Mana = 351
        },
        new Hero
        {
            Name = "Tiny",
            Attribute = HeroAttribute.Strength,
            IsMelee = true,
            Health = 700,
            Mana = 291
        },
        new Hero
        {
            Name = "Queen of Pain",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 540,
            Mana = 351
        },
        new Hero
        {
            Name = "Sven",
            Attribute = HeroAttribute.Strength,
            IsMelee = true,
            Health = 680,
            Mana = 255
        },
        new Hero
        {
            Name = "Drow Ranger",
            Attribute = HeroAttribute.Agility,
            IsMelee = false,
            Health = 560,
            Mana = 267
        },
        new Hero
        {
            Name = "Earthshaker",
            Attribute = HeroAttribute.Strength,
            IsMelee = true,
            Health = 700,
            Mana = 255
        },
        new Hero
        {
            Name = "Mirana",
            Attribute = HeroAttribute.Agility,
            IsMelee = false,
            Health = 580,
            Mana = 279
        },
        new Hero
        {
            Name = "Tinker",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 520,
            Mana = 351
        },
        new Hero
        {
            Name = "Anti-Mage",
            Attribute = HeroAttribute.Agility,
            IsMelee = true,
            Health = 620,
            Mana = 195
        },
        new Hero
        {
            Name = "Lion",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 540,
            Mana = 375
        },
        new Hero
        {
            Name = "Witch Doctor",
            Attribute = HeroAttribute.Intelligence,
            IsMelee = false,
            Health = 560,
            Mana = 375
        },
        new Hero
        {
            Name = "Faceless Void",
            Attribute = HeroAttribute.Agility,
            IsMelee = true,
            Health = 640,
            Mana = 243
        },
        new Hero
        {
            Name = "Dawnbreaker",
            Attribute = HeroAttribute.Universal,
            IsMelee = true,
            Health = 640,
            Mana = 303
        }
    ];
}