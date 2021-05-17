using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Precision_Medicine_Matching_System.Controllers
{
	public class AdministratorAttribute : AuthorizeAttribute
	{
		public AdministratorAttribute()
		{
			Policy = "AdministratorAuthentication";
		}
	}
}
