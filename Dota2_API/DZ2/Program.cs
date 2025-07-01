using Project.Entities;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();//example of the server

app.MapGet("/heroes", GetHeroesHandler);
app.MapGet("/heroes/{name}", GetHeroHandler);
app.MapPost("/heroes", CreateHeroHandler);
app.MapPut("/heroes/{name}", UpdateHeroHandler);
app.MapDelete("/heroes/{name}", DeleteHeroHandler);

app.Run();//Start server 

void GetHeroesHandler(HttpContext context)
{
    var name = context.Request.Query["name"].ToString();
    var health = context.Request.Query["health"].ToString();
    var healthLimit = context.Request.Query["health_limit"].ToString();
    
    var heroes = HeroesDataBase.Heroes;

    if (!string.IsNullOrEmpty(health)) 
    {
        int health_ = int.Parse(health);
        if (healthLimit == "more")   
            heroes = heroes.Where(hero => hero.Health > health_).ToList();
        else if (healthLimit == "less")   
            heroes = heroes.Where(hero => hero.Health < health_).ToList();  
    }
    else if (!string.IsNullOrEmpty(name)) 
        heroes = heroes.Where(hero => hero.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
    else 
    {
        context.Response.StatusCode = 404;
        return;
    }
    context.Response.WriteAsJsonAsync(heroes);
}

async Task CreateHeroHandler(HttpContext context)
{
    Hero? hero = await context.Request.ReadFromJsonAsync<Hero>();
    
    if (hero == null) 
        throw new Exception("Error converting json to hero");
    
    HeroesDataBase.Heroes.Add(hero);
    
    context.Response.StatusCode = 201;
    context.Response.WriteAsJsonAsync(hero);
    // Console.WriteLine($"Hero: {hero.Name} {hero.Health}");
}
//          Get /heroes/
void GetHeroHandler(HttpContext context, string name)
{
    var hero = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);
    context.Response.WriteAsJsonAsync(hero);
}

async Task UpdateHeroHandler(HttpContext context, string name)
{
    var hero_before = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);
    var hero_after = await context.Request.ReadFromJsonAsync<Hero>();
    
    hero_before.Name = hero_after.Name;
    hero_before.Attribute = hero_after.Attribute;
    hero_before.IsMelee = hero_after.IsMelee;
    hero_before.Health = hero_after.Health;
    hero_before.Mana = hero_after.Mana;

    context.Response.WriteAsJsonAsync(hero_before);
}

void DeleteHeroHandler(HttpContext context, string name)
{
    var hero = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);
    
    HeroesDataBase.Heroes.Remove(hero);
    context.Response.StatusCode = 204;
}