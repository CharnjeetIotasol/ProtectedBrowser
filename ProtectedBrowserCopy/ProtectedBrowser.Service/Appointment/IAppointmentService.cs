using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Appointment
{
    public interface IAppointmentService
    {
        long AppointmentInsert(AppointmentModel model);
        void AppointmentUpdate(AppointmentModel model);
        List<AppointmentModel> AppointmentSelect(SearchParam param);
        List<AppointmentTimeSlot> GetUserAppointmentSlot(DateTimeOffset? appointmentDate, long? toUserId);
    }
}
