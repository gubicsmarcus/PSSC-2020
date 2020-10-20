using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateVoteWorkflow
{
    /// <summary>
    /// SUM type:
    /// </summary>
    [AsChoice]
    public static partial class CreateNewVoteResult
    {
        /// <summary>
        /// Marker interface
        /// </summary>
        public interface ICreateVoteResult
        {

        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class VoteGiven : ICreateVoteResult
        {
            public Guid VoteId { get; private set; }
            public int Nr_Vote{ get; private set; }

            public VoteGiven(Guid voteId, int nr_vote)
            {
                VoteId = voteId;
                Nr_Vote = nr_vote;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class VoteNotGiven : ICreateVoteResult
        {
            public string Reason { get; set; }

            public VoteNotGiven(string reason)
            {
                Reason = reason;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class VoteValidationFailed : ICreateVoteResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public VoteValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
