using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForMe.Entities
{
    public class Description
    {


        public int Id { get; set; }
        public string Dec_details { get; set; }
        public int Doctor_Id { get; set; }
        public int Pationt_Id { get; set; }
        public string date { get; set; }


    }
}
