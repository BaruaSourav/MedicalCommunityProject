using BOLayerMedCom;
using DALayerMedCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayerMedCom
{
    public class PatientsBL
    {
        UnitOfWork uw = new UnitOfWork();
        public List<Patient> getPatientList(int superVisorID)
        {
            var filteredPatients=uw.PatientRepository.Get(filter: d => d.Supervisor.Equals(superVisorID));
            return filteredPatients.ToList();

        }
    }
}
