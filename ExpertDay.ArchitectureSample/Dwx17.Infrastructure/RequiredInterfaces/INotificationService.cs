using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwx17.Infrastructure.RequiredInterfaces
{
    public interface INotificationService
    {
        void Notify(string text);
    }
}
