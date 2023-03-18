using FluentValidation.Results;

namespace Application.Shared.Helpers
{
    public static class ValidatorHelper
    {
        public static List<string> ParseFailures(List<ValidationFailure> failures)
        {
            List<string> list = new List<string>();
            foreach (ValidationFailure failure in failures)
            {
                list.Add(failure.ErrorMessage);
            }

            return list;
        }
    }
}
