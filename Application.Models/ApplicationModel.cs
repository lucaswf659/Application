using System;

namespace Application.Models
{
    public class ApplicationModel
    {
        public int ApplicationId { get; set; }

        public string Url { get; set; }

        public string PathLocal { get; set; }

        public bool DebuggingMode { get; set; }
    }
}
