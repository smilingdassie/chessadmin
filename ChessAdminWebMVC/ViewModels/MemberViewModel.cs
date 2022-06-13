using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.ViewModels
{
    public class MemberViewModel
    {
        public Member Member { get; set; }

        public int ID { get; set; }
        public string DisplayName { get; set; }

        public MemberViewModel() { }


        public MemberViewModel(Member member) 
        {
            this.Member = member;
            this.ID = member.ID;
            this.DisplayName = $"{member.Name} {member.Surname} - ({member.CurrentRank})";
        }
    }
}