using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerResource.Model
{
    public class ApplicationModel : BaseModel
    {
        ApplicationModel() { }

        ApplicationModel(ApplicationModel obj) {
            this.ApplicationInformation = obj.ApplicationInformation;
            //this.ApplicationPath = obj.ApplicationPath;
        }
        public ParameterModel[] ApplicationInformation { get; set; }
       // public ParameterModel ApplicationPath { get; set; }
    }
}
