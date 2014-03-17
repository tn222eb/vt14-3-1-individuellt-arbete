using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.Model
{
    // Den fick ej ha samma namn som egenskapen Category så döpte om den 
    // istället för ändra på egenskapen för jag vill den ska stämma fältet i databasen
    public class Categoryy
    {
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}