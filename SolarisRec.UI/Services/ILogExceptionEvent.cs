using System;
using System.Threading.Tasks;

namespace SolarisRec.UI.Services
{
    public interface ILogExceptionEvent
    {
        Task Log(Exception ex);
    }
}