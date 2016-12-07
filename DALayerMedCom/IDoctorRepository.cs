using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;

namespace DALayerMedCom
{
   public interface IDoctorRepository:IDisposable
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorByID(int DocID);
        void InsertDoctor(Doctor doctor);
        void DeleteDoctor(int DocID);
        void UpdateDoctor(Doctor doctor);
        void Save();

    }
}
