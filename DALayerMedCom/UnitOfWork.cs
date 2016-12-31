using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;


namespace DALayerMedCom
{
   public class UnitOfWork:IDisposable
    {
        private MediyardDBEntities1 context = new MediyardDBEntities1();
        private GenericRepository<Doctor> doctorRepository;
        private GenericRepository<District> districtRepository;
        private GenericRepository<Region> regionRepository;
        private GenericRepository<Patient> patientRepository;


        //pub prop for DoctorRepo
        public GenericRepository<Doctor> DoctorRepository
        {
            get
            {
                if (this.doctorRepository== null)
                {
                    this.doctorRepository = new GenericRepository<Doctor>(context);
                }
                return doctorRepository;
            }
        }
        //pub prop for DistrictRepo
        public GenericRepository<District> DistrictRepository
        {

            get
            {
                if(this.districtRepository==null)
                {
                    this.districtRepository = new GenericRepository<District>(context);
                }
                return districtRepository;
            }
        }
        public GenericRepository<Region> RegionRepository
        {
            get
            {
                if (this.regionRepository == null)
                {
                    this.regionRepository = new GenericRepository<Region>(context);
                }
                return regionRepository;
            }
        }
        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this.patientRepository == null)
                {
                    this.patientRepository = new GenericRepository<Patient>(context);
                }
                return patientRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
