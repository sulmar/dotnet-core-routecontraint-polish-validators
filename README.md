# Reguły do walidacji tras na podstawie sumy kontrolnej NIP oraz Pesel


- Rejestracja

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddValidators();
}
~~~

Powyższa metoda rejestruje reguły _pesel_ oraz _nip_

Następnie możemy ich użyć w kontrolerze jako reguły tras:

~~~ csharp

[ApiController]
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

