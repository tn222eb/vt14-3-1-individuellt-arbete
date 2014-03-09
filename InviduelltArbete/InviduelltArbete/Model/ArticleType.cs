using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InviduelltArbete.Model
{
    public class ArticleType
    {
        public int ArticleTypeID { get; set; }
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
    }
}