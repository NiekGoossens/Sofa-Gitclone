using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.Export {
    public class PngExport : SprintExport {
        public void CreateExport(Sprint sprint, string Header, string Footer) {
            Sprint sprint2 = sprint.GetVariables();
            var ResultString = Header + "\n" + sprint2.project.Name + " " + sprint2.name + " " + sprint2.startDate + "\n" + Footer;
            Console.WriteLine("Exporting to Png");
            Console.WriteLine("Sprint export: " + ResultString);


        }
    }
}
