using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Services
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRL ifeedbackRL;
        public FeedbackBL(IFeedbackRL ifeedbackRL)
        {
            this.ifeedbackRL = ifeedbackRL;
        }

        public bool AddFeedback(FeedbackModel feedbackModel, int UserID)
        {
            try
            {
                return ifeedbackRL.AddFeedback(feedbackModel, UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GetFeedbackModel> GetFeedback(int UserID)
        {
            try
            {
                return ifeedbackRL.GetFeedback(UserID);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
