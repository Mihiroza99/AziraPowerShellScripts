using Newtonsoft.Json;
using PowerResource.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource
{
    public class Credentialhelper
    {
        public CredentialModel credential { get; set; }

        public Credentialhelper()
        {
            var credential = new CredentialModel();
            credential.MachineMode = Baseclass._strappmode;
            credential.MachineHostName = Baseclass._strappip;
            credential.MachinePortNumber = Baseclass._strappport;
            credential.MachineUserName = Baseclass._strappuname;
            credential.MachinePassword = Baseclass._strapppwd;

            credential.SqlAuthMode = Baseclass._strsqlmode;
            credential.SqlInstanceName = Baseclass._strsqlhostname;
            credential.SqlDatabaseName = Baseclass._strsqldatabase;
            credential.SqlUserName = Baseclass._strsqlunm;
            credential.SqlPassword = Baseclass._strsqlpwd;
            this.credential = credential;
        }

        public CredentialModel GetCredentials(string executablePath, string scriptName)
        {
            var jsonDirectory = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Profile");
            string strjsonpath = Path.Combine(jsonDirectory, scriptName + ".json");
            if (File.Exists(strjsonpath))
            {
                var dd = JsonConvert.DeserializeObject<BaseModel>(File.ReadAllText(strjsonpath));
                this.credential = dd.Credential;
            }

            return this.credential;
        }
    }

    public class tmpCredential
    {
        public string machinemode { get; set; }
        public string machineip { get; set; }
        public string machineport { get; set; }
        public string machineuname { get; set; }
        public string machinepwd { get; set; }
    }
}
