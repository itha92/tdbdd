using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Normalizar
{
    class ComboboxItem
    {
        public string text { get; set; }
        public string val { get; set; }

        public override string ToString()
        {
            return text;
        }
    }
}
