using WH.Application.Commons.Bases;

namespace WH.Application.Commons.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<BaseError>? Errors { get; set; }

        public ValidationException() : base()
        {
            Errors = new List<BaseError>();
        }

        public ValidationException(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }
    }
}
