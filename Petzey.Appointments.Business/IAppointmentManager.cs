using System;
using System.Collections.Generic;

namespace Petzey.Appointments.Business
{
    public interface IAppointmentManager
    {
        List<DTOAppointment> GetAppointmentsByDoctorId(long docID);
        List<DTOAppointment> GetAppointmentsByOwnerId(long ownerId);
        List<DTOAppointment> GetAppointmentsByPetId(long petId);
        List<DTOAppointment> GetAppointmentsByDate(DateTime dt);
        List<DTOAppointment> GetAppointmentsByDate(DateTime dt, long docId);
        DTOAppointment AddAppointment(DTOAppointment appointment);
        DTOPrescription UpdatePrescription(DTOPrescription p);
        List<DTOPrescription> GetAllPrescriptionByPetId(long petId);
        DTOPrescription GetRecentPrescriptionByPetId(long petId);

    }


}
