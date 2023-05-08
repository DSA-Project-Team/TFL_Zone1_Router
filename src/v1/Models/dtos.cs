using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tflzone1.Models
{
    public class dtos
    {
        
    }

    public record AddDelayDTO (string startLine, string startStation, string nextLine, string nextStation, int delay);
}