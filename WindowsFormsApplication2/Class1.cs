using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DB_Normalization
{
     public class Combinations {

    private StringBuilder output = new StringBuilder();
    private  String inputstring;
    private List<String> Permutations = new List<String>();
    public Combinations(  String str ){
        inputstring = str;
        combine();
    }
    
    public void combine() { combine( 0 ); }
    private void combine(int start ){
        for( int i = start; i < inputstring.Length; ++i ){
            output.Append( inputstring[i] );
            
            Permutations.Add(output.ToString());
            if ( i < inputstring.Length )
            combine( i + 1);
            output.Length = ( output.Length - 1 );
        }
    }

    public List<String> GetPermutations() {
        return Permutations;
    }
} 
}
