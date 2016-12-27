using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Serializing.Binary
{
	public class CheckMemberAttribute:MemberAttribute
	{
		public int BeginPostion { get; private set; }

		public int EndLength { get; private set; }
	}
}
