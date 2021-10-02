using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource.Model
{
    public class ParameterModel
    {
        public int id { get; set; }
        public string item { get; set; }
        public string Tooltip { get; set; }
        public bool Checked { get; set; }
        public string Value { get; set; }
    }
}
