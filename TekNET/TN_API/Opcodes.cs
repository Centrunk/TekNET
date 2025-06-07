/*
*   Copyright (C) 2025 by N5UWU & N7MOW
*   This program is distributed WITHOUT WARRANTY.
*/

namespace TN_API
{
	public static class Opcodes
	{
		public static void ClientReq()
		{
			string OpCode = "0x01";
			string NewAlertingFac = "0x00";
			string NewClient = "0x01";
			string NewClientOTP = "0x02";
			string FacCfgReq = "0xA0";
			string ClientCfgReq = "0xC0";
		}

		public static void ServerResp()
		{
			string OpCode = "0x02";
			string FacLogonAcc = "0x46";
			string OTPnotFound = "0x54";
			string OTPReq = "0x55";
			string PIDProg = "0x56";
			string CfgProg = "0x57";
			string FacEndPProg = "0xC9";
		}

		public static void ClientResp()
		{
			string OpCode = "0x03";
			string ClientPollResp = "0x00";
			string FacPollResp = "0x01";
			string FacPollRespReqEPL = "0x02";
		}
		public static void SvrToClientPoll()
		{
			string OpCode = "0x04";
			string ClientPoll = "0x01";
			string FacPoll = "0x02";
			string FacPollWEPL = "0x03";
		}
		public static void SvrHlthChk()
		{
			string OpCode = "0x05";

		}
		public static void ClientHlthChk()
		{
			string OpCode = "0x06";

		}
		public static void IssueAlert()
		{
			string OpCode = "0x11";
			string IssueSysWide = "0x00";
			string IssueReg = "0x01";
			string IssueGrp = "0x02";
			string IssueIndvTn = "0x03";
			string IssueIndvDat = "0x04";
			string IssueIndvAdvDat = "0x05";
		}
		public static void Alert()
		{
			string OpCode = "0x91";
			string IssueSysWide = "0x00";
			string IssueReg = "0x01";
			string IssueGroup = "0x02";
			string IssueIndvTone = "0x03";
			string IssueIndvData = "0x04";
			string IssueIndvAdvData = "0x05";
		}
		public static void RetryAlert()
		{
			string OpCode = "0x92";

		}
		public static void ClientForceDisco()
		{
			string OpCode = "0x98";
			string ForceDisco = "0x99";
		}
		public static void ClientReject()
		{
			string OpCode = "0x99";
			string InvOTP = "0x91";
		}
	}
}
