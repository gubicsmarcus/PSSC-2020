using System;
using System.ComponentModel.Design;
using LanguageExt;
using Tema6.Outputs;

namespace Tema6
{
    class Program
    {
        static void Main(string[] args)
        {
            var wf = from createReplyResult in Domain.ValidateReply(1, 1, "test")
                     let validReply = (ValidateReplyResult.ReplyValid)createReplyResult
                     from checkLanguageResult in Domain.CheckLanguage(validReply.Reply.Answer)
                     from ownerAck in Domain.SendAckToQuestionOwner(1, 1, "test")
                     from authorAck in Domain.SendAckToReplyAuthor(2, 1, "test")
                     select (validReply, checkLanguageResult, ownerAck, authorAck);

			var serviceProvider = new ServiceCollection()
                .AddOperations(typeof(ValidateReplyAdapter).Assembly)
                .AddTransient<IInterpreterAsync>(sp => new LiveInterpreterAsync(sp))
                .BuildServiceProvider();

            var interpreter = serviceProvider.GetService<IInterpreterAsync>();

            var writeContext = new QuestionWriteContext(new List<int>() { 1, 2, 3 }, new List<int>() { 100, 101, 102 });
            var result = await interpreter.Interpret(wf, writeContext);

            Console.WriteLine("Hello World!");
     
        }

    }

}
