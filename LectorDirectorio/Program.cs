Console.WriteLine("Ingrese un directorio a analizar");
string directorio = Console.ReadLine();


while (!System.IO.Directory.Exists(directorio))
{
    Console.WriteLine("El directorio no existe");
    directorio = Console.ReadLine();
}

string[] directorios = System.IO.Directory.GetDirectories(directorio);

string[] archivos = System.IO.Directory.GetFiles(directorio);
FileInfo[] infoarchivos = new FileInfo[archivos.Length];
for (int i = 0; i < archivos.Length; i++)
{
    infoarchivos[i] = new FileInfo(archivos[i]);
}

Console.WriteLine($"*******************{directorio}*******************");

for (int i = 0; i < directorios.Count(); i++)
{
    Console.WriteLine($"\t> {directorios[i]}");
}
for (int i = 0; i < archivos.Length; i++)
{
    Console.WriteLine($"\t {archivos[i]}   {infoarchivos[i].Length / 1000} KB");
}

FileStream archivo = new FileStream("reportes_archivos.csv", FileMode.Append);
for (int i = 0; i < archivos.Length; i++)
{
    using (StreamWriter strwriter = new StreamWriter(archivo))
    {
        strwriter.Write($"Nombre: {infoarchivos[i].Name}  Tamaño (KB): {infoarchivos[i].Length}  Ultima Fecha de Modificacion: {infoarchivos[i].LastWriteTime} \n");
        strwriter.Close();
    }
}


