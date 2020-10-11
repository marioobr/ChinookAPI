using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class AlbumArtista
    {
        public string TituloAlbum {get; set;}
        public string NombreArtista { get; set; }
        public AlbumArtista(string titulo,string nombreArtista)
        {
            TituloAlbum = titulo;
            NombreArtista = nombreArtista;
        }
    }
}
