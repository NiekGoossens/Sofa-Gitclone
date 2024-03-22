using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.Export {
    public class PngExport : SprintExport {
        public void CreateExport(Sprint sprint) {

            Console.WriteLine("Exporting to Png");
            Sprint sprint2 = sprint.GetVariables();
            Console.WriteLine("Exporting Sprint: " + sprint2.name);
            Console.WriteLine("Exporting Sprint: " + sprint.GetVariables);


        }
    }
}
