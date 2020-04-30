# Polish RouteContraint Validators for .NET Core

## Get Started

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddPeselValidator();
}
~~~

or 
~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddNipValidator();
}
~~~

or all
            
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

