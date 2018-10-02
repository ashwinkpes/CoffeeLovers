using System.Collections.Generic;

namespace CoffeeLovers.Common.Options
{
    public class BasicEmailSettings
    {
        public string Subject { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string CC { get; set; }

        public List<string> BCC { get; set; }
    }
}