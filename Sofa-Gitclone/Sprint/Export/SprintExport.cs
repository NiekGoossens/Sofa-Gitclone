using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.Export {
    public interface SprintExport {
        void CreateExport(Sprint sprint, string Header, string Footer);
    }
}
