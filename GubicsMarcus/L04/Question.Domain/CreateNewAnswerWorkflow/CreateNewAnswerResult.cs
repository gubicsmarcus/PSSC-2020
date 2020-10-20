using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateNewAnswerWorkflow
{
    /// <summary>
    /// SUM type:
    /// </summary>
    [AsChoice]
    public static partial class CreateNewAnswerResult
    {
        /// <summary>
        /// Marker interface
        /// </summary>
        public interface ICreateNewAnswerResult
        {

        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerPosted : ICreateNewAnswerResult
        {
            public Guid AnswerId { get; private set; }
            public string Description { get; private set; }

            public AnswerPosted(Guid answerId, string description)
            {
                AnswerId = answerId;
                Description = description;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerNotPosted : ICreateNewAnswerResult
        {
            public string Reason { get; set; }

            public AnswerNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerValidationFailed : ICreateNewAnswerResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public AnswerValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
