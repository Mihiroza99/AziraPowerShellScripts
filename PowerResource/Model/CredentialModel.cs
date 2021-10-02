using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource.Model
{
    public class CredentialModel
    {
        public bool SameAsApplication { get; set; }

        public string MachineMode { get; set; }
        public string MachineHostName { get; set; }
        public string MachinePortNumber { get; set; }
        public string MachineUserName { get; set; }
        public string MachinePassword { get; set; }

        public string SqlAuthMode { get; set; }
        public string SqlInstanceName { get; set; }
        public string SqlUserName { get; set; }
        public string SqlPassword { get; set; }
        public string SqlDatabaseName { get; set; }
    }
}
