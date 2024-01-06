using CoreBusiness.Dropdown;

namespace UseCases.Dropdown.UseCaseInterfaces
{
    public interface IViewJournalIdByPublisherNameUseCase
    {
        List<Journal> Execute(string publisherNme);
    }
}