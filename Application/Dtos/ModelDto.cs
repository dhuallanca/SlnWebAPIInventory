using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// To control what data is exposed to the client and to simplify the structure of complex objects
/// Normaly using records
namespace Application.Dtos
{
    public record ModelDto(int MyProperty);
}
