using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Precision_Medicine_Matching_System.Models
{
	public class Administrator : IIdentity
	{
        public Administrator( string name, bool isAuthenticated, string authenticationType)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
            AuthenticationType = authenticationType;
        }
        public string Name { get; }
        public bool IsAuthenticated { get; }
        public string AuthenticationType { get; }
    }
}
