using ProtectedBrowser.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Appointment
{
    public class AppointmentSlotManage
    {
        public static List<AppointmentTimeSlot> SlotManage(List<AppointmentModel> bookedAppointment, TimeSpan? StartTime, TimeSpan? StartLunchTime, TimeSpan? EndLunchTime, TimeSpan? EndTime, int TimeSlot)
        {
            List<AppointmentTimeSlot> timeSloatList = new List<AppointmentTimeSlot>();
            TimeSpan? startLunchTime = StartLunchTime;
            TimeSpan? startTime = StartTime;
            TimeSpan minutes = TimeSpan.FromMinutes(TimeSlot);
            do
            {
                if (startTime < startLunchTime)
                {

                    timeSloatList.Add(new AppointmentTimeSlot()
                    {
                        StartTime = startTime,
                        EndTime = startTime = startTime.Value.Add(minutes),
                    });
                }
            } while (startTime < startLunchTime);
            TimeSpan? endLunchTime = EndLunchTime;
            TimeSpan? endTime = EndTime;
            do
            {
                if (endLunchTime < endTime)
                {
                    timeSloatList.Add(new AppointmentTimeSlot()
                    {
                        StartTime = endLunchTime,
                        EndTime = endLunchTime = endLunchTime.Value.Add(minutes),
                    });
                }
            } while (endLunchTime < endTime);

            foreach (var item in bookedAppointment)
            {
                TimeSpan? bookedStartSpan = item.StartTime;
                TimeSpan? bookedEndSpan = item.EndTime;
                foreach (var slot in timeSloatList)
                {
                    TimeSpan? sloatStartSpan = slot.StartTime;
                    TimeSpan? sloatEndSpan = slot.EndTime;
                    if (bookedStartSpan == sloatStartSpan || (sloatStartSpan > bookedStartSpan && sloatStartSpan < bookedEndSpan))
                    {
                        slot.IsBooked = true;
                    }
                }
            }
            return timeSloatList;
        }

        public static bool CheckingLeaveTimeSlot(TimeSpan? startTime, TimeSpan? endTime, TimeSpan? leaveStartTime, TimeSpan? LeaveEndTime)
        {
            if (((startTime >= leaveStartTime) && (startTime < LeaveEndTime)) || ((endTime > leaveStartTime) && (endTime < LeaveEndTime)))
            {
                return true;
            }
            return false;
        }
    }
}
