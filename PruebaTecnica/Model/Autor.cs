namespace Model
{
    using System;
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public int CantidadLibros { get; set; }
        public int IdPais { get; set; }
        public int IdCiudad { get; set; }
        public string IdSexo { get; set; }
    }
}
