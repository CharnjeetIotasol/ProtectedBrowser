using ProtectedBrowser.DBRepository.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Leave;

namespace ProtectedBrowser.Service.Leave
{
    public class LeaveService:ILeaveService
    {
        private LeaveDBService _leaveDBService;
        public LeaveService()
        {
            _leaveDBService = new LeaveDBService();
        }

        public long LeaveInsert(LeaveModel model)
        {
            return _leaveDBService.LeaveInsert(model);
        }

        public List<LeaveModel> LeaveSelect(SearchParam param)
        {
            return _leaveDBService.LeaveSelect(param);
        }

        public void LeaveUpdate(LeaveModel model)
        {
            _leaveDBService.LeaveUpdate(model);
        }
    }
}
