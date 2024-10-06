namespace Application.Services
{// aca hacemos el contrato de los metodos que va a utilizar la clase.
    public interface ICustomerService
    {
        void FilterPro(List<Professional>);
        void RatePro(int ProfessionalId, float Calification);
        void SelectPro(Professional professional);
        void SendRequest(int ProfessionalID, DateTime Date);
    }
}

