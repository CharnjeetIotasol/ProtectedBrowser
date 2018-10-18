using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Appointment;
using ProtectedBrowser.DBRepository.Appointment;
using ProtectedBrowser.DBRepository.DailyWorkSetting;
using ProtectedBrowser.DBRepository.PublicHoliday;
using ProtectedBrowser.DBRepository.Leave;

namespace ProtectedBrowser.Service.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private AppointmentDBService _appointmentDBService;
        private DailyWorkSettingDBService _dailyWorkSettingDBService;
        private PublicHolidayDBService _publicHolidayDBService;
        private LeaveDBService _leaveDBService;
        public AppointmentService()
        {
            _appointmentDBService = new AppointmentDBService();
            _dailyWorkSettingDBService = new DailyWorkSettingDBService();
            _publicHolidayDBService = new PublicHolidayDBService();
            _leaveDBService = new LeaveDBService();
        }
        public long AppointmentInsert(AppointmentModel model)
        {
            return _appointmentDBService.AppointmentInsert(model);
        }

        public List<AppointmentModel> AppointmentSelect(SearchParam param)
        {
            return _appointmentDBService.AppointmentSelect(param);
        }

        public void AppointmentUpdate(AppointmentModel model)
        {
            _appointmentDBService.AppointmentUpdate(model);
        }
        public List<AppointmentTimeSlot> GetUserAppointmentSlot(DateTimeOffset? appointmentDate, long? toUserId)
        {
            List<AppointmentTimeSlot> appointmentTimeSlot = new List<AppointmentTimeSlot>();
            SearchParam param = new SearchParam();
            param.AppointmentDate = appointmentDate;
            var appointments = AppointmentSelect(param);
            var dailyWorkSetting = _dailyWorkSettingDBService.DailyWorkSettingSelect();
            if (dailyWorkSetting == null)
                return new List<AppointmentTimeSlot>();
            param.UserId = toUserId;

            var userLeave = _leaveDBService.LeaveSelect(param);
            var userAppointments = appointments.Where(x => x.ToUserId == toUserId).ToList();
            if (userLeave.Count == 0)
            {
                var timeSlot = AppointmentSlotManage.SlotManage(userAppointments, dailyWorkSetting.StartTime, dailyWorkSetting.StartLunchTime, dailyWorkSetting.EndLunchTime, dailyWorkSetting.EndTime, 30);
                appointmentTimeSlot.AddRange(timeSlot);
            }
            else
            {
                var fullDayLeave = userLeave.Where(x => x.StartDate.Value.Date < appointmentDate.Value.Date && x.EndDate.Value.Date > appointmentDate.Value.Date).ToList();
                if (fullDayLeave.Count != 0)
                {
                    return new List<AppointmentTimeSlot>();
                }
                var timeSlot = AppointmentSlotManage.SlotManage(userAppointments, dailyWorkSetting.StartTime, dailyWorkSetting.StartLunchTime, dailyWorkSetting.EndLunchTime, dailyWorkSetting.EndTime, 30);
                appointmentTimeSlot.AddRange(timeSlot);
                foreach (var leave in userLeave)
                {
                    if (leave.StartTime == null)
                    {
                        break;
                    }
                    else
                    {
                        if (leave.StartDate.Value.Date == appointmentDate.Value.Date && (leave.StartDate.Value.Date != leave.EndDate.Value.Date))
                        {
                            leave.EndTime = dailyWorkSetting.EndTime;
                        }
                        if (leave.EndDate.Value.Date == appointmentDate.Value.Date && (leave.StartDate.Value.Date != leave.EndDate.Value.Date))
                        {
                            leave.StartTime = dailyWorkSetting.StartTime;
                        }
                        for (int j = 0; j < timeSlot.Count; j++)
                        {
                            if (AppointmentSlotManage.CheckingLeaveTimeSlot(timeSlot[j].StartTime, timeSlot[j].EndTime, leave.StartTime, leave.EndTime))
                            {
                                timeSlot.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
                if (timeSlot.Count != 0)
                    appointmentTimeSlot.AddRange(timeSlot);
            }
            return appointmentTimeSlot;
        }
    }
}
