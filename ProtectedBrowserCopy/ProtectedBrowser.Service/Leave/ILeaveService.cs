using ProtectedBrowser.Domain;
using ProtectedBrowser.Domain.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Leave
{
    public interface ILeaveService
    {
        long LeaveInsert(LeaveModel model);
        void LeaveUpdate(LeaveModel model);
        List<LeaveModel> LeaveSelect(SearchParam param);
    }
}
