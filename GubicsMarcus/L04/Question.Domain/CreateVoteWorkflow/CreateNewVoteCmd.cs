using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateVoteWorkflow
{
    public struct CreateNewVoteCmd
    {
        [Required]
        public bool GoodOrBad { get; private set; }
        [Required]
        public int Nr_vote { get; private set; }
        

        public CreateNewVoteCmd(bool goodorbad,int nr)
        {
            GoodOrBad = goodorbad;
            Nr_vote = nr;
        }
    }
}
