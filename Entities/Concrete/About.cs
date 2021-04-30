using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public  class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(500)]
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string  AboutImage { get; set; }
        public string AboutImage2 { get; set; }
    }
}
