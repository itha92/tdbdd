using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Normalizar
{
    class ListBoxItem
    {
        public string value1 { get; set; }
        public string value2 { get; set; }

        public override string ToString()
        {
            return value1 + "->" + value2;
        }

        public ListBoxItem(string val1, string val2)
        {
            this.value1 = val1;
            this.value2 = val2;
        }
    }
}
