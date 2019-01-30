using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    public interface ISubscriber
    {
        void Update(IPublisher publisher, string message);
    }
}
