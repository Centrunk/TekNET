/*
*   Copyright (C) 2022 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using Microsoft.VisualBasic;
using System.IO.Ports;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Text.RegularExpressions;

namespace StartData
{
	internal class Program
	{
		public class CONF
		{
			public Dictionary<int, string> Techs { get; set; }
			public string COMP { get; set; }
			public string COMT { get; set; }
			public string ADP { get; set; }
		}

		private static void Main(string[] args)
		{
		restart:
			Console.WriteLine("T or G");
			int RTC = 5;
			if (Console.ReadKey().KeyChar == 'T')
			{
				/*
						 * Wait for VCALL737
						 * Send RCALL858
						 * Wait for NT## (must be sent as two digit)
						 * Store NT (Number of Techs)
						 * Send NTACK
						 * Wait for TKtech1,tech2,tech3 (Tech list must be Comma seped)
						 * Send TKACK
						 * Wait for CAP## (must be sent as two digit)
						 * Store CAP (Callout Priority)
						 * Send CAPACK
						 * Wait for TOMR
						 * Send RFT
						 * Wait for TOMxxxxxxxxxxxxxxx(MSG is variable len)
						 * Store TOM (Tone Out Message)
						 * Send TOMACK
						 * Wait for CHKSUM
						 * Store CHKSUM
						 * Compare CHKSUM RX to Computed Checksum of TOM
						 * Send CHKSUMAK if good
						 * Send CHKSUMNAK if bad
						 * If bad, jump back to wait for TOMR
						 * **Start Tone**
						 * Once Tone out is complete send RFNM and wait for VCALL737
						 */
				using (SerialPort MyCOMPort = new SerialPort())
				{
					//COM port settings to 8N1 mode
					MyCOMPort.PortName = "COM6";          // Name of the COM port
					MyCOMPort.BaudRate = 115200;               // Baudrate = 9600bps
					MyCOMPort.Parity = Parity.None;        // Parity bits = none
					MyCOMPort.DataBits = 8;                  // No of Data bits = 8
					MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1
					try
					{
						MyCOMPort.Open();   // Open the port
					}
					catch (Exception Ex) { }
					try
					{
						string CMD;

					VC:
						MyCOMPort.WriteLine("VCALL737");
						Console.WriteLine("VCALL737");
						CMD = MyCOMPort.ReadLine();
#if DEBUG
						Console.WriteLine(CMD);
#endif
						if (CMD == "RCALL858")
						{
						NT:
							MyCOMPort.WriteLine("NT03");
							Console.WriteLine("NT03");
							CMD = MyCOMPort.ReadLine();
#if DEBUG
							Console.WriteLine(CMD);
#endif

							if (CMD == "NTACK")
							{
							TK:
								MyCOMPort.WriteLine("TKTech1,Tech2,Admin");
								Console.WriteLine("TKTech1,Tech2,Admin");
								CMD = MyCOMPort.ReadLine();
#if DEBUG
								Console.WriteLine(CMD);
#endif

								if (CMD == "TKAK")
								{
								Cap:
									MyCOMPort.WriteLine("CAP01");
									Console.WriteLine("CAP01");
									CMD = MyCOMPort.ReadLine();
#if DEBUG
									Console.WriteLine(CMD);
#endif
									int CHKSUMRTC = 0;
									if (CMD == "CAPACK")
									{
									tomR:
										MyCOMPort.WriteLine("TOMR");
										Console.WriteLine("TOMR");
										CMD = MyCOMPort.ReadLine();
#if DEBUG
										Console.WriteLine(CMD);
#endif
										if (CMD == "RFT")
										{
										Msg:
											string msg = "TOMThis is a test of the tone out system";
											string msgtbh = "This is a test of the tone out system";
											MyCOMPort.WriteLine(msg);
											Console.WriteLine(msg);
											CMD = MyCOMPort.ReadLine();
#if DEBUG
											Console.WriteLine(CMD);
#endif
											if (CMD == "TOMACK")
											{
											CHKSUM:
												if (CHKSUMRTC == 5)
												{
													Console.WriteLine("CheckSum Fail - Retry Counter Timeout");
													goto restart;
												}
												if (CHKSUMRTC != 0)
												{
													Console.WriteLine("Retry " + CHKSUMRTC);
												}
												using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
												{
													string hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(msgtbh))).Replace("-", String.Empty);
													MyCOMPort.WriteLine("CHKSUM" + hash);
													Console.WriteLine("CHKSUM" + hash);
												}

												CMD = MyCOMPort.ReadLine();
#if DEBUG
												Console.WriteLine(CMD);
#endif
												if (CMD == "CHKSUMAK")
												{
												//MyCOMPort.WriteLine("TOMThis is a test of the tone out system");
												RFNM:
													CMD = MyCOMPort.ReadLine();
#if DEBUG
													Console.WriteLine(CMD);
#endif
													if (CMD == "RFNM")
													{
														goto restart;
													}
													else
													{
														Thread.Sleep(50);
														goto RFNM;
													}
												}
												else if (CMD == "CHKSUMNAK")
												{
													CHKSUMRTC++;
													goto tomR;
												}
												else
												{
													CHKSUMRTC++;
													goto CHKSUM;
												}
											}
											else
											{
												goto Msg;
											}
										}
										else
										{
											goto tomR;
										}
									}
									else
									{
										goto Cap;
									}
								}
								else
								{
									goto TK;
								}
							}
							else
							{
								goto NT;
							}
						}
						else
						{
							Console.WriteLine("SNAK Error");
							goto restart;
						}
					}
					catch (Exception Ex) { }
					MyCOMPort.Close();
				}
			}
			else
			{
				Dictionary<int, string> TEK = new Dictionary<int, string>();
				string COMP = "COM1";
				string COMT = "COM2";
				string ADP = "73738767793";
				TEK.Add(1, "Admin");
				TEK.Add(2, "DepNet");
				TEK.Add(3, "Tech1");
				TEK.Add(4, "Tech2");
				TEK.Add(5, "Tech3");

				var CONF = new CONF
				{
					Techs = TEK,
					COMP = COMP,
					COMT = COMT,
					ADP = ADP
				};

				string jsonString = JsonSerializer.Serialize(CONF);
				File.WriteAllText(@"X:\TekNET\TekNET\TekNET\bin\Debug\Conf.TNCONF", jsonString);
			}
			goto restart;
		}
	}
}