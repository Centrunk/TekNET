using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN_API;

namespace TeknetQC2
{
	internal class ServerComm
	{
		internal SimpleTCP.SimpleTcpClient STPC = new SimpleTCP.SimpleTcpClient();
		internal void Connect() 
		{
			Opcodes.ClientReq();
			
			
		
		}
	}
}
