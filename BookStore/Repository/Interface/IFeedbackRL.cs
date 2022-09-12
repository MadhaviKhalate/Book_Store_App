using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IFeedbackRL
    {
        public bool AddFeedback(FeedbackModel feedbackModel, int UserID);
        public IEnumerable<GetFeedbackModel> GetFeedback(int UserID);

    }
}
