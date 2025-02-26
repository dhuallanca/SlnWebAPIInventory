﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity
{
    public record UserDto(int Id, string Name, string Email, string FirstName, string LastName, bool IsActive);
}
