using Project.Entities;

var builder = WebApplication.CreateBuilder();

var app =  builder.Build();

app.MapGet("/heroes", GetHeroesHandler);

app.Run();


void GetHeroesHandler(HttpContext context)
{
    var name = context.Request.Query["name"].ToString();
    
    var heroes = HeroesDataBase.Heroes;

    if (!string.IsNullOrEmpty(name))
        heroes = heroes.Where(hero => hero.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
    
    
    context.Response.WriteAsJsonAsync(heroes);
}