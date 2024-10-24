using System.ComponentModel.DataAnnotations;

namespace colegio.Models;

public class Tipos_sangre
{
    [Key]
    public Int32 id_tipo_sangre { get; set; }
    public string? sangre { get; set; } 
}

public class Estudiantes
{
    [Key]
    public Int32 id_estudiante { get; set; }
    public string? carne { get; set; } 
    public string? nombres { get; set; } 
    public string? apellidos { get; set; } 
    public string? direccion { get; set; } 
    public string? telefono { get; set; } 
    public string? correo_electronico { get; set; } 
    public Int32 id_tipo_sangre { get; set; } 
    public DateTime? fecha_nacimiento { get; set; } 

}