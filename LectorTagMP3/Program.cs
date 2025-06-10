using Id3v1Ta;

Id3v1Tag cancion = new Id3v1Tag("Runaway");
Console.WriteLine($"Cancion: {cancion.nombre}");
Console.WriteLine("Tag: ");
cancion.Tag();
Console.WriteLine("Año: ");
cancion.Anio();
Console.WriteLine("Album: ");
cancion.Album();
Console.WriteLine("Artista: ");
cancion.Artista();
Console.WriteLine("Genero: ");
cancion.Genero();
Console.WriteLine("Comentarios: ");
cancion.Comentario();
