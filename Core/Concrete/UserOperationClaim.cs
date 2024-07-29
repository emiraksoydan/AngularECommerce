using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class UserOperationClaim
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid OperationClaimID { get; set; }
    }
}
