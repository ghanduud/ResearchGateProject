using System;

namespace ResearchGateProject.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        //hello
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
