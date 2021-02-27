using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazerPagesMegaDesk.Model
{
    public class SurfaceMaterial
    {
        //add properties for less than 1k square inches, between 1k and 2k, and more than 2k
        public int SurfaceMaterialId { get; set; }

        [Display(Name ="Surface Material")]
        public string SurfaceMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}
