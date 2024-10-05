using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP_RODRIGUEZ.Models;

namespace EP_RODRIGUEZ.ViewModel
{
    public class RemesasViewModel
    {
        public Remesas? FormRemesas  {get; set;}
        public IEnumerable<Remesas>? ListRemesas  {get; set;}
    }
}