using Petzey.Appointments.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Petzey.Appointments.API.Controllers
{
    public class AppointmentController : ApiController
    {
        IAppointmentManager _appointmentsManager;

        public AppointmentController()
        {
            _appointmentsManager = new AppointmentManager();
        }

        public AppointmentController(IAppointmentManager mgr)
        {
            _appointmentsManager = mgr;
        }

        //get domain/api/appointment/doctor/id/date/dd-mm-yyyy
        [Route("api/appointment/doctor/{did}/date/{date}")]
        public IHttpActionResult GetAppointmentByDate(long did, DateTime date)
        {
            var res = _appointmentsManager.GetAppointmentsByDate(date, did);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //get domain/api/appointment/date/dd-mm-yyyy
        [Route("api/appointment/date/{date}")]
        public IHttpActionResult GetAppointmentByDate(DateTime date)
        {
            var res = _appointmentsManager.GetAppointmentsByDate(date);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //get domain/api/appointment/doctor/id
        [Route("api/appointment/doctor/{id}")]
        public IHttpActionResult GetAppointmentByDoctor(long id)
        {
            var res = _appointmentsManager.GetAppointmentsByDoctorId(id);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //get domain/api/appointment/owner/id
        [Route("api/appointment/owner/{id}")]
        public IHttpActionResult GetAppointmentByOwner(long id)
        {
            var res = _appointmentsManager.GetAppointmentsByOwnerId(id);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //get domain/api/appointment/pet/id
        [Route("api/appointment/pet/{id}")]
        public IHttpActionResult GetAppointmentByPetId(long id)
        {
            var res = _appointmentsManager.GetAppointmentsByPetId(id);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //post domain/api/appointment
        public IHttpActionResult PostAppointment([FromBody] DTOAppointment dto)
        {
            try
            {
                return Ok(_appointmentsManager.AddAppointment(dto));

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
