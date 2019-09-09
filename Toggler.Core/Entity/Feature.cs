using System;

namespace Toggler.Core.Entity
{
    public class Feature
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
