using Newtonsoft.Json;
using PowerResource.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerResource.Helper
{
    public class ProfileHelper
    {
        public static Dictionary<string, bool> GetScritsProfileStatus()
        {
            var returnValue = new Dictionary<string, bool>();
            var jsonDirectory = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Profile");
            if (Directory.Exists(jsonDirectory))
            {
                var applicationProfile = Path.Combine(jsonDirectory, ApplicationInformation.scriptName + ".json");
                var iisInformationProfile = Path.Combine(jsonDirectory, IISInformation.scriptName + ".json");
                var sqlServerProfile = Path.Combine(jsonDirectory, SQLServer.scriptName + ".json");
                var sqlServerDiagnosticsProfile = Path.Combine(jsonDirectory, SQLServerDiagnostics.scriptName + ".json");
                var ssasProfile = Path.Combine(jsonDirectory, SSASConfiguration.scriptName + ".json");
                var ssrsProfile = Path.Combine(jsonDirectory, SSRSConfiguration.scriptName + ".json");
                //var eventLogProfile = Path.Combine(jsonDirectory, EventLog.scriptName + ".json");

                if (!File.Exists(applicationProfile))
                {
                    returnValue.Add(ApplicationInformation.scriptName, false);
                }
                if (!File.Exists(iisInformationProfile))
                {
                    returnValue.Add(IISInformation.scriptName, false);
                }
                if (!File.Exists(sqlServerProfile))
                {
                    returnValue.Add(SQLServer.scriptName, false);
                }
                if (!File.Exists(sqlServerDiagnosticsProfile))
                {
                    returnValue.Add(SQLServerDiagnostics.scriptName, false);
                }
                if (!File.Exists(ssasProfile))
                {
                    returnValue.Add(SSASConfiguration.scriptName, false);
                }
                if (!File.Exists(ssrsProfile))
                {
                    returnValue.Add(SSRSConfiguration.scriptName, false);
                }
                //if (!File.Exists(eventLogProfile))
                //{
                //    returnValue.Add(EventLog.scriptName, false);
                //}
            }

            return returnValue;
        }

        public T GetProfileData<T>(string executablePath, string scriptName) where T : class
        {
            var jsonDirectory = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Profile");
            string strjsonpath = Path.Combine(jsonDirectory, scriptName + ".json");
            if (File.Exists(strjsonpath))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(strjsonpath));
            }
            else
            {
                var _rootpath = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Resources");//.Substring(0, System.IO.Path.GetDirectoryName(Application.ExecutablePath).Length - 10) + "\\Resources";
                var _configpath = Path.Combine(_rootpath, scriptName + ".json");
                var returnValue = JsonConvert.DeserializeObject<T>(File.ReadAllText(_configpath));
                var credentialModel = new Credentialhelper();
                SetValue(returnValue, "Credential", credentialModel.credential);
                return returnValue;
            }
        }

        private void SetValue(object theObject, string theProperty, object theValue)
        {
            var msgInfo = theObject.GetType().GetProperty(theProperty);
            msgInfo.SetValue(theObject, theValue, null);
        }

        private T GetValue<T>(object rootObject, PropertyInfo obj)
        {
            return (T)obj.GetValue(rootObject, null);
        }

        public T SetProfileData<T>(string executablePath, string scriptName, T FormElements, CheckedListBox chklstApp) where T : class
        {
            try
            {
                //var credentialProperty = FormElements.GetType().GetProperty("Credential");
                //var credentialValue = GetValue<CredentialModel>(FormElements, credentialProperty);
                //SetValue(credentialValue, "MachineMode", Baseclass._strappmode);
                //SetValue(credentialValue, "MachineHostName", Baseclass._strappip);
                //SetValue(credentialValue, "MachinePortNumber", Baseclass._strappport);
                //SetValue(credentialValue, "MachineUserName", Baseclass._strappuname);
                //SetValue(credentialValue, "MachinePassword", Baseclass._strapppwd);
                //SetValue(credentialValue, "SqlAuthMode", Baseclass._strsqlmode);
                //SetValue(credentialValue, "SqlInstanceName", Baseclass._strsqlhostname);
                //SetValue(credentialValue, "SqlUserName", Baseclass._strsqlunm);
                //SetValue(credentialValue, "SqlPassword", Baseclass._strsqlpwd);
                //SetValue(credentialValue, "SqlDatabaseName", Baseclass._strsqldatabase);

                var parameters = FormElements.GetType().GetProperty(scriptName);
                var items = GetValue<ParameterModel[]>(FormElements, parameters);
                foreach (var item in items)
                {
                    var selected = chklstApp.CheckedItems.Cast<ParameterModel>();
                    if (selected.Any(s => s.Tooltip == item.Tooltip && s.item == item.item))
                    {
                        item.Checked = true;
                    }
                }

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(FormElements);
                var jsonDirectory = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Profile");
                if (!Directory.Exists(jsonDirectory))
                {
                    Directory.CreateDirectory(jsonDirectory);
                }
                string strjsonpath = Path.Combine(jsonDirectory, scriptName + ".json");
                System.IO.File.WriteAllText(strjsonpath, json);

                return FormElements;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetBaseClassValues(BaseModel FormElements)
        {
            Baseclass._strappmode = FormElements.Credential.MachineMode;
            Baseclass._strappip = FormElements.Credential.MachineHostName;
            Baseclass._strappport = FormElements.Credential.MachinePortNumber;
            Baseclass._strappuname = FormElements.Credential.MachineUserName;
            Baseclass._strapppwd = FormElements.Credential.MachinePassword;
            Baseclass._strsqlmode = FormElements.Credential.SqlAuthMode;
            Baseclass._strsqlhostname = FormElements.Credential.SqlInstanceName;
            Baseclass._strsqldatabase = FormElements.Credential.SqlDatabaseName;
            Baseclass._strsqlunm = FormElements.Credential.SqlUserName;
            Baseclass._strsqlpwd = FormElements.Credential.SqlPassword;
        }

        public bool CheckForDefaultCredential()
        {
            if (!Baseclass._IsdefaultCredentialSet)
            {
                MessageBox.Show("Neither the Profile nor the default credential set for moving further execution. Please add required credential to move further.");
            }

            return Baseclass._IsdefaultCredentialSet;
        }
    }
}