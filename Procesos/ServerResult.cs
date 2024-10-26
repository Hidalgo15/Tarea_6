class ServerResult{
    public bool Exito { get; set; }
    public string Mensaje { get; set; }
    public object Datos { get; set; }

    public ServerResult (bool exito,string Mensaje ,object datos){
        Exito = exito;
        Mensaje = Mensaje;
        Datos = datos;
    }
    
    public ServerResult (bool exito,string Mensaje){
        Exito = exito;
        Mensaje = Mensaje;
    }

    public ServerResult (bool exito){
        Exito = exito;
    }

    public ServerResult (){
        Exito = true;
    }

}