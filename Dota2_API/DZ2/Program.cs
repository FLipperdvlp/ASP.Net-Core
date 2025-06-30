using Project.Entities;

var builder = WebApplication.CreateBuilder();
var app =  builder.Build();
app.MapGet("/heroes", GetHeroesHandler);
app.Run();
void GetHeroesHandler(HttpContext context)
{
    var name = context.Request.Query["name"].ToString();
    var health = context.Request.Query["health"].ToString();
    var healthLimit = context.Request.Query["health_limit"].ToString();
    
    var heroes = HeroesDataBase.Heroes;

    if (!string.IsNullOrEmpty(health))  {
        int health_ = int.Parse(health);
        
        if      (healthLimit == "more")   heroes = heroes.Where(hero => hero.Health > health_).ToList();
        else if (healthLimit == "less")   heroes = heroes.Where(hero => hero.Health < health_).ToList();  }
    else if (!string.IsNullOrEmpty(name)) heroes = heroes.Where(hero => hero.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
    else context.Response.StatusCode = 404;
    context.Response.WriteAsJsonAsync(heroes);
}