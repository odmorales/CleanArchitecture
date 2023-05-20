
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
//await QueryLinq();
//await AddNewStreamerWithVideo();
//await AddNewActorWithVideo();
//await AddNewDirectorWithVideo();
await MultipleEntitiesQuery();


Console.WriteLine("Escriba cualquier letra para salir");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videWithActors = await dbContext.Videos!.Include(x => x.Actors).FirstOrDefaultAsync(x => x.Id == 1);
    //var actor = await dbContext.Actors!.Select(x => x.Nombre).ToListAsync();
    var videoWithDirector = await dbContext!.Videos!
                            .Where(x => x.Director != null)
                            .Include(x => x.Director)
                            .Select(q =>
                                new {
                                    Director_Nombre_Completo = $"{ q.Director!.Nombre } { q.Director.Apellido }",
                                    Movie = q.Nombre
                                }
                             ).ToListAsync();

    foreach (var movie in videoWithDirector)
    {
        Console.WriteLine($"{movie.Director_Nombre_Completo} -- {movie.Movie}");
    }
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };
    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };

    var humgerGames = new Video
    {
        Nombre = "Humger Games",
        Streamer = pantaya
    };
    await dbContext.AddAsync(humgerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrakingAndNotTraking()
{
    var streamerWithTraking = await dbContext.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNotTraking = await dbContext.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTraking.Nombre = "Netflix Super";
    streamerWithNotTraking.Nombre = "Amazon Plus";

    await dbContext.SaveChangesAsync();

}

async Task QueryLinq()
{

    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers 
                           where EF.Functions.Like(i.Nombre!, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} -- {streamer.Nombre}");
    }
}

async Task QueryMethods()
{
    var streamer = dbContext.Streamers;

    var streamer1 = await streamer!.Where(x => x.Nombre!.Contains("a")).FirstAsync();

    var streamer2 = await streamer!.Where(x => x.Nombre!.Contains("a")).FirstOrDefaultAsync();

    var streamer3 = await streamer!.FirstOrDefaultAsync(x => x.Nombre!.Contains("a"));

    var singleAsync = await streamer!.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer!.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamer!.FindAsync(1);
}

async Task QueryFilter()
{
    var streamers = await dbContext.Streamers!.Where(x => x.Nombre == ("Netfix")).ToListAsync();

    foreach(var streamer in streamers)
    {
       Console.WriteLine($"{streamer.Id} -- {streamer.Nombre}");
    }
}

void QueryStreaming()
{
    var stramers = dbContext!.Streamers!.ToList();

    foreach(var streamer in stramers)
    {
        Console.WriteLine($"{streamer.Id} -- {streamer.Nombre}");
    };
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "URL"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    var movies = new List<Video>()
    {
        new Video()
        {
            Nombre = "La Cenicienta",
            StreamerId = streamer.Id
        },
        new Video()
        {
            Nombre = "Crepusculo",
            StreamerId = streamer.Id
        },
        new Video()
        {
            Nombre = "Jack el destripador",
            StreamerId = streamer.Id
        },
        new Video()
        {
            Nombre = "Piratas del Caribe",
            StreamerId = streamer.Id
        },
    };

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}