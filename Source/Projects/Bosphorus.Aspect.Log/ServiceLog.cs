using System;
using Bosphorus.Logging.Model;

namespace Bosphorus.Aspect.Log
{
    public class ServiceLog: AbstractLog
    {
        public virtual Guid InvocationId { get; set; }
        public virtual string Class { get; set; }
        public virtual string Method { get; set; }
        public virtual string LogData { get; set; }
    }
}
