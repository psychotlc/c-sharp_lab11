using System.Net.Http.Json;

public class Customer
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
}

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        var response = await _httpClient.GetAsync("api/customers");
        response.EnsureSuccessStatusCode();
        List<Customer> customers = await new Task<List<Customer>>(response.Content.ReadFromJsonAsync());
        return customers;
    }

    public async Task<Customer> GetCustomerAsync(string id)
    {
        var response = await _httpClient.GetAsync($"api/customers/{id}");
        response.EnsureSuccessStatusCode();
        var customer = await response.Content.ReadFromJsonAsync<Customer>();
        return customer;
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        var response = await _httpClient.PostAsJsonAsync("api/customers", customer);
        response.EnsureSuccessStatusCode();
        var createdCustomer = await response.Content.ReadFromJsonAsync<Customer>();
        return createdCustomer;
    }

    public async Task UpdateCustomerAsync(string id, Customer customer)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", customer);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCustomerAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"api/customers/{id}");
        response.EnsureSuccessStatusCode();
    }
}