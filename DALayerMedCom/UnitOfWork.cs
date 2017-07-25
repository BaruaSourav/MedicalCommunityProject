using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DALayerMedCom
{
   public class UnitOfWork:IDisposable
    {
        private MediyardDBEntities1 context;
        private GenericRepository<Doctor> doctorRepository;
        private GenericRepository<District> districtRepository;
        private GenericRepository<Region> regionRepository;
        private GenericRepository<Patient> patientRepository;
        private GenericRepository<Admin> adminRepository;
        private GenericRepository<Appointment> appointmentRepository;

        //injecting the context:DBContext
        public UnitOfWork(DbContext paramContext)
        {
            this.context = (MediyardDBEntities1) paramContext;
        }





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

        public GenericRepository<Admin> AdminRepository
        {
            get
            {
                if (this.adminRepository == null)
                {
                    this.adminRepository = new GenericRepository<Admin>(context);
                }
                return adminRepository;
            }
        }

        //pub prop for appointment
        public GenericRepository<Appointment> AppointmentRepository
        {
            get
            {
                if (this.appointmentRepository == null)
                {
                    this.appointmentRepository = new GenericRepository<Appointment>(context);
                }
                return appointmentRepository;
            }
        }

        public void Save()
        {
            
            try
            {
                

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
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
