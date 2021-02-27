using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerPagesMegaDesk.Model

{


    public class Desk
    {
        //constants
        //public const short MIN_WIDTH = 24;
        //public const short MAX_WIDTH = 96;
        //public const short MIN_DEPTH = 12;
        //public const short MAX_DEPTH = 48;
        //public const short MIN_DESK_DRAWERS = 0;
        //public const short MAX_DESK_DRAWERS = 7;

        // prop tab tab to do that thing

        public int DeskId { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        [Display(Name ="Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Surface Material")]
        public int SurfaceMaterialId { get; set; }

        /*navigation properties*/
        public SurfaceMaterial SurfaceMaterial { get; set; }

      /*  static void Main(string[] args) {
            //local variables
            int finalSurfaceArea = 900;
            Desk deskOBJ = new Desk();

            //call getsurfacearea method with desk object
            finalSurfaceArea = deskOBJ.GetSurfaceArea();
        
        }


        //method that calculates surface area
        public int GetSurfaceArea() {
            
           int SA =Convert.ToInt32(Width * Depth);

            return SA;
        }*/




    }
}
