using MsgReader.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Parser
{
    public class SubmissionDetails
    {
        public List<string> JobNumber { get; set; }

        public string Purpose { get; set; }

        public string Notes { get; set; }

        public string Sender { get; set; }

        public string Address { get; set; }
    }
}
