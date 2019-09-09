using System.ComponentModel.DataAnnotations;

namespace Toggler.Service
{
    public class EnvironmentVariable : IValidatable
    {
        [Required]
        public string SQL_CONNECTION { get; set; }

        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        }
    }
}
