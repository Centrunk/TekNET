/*
*   Copyright (C) 2025 by N5UWU & N7MOW
*   This program is distributed WITHOUT WARRANTY.
*/

namespace TN_API
{
	public class PacketIN
	{
		public string Opcode { get; set; }
		public string Cmd { get; set; }
		public string Datalen { get; set; }
		public string Data { get; set; }
	}
}
