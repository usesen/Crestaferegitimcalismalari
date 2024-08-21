namespace VelorusNet8.Domain.Repositories;

public interface ICustomerRepository
{
    Customer GetById(int customerId);
    IEnumerable<Customer> GetAll();
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);
}

