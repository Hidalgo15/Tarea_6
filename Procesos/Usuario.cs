using System.IO;
using System.Text.Json;

class Usuario{
    public string Cedula { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;

}

class DatosLogin{
    public string Cedula { get; set;} = string.Empty;
    public string Clave { get; set;} = string.Empty;
}

class MenejadorUsuario{

    
    public static ServerResult IniciarSesion(string cedula, string Clave ){

      //  var cedula = datos.Cedula;
      //  var Clave = datos.Clave;


     if (cedula.Length != 11){
        return new ServerResult (false, "La cedula debe tener 11 digitos");
       }
       if (Clave.Length ==0) {
        return new ServerResult (false, "La clave es obligatoria");
       }
    var archivo = $"usuarios/{cedula}.json";

    if (!File.Exists(archivo))
    {
        return new ServerResult (false,"usuario no encontrado");
    }

    var json = File.ReadAllText(archivo);
    var usuario = JsonSerializer.Deserialize<Usuario>(json);

    if (usuario.Clave != Clave){
        return new ServerResult (false,"Clave Incorecta");
    }
    usuario.Clave = "*****";
    return new ServerResult (false,"Sesion Iniciada", usuario);

    }
    


    public static ServerResult Registro (Usuario usuario){
       List <string> errores = new List <string> ();

       if (usuario.Cedula.Length != 11){
        errores.Add ("La cedula debe tener 11 digitos");
       }
       if (usuario.Nombre.Length ==0) {
        errores.Add ("El nombre es obligatorio");
       }

       if (errores.Count > 0){
        System.Console.WriteLine("Errores en el registro:");
        foreach(var error in errores){
            System.Console.WriteLine(error);
        }
        return new ServerResult (false, "Errores en el registro", errores);
       }

        if(!Directory.Exists("usuarios"))
        {
            Directory.CreateDirectory("usuarios");
        }

        var archivo = $"usuarios/{usuario.Cedula}.json";

        if (File.Exists(archivo)){
            return new ServerResult(false, "El usuario ya existe");
        }

        var json= JsonSerializer.Serialize (usuario);
        File.WriteAllText(archivo, json);

        return new ServerResult (true, "Usuario registrado");
    }
}