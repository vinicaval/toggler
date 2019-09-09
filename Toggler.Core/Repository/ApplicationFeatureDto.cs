using System;
using System.Collections.Generic;
using System.Text;

namespace Toggler.Core.Repository
{
   public class ApplicationFeatureDto
    {
        public Guid IDApplication { get; set; }
        public string NameApplication { get; set; }
        public string UrlApplication { get; set; }
        public Guid IDFeature { get; set; }
        public string NameFeature { get; set; }
        public string DescriptionFeature { get; set; }
        public bool Active { get; set; }
    }
}
