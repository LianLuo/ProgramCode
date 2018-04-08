using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.LabStore.DbModel;

namespace HW.LabStore.BusinessModel
{
    public class PEPBusinessComponent
    {
        private mallStoreEntities Context
        {
            get { return new mallStoreEntities();}
        }
    }
}
