using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class FeedbackModel
    {
        public int rating { get; set; }
        public string Comment { get; set; }
        public int BookID { get; set; }
    }
}
