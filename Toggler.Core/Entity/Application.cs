using System;
using System.Collections.Generic;

namespace Toggler.Core.Entity
{
    public class Application
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IEnumerable<Feature> Features { get; set; }
    }
}
