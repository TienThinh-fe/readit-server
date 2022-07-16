using System;
using System.Collections.Generic;

namespace server.DataAccess
{
    public partial class User
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
