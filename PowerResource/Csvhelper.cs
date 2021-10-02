using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Security;


namespace PowerResource
{
    public class Csvhelper
    {
        public void WriteOutput(string executablePath, string scriptName, Collection<PSObject> results, Pipeline pipeline, string timeStamp, out bool blnerr)
        {
            blnerr = false;
            var csvDirectory = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Output", scriptName);
            if (!Directory.Exists(csvDirectory))
            {
                Directory.CreateDirectory(csvDirectory);
            }
            var csvPath = Path.Combine(csvDirectory, scriptName + "_" + timeStamp + ".csv");
            Baseclass._strcsvpath = csvPath;
            using (var w = new StreamWriter(csvPath))
            {
                foreach (var psOutput in results)
                {
                    foreach (var prop in psOutput.Properties)
                    {
                       // if (prop.Name != "BaseName") // temp bypass it kindly rmove this condition
                        {
                            if (prop.Name != "Error")
                            {
                                if (prop.Name != "Length")
                                {
                                    var line = string.Format("{0},{1}", prop.Name, Convert.ToString(prop.Value));
                                    w.WriteLine(line);
                                }
                            }
                            else
                            {
                                var errorhandling = new ErrorHandling();
                                errorhandling.CreateAndWriteError(Application.ExecutablePath, scriptName, prop, pipeline, timeStamp);
                                blnerr = true;
                            }
                        }
                    }
                }
                w.Flush();
            }
        }
    }
}
