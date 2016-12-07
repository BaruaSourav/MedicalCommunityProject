using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using System.Data.Entity;

namespace DALayerMedCom
{
    public class DoctorRepository:IDoctorRepository,IDisposable
    {
        private MediyardDBEntities1 context;
        
        public DoctorRepository(MediyardDBEntities1 paramContext)
        {
            this.context = paramContext;
        }
       public IEnumerable<Doctor> GetDoctors()
        {
            return context.Doctors.ToList();
        }

        public Doctor GetDoctorByID(int DocID)
        {
            return context.Doctors.Find(DocID);
        }
        public void InsertDoctor(Doctor doctor)
        {
            context.Doctors.Add(doctor);
        }
        public void DeleteDoctor(int DocID)
        {
            Doctor doctor =context.Doctors.Find(DocID);
            context.Doctors.Remove(doctor);
        }
        public void UpdateDoctor(Doctor doctor)
        {
            context.Entry(doctor).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        /// <summary>
        /// Implementing the dispose function for IDisposable and making a public method to call this dispose, 
        /// A bool named disposed is taken to know the current disposing status of this class and 
        /// set to false.
        /// </summary>
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
