using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GetFeedbackModel
    {
        public string FeedbackID { get; set; }
        public string rating { get; set; }
        public string Comment { get; set; }
        public string BookID { get; set; }
    }
}
