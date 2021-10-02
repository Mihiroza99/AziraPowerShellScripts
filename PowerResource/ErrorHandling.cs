using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource
{
    public class ErrorHandling
    {
        public void CreateAndWriteError(string executablePath, string scriptName, PSPropertyInfo prop, Pipeline pipeline, string timeStamp) {
            var errorDirectory = Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "Error", scriptName);
            if (!Directory.Exists(errorDirectory))
            {
                Directory.CreateDirectory(errorDirectory);  
            }
            var errorPath = Path.Combine(errorDirectory, scriptName + "_" + timeStamp + ".txt");
            Baseclass._strerrpath = errorPath;
            using (var err = new StreamWriter(errorPath))
            {
                var line = string.Format("{0},{1}", prop.Name, prop.Value);
                err.WriteLine(line);
                err.WriteLine("\r\n");
                err.WriteLine("\r\n");
                err.WriteLine("\r\n");
                if (pipeline.Error.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    //iterate over Error PipeLine until end
                    while (!pipeline.Error.EndOfPipeline)
                    {
                        //read one PSObject off the pipeline
                        var value = pipeline.Error.Read() as PSObject;
                        if (value != null)
                        {
                            //get the ErrorRecord
                            var r = value.BaseObject as ErrorRecord;
                            if (r != null)
                            {
                                //build whatever kind of message your want
                                builder.AppendLine(r.InvocationInfo.MyCommand.Name + " : " + r.Exception.Message);
                                builder.AppendLine(r.InvocationInfo.PositionMessage);
                                builder.AppendLine(string.Format("+ CategoryInfo: {0}", r.CategoryInfo));
                                builder.AppendLine(string.Format("+ FullyQualifiedErrorId: {0}", r.FullyQualifiedErrorId));
                            }
                        }
                    }
                    err.WriteLine(builder.ToString());
                }
            }
        }
    }
}
