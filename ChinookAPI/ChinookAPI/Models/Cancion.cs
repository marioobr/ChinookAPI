using System;
using System.Collections.Generic;

namespace ChinookAPI.Models
{
    public partial class Cancion
    {
        public Cancion()
        {
          
        }

        public int CancionId { get; set; }
        public string Nombre { get; set; }
       
        public int AlbumId { get; set; }

        public int GeneroId { get; set; }


    }
}
