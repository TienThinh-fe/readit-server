using System;
using System.Collections.Generic;

namespace server.DataAccess
{
    public partial class Result
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
