using Petzey.Appointments.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Appointments.Business
{
    public class AppointmentManager : IAppointmentManager
    {
        private IAppointmentRepository _repo;
        private DTOMapper _mapper = new DTOMapper();
        public AppointmentManager(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public AppointmentManager()
        {
            _repo = new AppointmentRepository();
        }
        public DTOAppointment AddAppointment(DTOAppointment dto)
        {
            return _mapper.AppointmentToDTO(_repo,_repo.AddAppointment(_mapper.DTOToAppointment(_repo, dto)));
        }

        public List<DTOPrescription> GetAllPrescriptionByPetId(long petId)
        {
            return _repo.GetAllPrescriptionByPetId(petId).Select(p => _mapper.PrescriptionToDTO(p)).ToList();
        }

        public List<DTOAppointment> GetAppointmentsByDate(DateTime dt)
        {
            return _repo.GetAppointmentsByDate(dt).Select(a => _mapper.AppointmentToDTO(_repo, a)).ToList();
        }

        public List<DTOAppointment> GetAppointmentsByDate(DateTime dt, long docId)
        {
            return _repo.GetAppointmentsByDate(dt, docId).Select(a => _mapper.AppointmentToDTO(_repo, a)).ToList();
        }

        public List<DTOAppointment> GetAppointmentsByDoctorId(long docId)
        {
            return _repo.GetAppointmentsByDoctorId(docId).Select(a => _mapper.AppointmentToDTO(_repo, a)).ToList();

        }

        public List<DTOAppointment> GetAppointmentsByOwnerId(long ownerId)
        {
            return _repo.GetAppointmentsByOwnerId(ownerId).Select(a => _mapper.AppointmentToDTO(_repo, a)).ToList();

        }

        public List<DTOAppointment> GetAppointmentsByPetId(long petId)
        {
            return _repo.GetAppointmentsByPetId(petId).Select(a => _mapper.AppointmentToDTO(_repo, a)).ToList();
        }

        public DTOPrescription GetRecentPrescriptionByPetId(long petId)
        {
            return _mapper.PrescriptionToDTO(_repo.GetRecentPrescriptionByPetId(petId));
        }

        public DTOPrescription UpdatePrescription(DTOPrescription p)
        {
            return _mapper.PrescriptionToDTO(_repo.UpdatePrescription(_mapper.DTOToPrescription(_repo,p)));
        }
    }
}
