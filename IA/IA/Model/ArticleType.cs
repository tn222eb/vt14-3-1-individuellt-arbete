using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.Model
{
    public class ArticleType
    {
        public int ArticleTypeID { get; set; }
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
    }
}