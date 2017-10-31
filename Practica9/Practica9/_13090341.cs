using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using Newtonsoft.Json;
namespace Practica9
{
    public class _13090341
    {
        internal bool Done;
        string matricula;
        string nombre;
        string apellidos;
        string direccion;
        string telefono;
        string carrera;
        string semestre;
        string correo;
        string github;
        bool deleted;

        [JsonProperty(PropertyName = "id")]
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "apellidos")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [JsonProperty(PropertyName = "telefono")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [JsonProperty(PropertyName = "carrera")]
        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        [JsonProperty(PropertyName = "semestre")]
        public string Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [JsonProperty(PropertyName = "correo")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        [JsonProperty(PropertyName = "github")]
        public string Github
        {
            get { return github; }
            set { github = value; }
        }
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

    }
}
