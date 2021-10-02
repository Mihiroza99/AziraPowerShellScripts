using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource
{
    public class PowerShellHelper
    {
        public Runspace CreateRunSpace(string executablePath, string scriptName)
        {
            try
            {
                var credential = new Credentialhelper();
                var model = credential.GetCredentials(executablePath, scriptName);
                if (model.MachineMode != "w" && model.MachineHostName != "localhost")
                {
                    var secureString = new SecureString();
                    PowerShell instance = PowerShell.Create();
                    instance.AddScript(string.Format("ConvertTo-SecureString {0} -AsPlainText -Force", model.MachinePassword));
                    foreach (PSObject psOutput in instance.Invoke())
                    {
                        secureString = psOutput.BaseObject as SecureString;
                    }
                    var remoteCredential = new PSCredential(model.MachineUserName, secureString);
                    var connectionInfo = new WSManConnectionInfo();
                    connectionInfo.ComputerName = model.MachineHostName;
                    connectionInfo.Credential = remoteCredential;
                    var runspace = RunspaceFactory.CreateRunspace(connectionInfo);
                    return runspace;
                }
                else
                {
                    return RunspaceFactory.CreateRunspace();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error Occured.for more detail kindly check event Log!!\r\n" + "\r\n" + ex.Message.ToString(), "Error Message");
                throw ex;
            }
        }
    }
}
