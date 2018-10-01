using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.Common.Options
{
    public sealed class SendGridSettings
    {
        public string ApiKey { get; set; }

        public string From { get; set; }
    }
}
