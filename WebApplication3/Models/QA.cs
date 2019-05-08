using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class QA
    {   
            [Key]
            public string Title { get; set; }

            public string EditorName { get; set; }

            public string InfoContent { get; set; }
        
    }
}