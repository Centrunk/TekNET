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
					MyCOMPort.PortName = "COM11";          // Name of the COM port
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
						string? message = "";
						int pri;
						string? priPAR = "";
						Console.WriteLine("");
						Console.WriteLine("Message: ");
						message = Console.ReadLine();
					RTS:
						Console.WriteLine("Pri (0-7): ");
						priPAR = Console.ReadLine();
						if (priPAR != null)
						{
							pri = int.Parse(priPAR);
						}
						else
						{
							Console.WriteLine("Invalid Priority");
							goto RTS;
						}
						if (pri < 0 || pri > 7)
						{
							Console.WriteLine("Invalid Priority");
							goto RTS;
						}

						RTC = 5;
						MyCOMPort.WriteLine("VCALL737");
						Console.WriteLine("VCALL737");
						CMD = MyCOMPort.ReadLine();
#if DEBUG
						Console.WriteLine(CMD);
#endif
						if (CMD == "RCALL858")
						{
							RTC = 5;
						NT:
							MyCOMPort.WriteLine("NT03");
							Console.WriteLine("NT03");
							CMD = MyCOMPort.ReadLine();
#if DEBUG
							Console.WriteLine(CMD);
#endif

							if (CMD == "NTACK")
							{
								RTC = 5;
							TK:
								MyCOMPort.WriteLine("TKTech1,Tech2,Admin");
								Console.WriteLine("TKTech1,Tech2,Admin");
								CMD = MyCOMPort.ReadLine();
#if DEBUG
								Console.WriteLine(CMD);
#endif

								if (CMD == "TKAK")
								{
									RTC = 5;
								Cap:
									MyCOMPort.WriteLine("CAP0" + pri);
									Console.WriteLine("CAP0" + pri);
									CMD = MyCOMPort.ReadLine();
#if DEBUG
									Console.WriteLine(CMD);
#endif
									int CHKSUMRTC = 0;
									if (CMD == "CAPACK")
									{
										RTC = 5;
									tomR:
										MyCOMPort.WriteLine("TOMR");
										Console.WriteLine("TOMR");
										CMD = MyCOMPort.ReadLine();
#if DEBUG
										Console.WriteLine(CMD);
#endif
										if (CMD == "RFT")
										{
											RTC = 5;
										Msg:
											string msgt = "TOM" + message;
											MyCOMPort.WriteLine(msgt);
											Console.WriteLine(msgt);
											CMD = MyCOMPort.ReadLine();
#if DEBUG
											Console.WriteLine(CMD);
#endif
											if (CMD == "TOMACK")
											{
												RTC = 5;
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
													string hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(message))).Replace("-", String.Empty);
													MyCOMPort.WriteLine("CHKSUM" + hash);
													Console.WriteLine("CHKSUM" + hash);
												}

												CMD = MyCOMPort.ReadLine();
#if DEBUG
												Console.WriteLine(CMD);
#endif
												if (CMD == "CHKSUMAK")
												{
													RTC = 5;
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
												RTC--;
												if (RTC == 0)
												{
													Console.WriteLine("Retry Counter Timeout");
													goto restart;
												}
												else
												{
												}
												goto Msg;
											}
										}
										else
										{
											RTC--;
											if (RTC == 0)
											{
												Console.WriteLine("Retry Counter Timeout");
												goto restart;
											}
											else
											{
											}
											goto tomR;
										}
									}
									else
									{
										RTC--;
										if (RTC == 0)
										{
											Console.WriteLine("Retry Counter Timeout");
											goto restart;
										}
										else
										{
										}
										goto Cap;
									}
								}
								else
								{
									RTC--;
									if (RTC == 0)
									{
										Console.WriteLine("Retry Counter Timeout");
										goto restart;
									}
									else
									{
									}
									goto TK;
								}
							}
							else
							{
								RTC--;
								if (RTC == 0)
								{
									Console.WriteLine("Retry Counter Timeout");
									goto restart;
								}
								else
								{
								}
								goto NT;
							}
						}
						else
						{
							Console.WriteLine("SNAK Error");
							goto restart;
						}
					}
					catch (Exception Ex) { goto restart; }
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