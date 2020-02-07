
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotesFront.Models
{
    public class ClaimViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class UserClaims
    {
        public IEnumerable<ClaimViewModel> Claims { get; set; }
        public string UserName { get; set; }
    }
}
