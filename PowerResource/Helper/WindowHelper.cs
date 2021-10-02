using PowerResource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerResource.Helper
{
    public class WindowHelper
    {
        public T BindCheckBoxList<T>(string executionPath, string scriptName, CheckedListBox chklstApp) where T : class
        {
            var profile = new ProfileHelper();
            var returnValue = profile.GetProfileData<T>(executionPath, scriptName);
            BindingSource bs1 = new BindingSource(returnValue, scriptName);
            chklstApp.DataSource = bs1;
            chklstApp.DisplayMember = "item";
            chklstApp.ValueMember = "id";

            for (int i = 0; i < chklstApp.Items.Count; i++)
            {
                var obj = (ParameterModel)chklstApp.Items[i];
                chklstApp.SetItemChecked(i, obj.Checked);
            }

            return returnValue;
        }

        //public T SetCredentials<T>() where T : class
        //{
        //    if (chkssrscred.Checked)
        //    {
        //        FormElements.Credential.MachineMode = Baseclass._strappmode;
        //        FormElements.Credential.MachineHostName = Baseclass._strappip;
        //        FormElements.Credential.MachinePortNumber = Baseclass._strappport;
        //        FormElements.Credential.MachineUserName = Baseclass._strappuname;
        //        FormElements.Credential.MachineUserName = Baseclass._strapppwd;

        //        FormElements.Credential.SqlAuthMode = Baseclass._strsqlmode;
        //        FormElements.Credential.SqlInstanceName = Baseclass._strsqlhostname;
        //        FormElements.Credential.SqlUserName = Baseclass._strsqlunm;
        //        FormElements.Credential.SqlPassword = Baseclass._strsqlpwd;
        //        FormElements.Credential.SqlDatabaseName = Baseclass._strsqldatabase;
        //    }
        //    else
        //    {
        //        if (rbtnapplocal.Checked)
        //        {
        //            FormElements.Credential.MachineMode = "w";
        //            FormElements.Credential.MachineHostName = "localhost";
        //            FormElements.Credential.MachinePortNumber = "80";
        //            _strappuname = " ";
        //            _strapppwd = " ";
        //        }
        //        if (rbtnappnetwork.Checked)
        //        {
        //            _strappmode = "network";
        //            _strappip = Convert.ToString(txtappip.Text);
        //            _strappport = Convert.ToString(txtappport.Text);
        //            _strappuname = Convert.ToString(txtappuname.Text);
        //            _strapppwd = Convert.ToString(txtapppwd.Text);
        //        }

        //        if (rbtnsqlwin.Checked)
        //        {
        //            _strsqlmode = "w";
        //            _strsqlhostname = " ";
        //            _strsqlunm = " ";
        //            _strsqlpwd = " ";
        //        }
        //        if (rbtnsql.Checked)
        //        {
        //            _strsqlmode = "network";
        //            _strsqlhostname = Convert.ToString(txtsqlhost.Text);
        //            _strsqlunm = Convert.ToString(txtsqllogin.Text);
        //            _strsqlpwd = Convert.ToString(txtsqlpass.Text);
        //        }
        //        _strsqldatabase = Convert.ToString(txtsqldatabase.Text) == "" ? " " : Convert.ToString(txtsqldatabase.Text);
        //    }
        //}
    }
}
