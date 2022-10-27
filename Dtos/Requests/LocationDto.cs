using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class LocationDto
    {
        [Required]
        [Range(-90.0, 90.0)]
        public double Latitude { get; set; }
        [Required]
        [Range(-90.0, 90.0)]
        public double Longitude { get; set; }
    }
}
