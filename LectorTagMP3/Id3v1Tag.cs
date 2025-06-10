using System.Security.Cryptography.X509Certificates;

namespace Id3v1Ta;

class Id3v1Tag
{
    public string nombre;
    byte[] data = new byte[128];
    public Id3v1Tag(string cancion)
    {
        this.nombre = cancion;
        string[] archivosmp3 = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.mp3");
        string ruta = archivosmp3.FirstOrDefault(x => Path.GetFileName(x) == this.nombre + ".mp3");
        using (FileStream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read))
        {
            archivo.Seek(-128, SeekOrigin.End);
            using (BinaryReader reader = new BinaryReader(archivo, System.Text.Encoding.ASCII))
            {
                reader.Read(data, 0, 128);
            }
        }
    }

    public void Tag()
    {
        string tag = System.Text.Encoding.ASCII.GetString(this.data,0,3);
        Console.WriteLine($"{tag}");
    }
    public void Titulo()
    {
        string titulo = System.Text.Encoding.ASCII.GetString(this.data,3,30);
        Console.WriteLine($"{titulo}");
    }
    public void Artista()
    {
        string artista = System.Text.Encoding.ASCII.GetString(this.data,33,30);
        Console.WriteLine($"{artista}");
    }
    public void Album()
    {
        string album = System.Text.Encoding.ASCII.GetString(this.data,63,30);
        Console.WriteLine($"{album}");
    }
    public void Anio()
    {
        string anio = System.Text.Encoding.ASCII.GetString(this.data,93,4);
        Console.WriteLine($"{anio}");
    }
    public void Comentario()
    {
        string comentario = System.Text.Encoding.ASCII.GetString(this.data,97,30);
        Console.WriteLine($"{comentario}");
    }
    public void Genero()
    {
        string genero = System.Text.Encoding.ASCII.GetString(this.data,127,1);
        Console.WriteLine($"{genero}");
    }
}