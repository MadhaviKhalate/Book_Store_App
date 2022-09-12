using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IFeedbackBL
    {
        public bool AddFeedback(FeedbackModel feedbackModel, int UserID);
        public IEnumerable<GetFeedbackModel> GetFeedback(int UserID);

    }
}
