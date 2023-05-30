using System;

namespace DILife.Services
{
    public class ChildService : ITransientService, IScopedService, ISingletonService
    {
        private Guid _id;
        public ChildService()
        {
            _id = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _id;
        }
    }
}
