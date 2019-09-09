using System.Collections.Generic;
using System.Linq;
using Toggler.Core.Entity;

namespace Toggler.Core.Repository.Builder
{
    public class ApplicationFeatureBuilder
    {
        public Application Build(IEnumerable<ApplicationFeatureDto> appFeatureDto)
        {
            var app = appFeatureDto.First();

            var application = new Application()
            {
                Id = app.IDApplication,
                Name = app.NameApplication,
                Url = app.UrlApplication,
                Features = appFeatureDto.Select(a => new Feature
                {
                    Id = a.IDFeature,
                    Name = a.NameFeature,
                    Description = a.DescriptionFeature,
                    Active = a.Active
                })
            };

            return application;
        }
    }
}

