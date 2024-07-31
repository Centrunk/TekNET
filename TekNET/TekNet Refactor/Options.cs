/*
*   Copyright (C) 2024 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekNet_Refactor
{
	internal class Options
	{
		//Options
		internal bool clock = true;

		internal string clockbtext = "This is the Rose Telecom Tech net paging solution. The time is";

		internal string clockatext = "Zulu. Irina is clear";

		internal string clocktrigtime = "03";

		internal bool clock24h = true;

		internal bool testpages = true;

		internal bool pageout = true;

		internal string testpagetrigH = "12";

		internal string testpagetrigM = "20";

		internal string testpagetrigAP = "PM";

		internal string testpagetext = "This is a test of the Rose Telecom Tech Net paging solution. The current time is";

		internal string imapaddress = "imap.server.com";

		internal string imapuser = "user";

		internal string imappass = "password";

		internal string imapport = "993";

		internal bool imapssl = true;

		internal bool imapenab = false;

		internal bool UEMadv = false;

		internal bool STRIG = false;

		internal Dictionary<string, string> sites = new Dictionary<string, string>();

		internal string testpagetrigtime = "12:20 PM";

		internal string testpagetrigclear = "12:45 PM";

		internal int clocktrigtimeclear = 35;
	}
}
