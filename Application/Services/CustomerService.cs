using Domain.Entities;
using Application.Interfaces;

// Acá faltaría poner la logica de los metodos.
namespace Application.Services
{// aca hacemos la inyeccion de dependencias e inicializamos el constructor
    public class CustomerService : ICustomerService
        private readonly ICustomerRepository
        public CustomerService(ICustomerService, customerRepository)
    {
        _customerRpository = customerRepository;
    }

    // aca comenzariamos a meter la logica de los metodos.
    public void FilterPro(List<Professional>)
    {

    }

    void RatePro(int ProfessionalId, float Calification)
    {

    }
    void SelectPro(Professional professional)
    {

    }
    void SendRequest(int ProfessionalID, DateTime Date)
    {

    }



}
