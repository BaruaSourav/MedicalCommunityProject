using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayerMedCom;
using DALayerMedCom;
using BOLayerMedCom.ViewModels;
using System.Web.Security;
using System.Data.Entity;
using System.Globalization;

namespace BLLayerMedCom
{
    public class DoctorsBL
    {

        

        private UnitOfWork uw;
        //read-only count for Doctors Entity 
        public int TotalDoctors {
            get
            {
                return uw.DoctorRepository.Get().Count();
            }
        }


        public int TotalPatientByDoc(Doctor doc)
        {
            return uw.DoctorRepository.GetByID(doc.DocID).Patients.Count();
        }


        public DoctorsBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }
        public bool doctorExists(UserVM doc)
        {

            var un = doc.userName;
            var filteredDoc = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));
            if (filteredDoc.Count() != 0)
                return true;
            else
                return false;
        }

        public bool verifyDoctor(UserVM doc)
        {
            var un = doc.userName;
            Doctor docInstance;
            var docList = uw.DoctorRepository.Get(filter: d => d.Username.ToLower().Equals(un));

            if (doctorExists(doc))
            {
                docInstance = docList.FirstOrDefault();
                if (doc.password == docInstance.Password)
                {
                    System.Diagnostics.Trace.WriteLine("verifydoc- Login Success");

                    //FormsAuthentication.SetAuthCookie(docInstance.Username,false);
                    return true;
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("verifydoc- Login Failed");
                    return false;
                }
            }
            else
            {
                return false;
            }



        }

        public bool insertDoc(Doctor doc)
        {
            uw.DoctorRepository.Insert(doc);
            uw.Save();
            return false;
        }


        public Doctor getByUN(string un)
        {
            var v = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un));
            return v.First<Doctor>();
        }
        public void setOnline(string un)
        {
            Doctor doc = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un)).FirstOrDefault();
            doc.isOnline = true;
            uw.DoctorRepository.Update(doc);
            uw.Save();
        }
        public void setOffline(string un)
        {
            Doctor doc = uw.DoctorRepository.Get(filter: o => o.Username.Equals(un)).FirstOrDefault();
            doc.isOnline = false;
            uw.DoctorRepository.Update(doc);
            uw.Save();
        }

        public List<Doctor> get(String searchTag,int? spec,String sortby)
        {
            Func<Doctor,Object> sortparam = null;

            if (sortby.Equals("Fees"))
                sortparam = m => m.ConsFee;
            else if (sortby.Equals("FirstName"))
                sortparam = m => m.FirstName;

            var v = uw.DoctorRepository.Get(
                filter:
                o=>o.FirstName.Contains(searchTag)&& 
                o.LastName.Contains(searchTag)&& 
                o.specID==spec,
            
                orderBy:
                o=>(IOrderedQueryable<Doctor>) o.OrderBy(sortparam)).ToList();



                return v;
        }


        public List<Doctor> getAll()
        {
            var v = uw.DoctorRepository.Get().ToList();
            return v;
        }




        public List<DocCardInfoVM> getDocCardList(List<Doctor> docList)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            List<DocCardInfoVM> DCardList = new List<DocCardInfoVM>();

            foreach (Doctor doctor in docList)
            {
                DCardList.Add(new DocCardInfoVM
                {
                    Fees = doctor.ConsFee.GetValueOrDefault(),
                    region = doctor.Region,
                    Name = "Dr. " + doctor.FirstName.ToUpper().Substring(0, 1) + doctor.FirstName.Substring(1).ToLower() + " " + doctor.LastName.ToUpper().Substring(0, 1) + doctor.LastName.ToLower().Substring(1),
                    PracticingAddress = textInfo.ToTitleCase(doctor.practicingAddress ?? "No Address Given"),
                    isOnline = doctor.isOnline,
                    totalPatients = TotalPatientByDoc(doctor),
                    spec = doctor.Specialization,
                    id=doctor.DocID

                });

            };

            return DCardList;

        }

        public DocCardInfoVM docVMfromDoc(Doctor doctor)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return new DocCardInfoVM
            {
                Fees = doctor.ConsFee.GetValueOrDefault(),
                region = doctor.Region,
                Name = "Dr. " + doctor.FirstName.ToUpper().Substring(0, 1) + doctor.FirstName.Substring(1).ToLower() + " " + doctor.LastName.ToUpper().Substring(0, 1) + doctor.LastName.ToLower().Substring(1),
                PracticingAddress = textInfo.ToTitleCase(doctor.practicingAddress ?? "No Address Given"),
                isOnline = doctor.isOnline,
                totalPatients = TotalPatientByDoc(doctor),
                spec = doctor.Specialization,
                id = doctor.DocID

            };
        }




            
            }
            
        



    }


