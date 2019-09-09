using System.Collections.Generic;
using System.Linq;
using Toggler.Core.Entity;

namespace Toggler.Core.Repository.Builder
{
    public class ApplicationFeatureBuilder
    {
        public IEnumerable<ApplicationFeature> Build(IEnumerable<ApplicationFeatureDto> appFeatureDto)
        {
            return appFeatureDto.Select(a =>
                new ApplicationFeature()
                {
                    Application = new Application()
                    {
                        Id = a.IDApplication,
                        Name = a.NameApplication,
                        Url = a.UrlApplication
                    },
                    Feature = new Feature()
                    {
                        Id = a.IDFeature,
                        Name = a.NameFeature,
                        Description = a.DescriptionFeature
                    },
                    Active = a.Active
                }
            );
        }
    }
}
