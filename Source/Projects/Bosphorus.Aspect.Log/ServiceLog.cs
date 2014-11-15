using System;

namespace Bosphorus.Aspect.Log
{
    public class ServiceLog: Logging.Model.Log
    {
        public virtual Guid InvocationId { get; set; }
        public virtual string Class { get; set; }
        public virtual string Method { get; set; }
        public virtual string LogData { get; set; }
    }
}
