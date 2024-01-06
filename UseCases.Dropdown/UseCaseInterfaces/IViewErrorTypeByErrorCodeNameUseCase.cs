using CoreBusiness.Dropdown;

namespace UseCases.Dropdown.UseCaseInterfaces
{
    public interface IViewErrorTypeByErrorCodeNameUseCase
    {
        List<ErrorType> Execute(string errorCode);
    }
}