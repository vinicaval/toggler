using AutoFixture;
using System;
using System.Linq;
using Toggler.Core.Repository;
using Toggler.Core.Repository.Builder;
using Xunit;

namespace Toggler.UnitTest
{
    public class ApplicationFeatureBuilderTest
    {
        
        [Fact]
        public void Parse_ApplicationFeatureDto_Into_ApplicationFeatureBuilder()
        {
            var fixture = new Fixture();
            var builder = new ApplicationFeatureBuilder();

            var applicationFeature = fixture.CreateMany<ApplicationFeatureDto>();

            var applicationFeatureResult = builder.Build(applicationFeature);

            Assert.Equal(applicationFeatureResult.Name, applicationFeature.First().NameApplication);
            
        }
    }
}
