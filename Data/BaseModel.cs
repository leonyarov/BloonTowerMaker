using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonTowerMaker.Data
{
    class BaseModel
    {
        //tower category
        public string set; 
        //base tower to inherit from
        public string basetower; 
         //cost of the tower
        public string cost; 
        //path count
        public string top, buttom,middle; 
        //tower description
        public string description; 
        //paragon setting
        public string paragon; 
        //tower type - ranged / close range (not implemented)
        public string type; 
        // upgrade name (tower name)
        public string name; 

        //image reference
        //big icon
        public string portrait;
        //upgrade icon
        public string display;
        //projectile file
        public string projectile;



        //basic stats
        public string range, projectile_range, damage, pierce,projectile_speed; 
    }
}