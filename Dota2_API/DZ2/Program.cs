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
        int healthInt = int.Parse(health);
        if (healthLimit == "more")   
            heroes = heroes.Where(hero => hero.Health > healthInt).ToList();
        else if (healthLimit == "less")   
            heroes = heroes.Where(hero => hero.Health < healthInt).ToList();  
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
    await context.Response.WriteAsJsonAsync(hero);
    // Console.WriteLine($"Hero: {hero.Name} {hero.Health}");
}
//          Get /heroes/
void GetHeroHandler(HttpContext context, string name)
{
    var hero = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);
    if (hero == null)
    {
        context.Response.StatusCode = 404;
        context.Response.WriteAsync("Here not found");
    }
    context.Response.WriteAsJsonAsync(hero);
}

async Task UpdateHeroHandler(HttpContext context, string name)
{
    var heroBefore = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);
    
    if( heroBefore == null ){ 
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Hero not found");
    }
    var heroAfter = await context.Request.ReadFromJsonAsync<Hero>();

    if (heroAfter == null)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsJsonAsync("Invalid hero data");
    }
    
    heroBefore.Name = heroAfter.Name;
    heroBefore.Attribute = heroAfter.Attribute;
    heroBefore.IsMelee = heroAfter.IsMelee;
    heroBefore.Health = heroAfter.Health;
    heroBefore.Mana = heroAfter.Mana;

    await context.Response.WriteAsJsonAsync(heroBefore);
}

void DeleteHeroHandler(HttpContext context, string name)
{
    var hero = HeroesDataBase.Heroes.FirstOrDefault(hero => hero.Name == name);

    if (hero == null)
    {
        context.Response.StatusCode = 404;
        context.Response.WriteAsync("Hero not found");
    }
    
    HeroesDataBase.Heroes.Remove(hero);
    context.Response.StatusCode = 204;
}