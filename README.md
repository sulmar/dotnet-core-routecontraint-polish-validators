# Polish Route Contraints Validators for MVC or RazorPages
Route constraints for Polish NIP, PESEL, REGON

## Get Started

- Registration of the PESEL route constraint

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddPeselValidator();
}
~~~

- Registration of the NIP route constraint

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddNipValidator();
}
~~~

- Registration of the NIP and PESEL route constraints
            
~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddValidators();
}
~~~


## Usage

~~~ csharp

[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet("{number:pesel}")]
    public IActionResult GetByPesel(string number)
    {
        return Ok($"Pesel {number}");
    }

    [HttpGet("{number:nip}")]
    public IActionResult GetByNip(string number)
    {
        return Ok($"Nip {number}");
    }
~~~

