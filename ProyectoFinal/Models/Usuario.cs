namespace ProyectoFinal.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }


        //FK
        public int usuario_rol { get; set; }
        //OBJETO ROL
        public  Roles? rolAsociado { get; set; }


    }
}
