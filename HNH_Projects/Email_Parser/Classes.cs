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
        public List<string> JobNumbers = new List<string> { };

        public List<string> Files = new List<string> { };

        public string Purpose = "";

        public string Notes = "";

        public string Sender = "";

        public string Address = "";
    }

    public class Globals
    {
        public static string AttachmentFolder { get; set; }
    }
}
