/*
*   Copyright (C) 2022 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Text.Json;
using System.Threading;

/*
* Tek entrys will only contain the name, All Tech Specific settings (Tone Pairs) will be in individual TXT files
* COMP is the comport of the RS232 relay ('A' Open, 'a' close)
* COMT is the comport of the Env Monitor PC, Toneout Voice Text will come via RS232 from the Env mon, along with what tek needs to be toned out.
*/

//TOTO: Add this!!!! https://github.com/gui-cs/Terminal.Gui

namespace TekNET
{
	public class CONF
	{
		public Dictionary<int, string> Techs { get; set; }
		public string COMP { get; set; }
		public string COMT { get; set; }
		public string ADP { get; set; }
	}

	internal class Program
	{
		internal string Techs = null;
		internal string COMP = null;
		internal string COMT = null;
		internal string ADP = null;

		private static void Main(string[] args)
		{
			Program P = new Program();
			Dictionary<int, string> TEK = new Dictionary<int, string>();
			P.Techs = null;
			P.COMP = null;
			P.COMT = null;
			P.ADP = null;
			int PENDUP = 0; //Pending Update
			string jsonString = null;
			Logger log = LogManager.GetCurrentClassLogger();
		B: //Restart point
			if (PENDUP == 1)
			{
				var CONF = new CONF
				{
					Techs = TEK,
					COMP = P.COMP,
					COMT = P.COMT,
					ADP = P.ADP
				};

				jsonString = JsonSerializer.Serialize(CONF);
				File.WriteAllText(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Conf.TNCONF", jsonString);
				PENDUP = 0;
			}
			int i = 4;

			jsonString = File.ReadAllText(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Conf.TNCONF");
			CONF? CONFO = JsonSerializer.Deserialize<CONF>(jsonString);
			P.ADP = CONFO.ADP;
			P.COMP = CONFO.COMP;
			P.COMT = CONFO.COMT;
			TEK = CONFO.Techs;

		A: //Menu Return w/o Settings Reload
			Console.Clear();
			Console.WriteLine("Centex Trunked Radio System");
			Console.WriteLine("V1.1");
			Console.WriteLine(@"__/\\\\\\\\\\\\\\\_______________________________/\\\\\_____/\\\__________________________________/\\\____");
			Console.WriteLine(@" _\///////\\\/////__________________/\\\_________\/\\\\\\___\/\\\________________________________/\\\\\\\__");
			Console.WriteLine(@"  _______\/\\\______________________\/\\\_________\/\\\/\\\__\/\\\____________________/\\\_______/\\\\\\\\\_");
			Console.WriteLine(@"   _______\/\\\___________/\\\\\\\\__\/\\\\\\\\____\/\\\//\\\_\/\\\_____/\\\\\\\\___/\\\\\\\\\\\_\//\\\\\\\__");
			Console.WriteLine(@"    _______\/\\\_________/\\\/////\\\_\/\\\////\\\__\/\\\\//\\\\/\\\___/\\\/////\\\_\////\\\////___\//\\\\\___");
			Console.WriteLine(@"     _______\/\\\________/\\\\\\\\\\\__\/\\\\\\\\/___\/\\\_\//\\\/\\\__/\\\\\\\\\\\_____\/\\\________\//\\\____");
			Console.WriteLine(@"      _______\/\\\_______\//\\///////___\/\\\///\\\___\/\\\__\//\\\\\\_\//\\///////______\/\\\_/\\_____\///_____ ");
			Console.WriteLine(@"       _______\/\\\________\//\\\\\\\\\\_\/\\\_\///\\\_\/\\\___\//\\\\\__\//\\\\\\\\\\____\//\\\\\_______/\\\____");
			Console.WriteLine(@"        _______\///__________\//////////__\///____\///__\///_____\/////____\//////////______\/////_______\///_____");
			/*i = 1;
			string[] tekArray = Techs.Split(',');

			foreach (string S in tekArray)
			{
				TEK.Add(i, S);

				i++;
			}*/
			i = 3;
			do
			{
				Console.WriteLine("");
				i--;
			} while (i != 0);
			Console.WriteLine("Menu");
			Console.WriteLine("1: Config");
			Console.WriteLine("2: Manage Techs");
			Console.WriteLine("3: Start");
			Console.WriteLine("4: Status");
			Console.WriteLine("5: Test");
			Console.Write("CMD: ");
			char CMD = Console.ReadKey().KeyChar;
			Console.WriteLine("");

			switch (CMD)
			{
				case '1':
				SetAgain:
					/*Config
				     *ER = Transmitter Comport
				     *EC = Env Mon Comport
				     *B = Back
					 */
					string NCOM;
					Console.Clear();

					Console.Write("Radio COM: ");
					Console.Write(P.COMP);
					Console.WriteLine("");
					Console.Write("ENV Mon COM: ");
					Console.Write(P.COMT);
					Console.WriteLine("");
					CMD = Console.ReadKey().KeyChar;
					if (CMD == 'E')
					{
						String[] PortNames = SerialPort.GetPortNames();
						CMD = Console.ReadKey().KeyChar;
						if (CMD == 'C')
						{
							Console.Clear();
							foreach (string S in PortNames)
							{
								Console.WriteLine(S);
							}
							Console.WriteLine("");
							Console.Write("Enter Port Name: ");
							NCOM = Console.ReadLine();
							if (PortNames.Any(NCOM.Contains))
							{
								P.COMP = NCOM;
								PENDUP = 1;
								goto B;
							}
							else
							{
								Console.WriteLine("");
								Console.WriteLine("Port Not Valid.... Press Any Key To Try Again");
								Console.ReadKey();
								goto SetAgain;
							}
						}
						else if (CMD == 'R')
						{
							Console.Clear();
							foreach (string S in PortNames)
							{
								Console.WriteLine(S);
							}
							Console.WriteLine("");
							Console.Write("Enter Port Name: ");
							NCOM = Console.ReadLine();
							if (PortNames.Any(NCOM.Contains))
							{
								P.COMT = NCOM;
								PENDUP = 1;
								goto B;
							}
							else
							{
								Console.WriteLine("");
								Console.WriteLine("Port Not Valid.... Press Any Key To Try Again");
								Console.ReadKey();
								goto SetAgain;
							}
						}
						else
						{
							Console.WriteLine("");
							Console.WriteLine("Command Not Valid.... Press Any Key To Try Again");
							Console.ReadKey();
							goto SetAgain;
						}
					}
					else if (CMD == 'B')
					{
						goto A;
					}
					else
					{
						Console.WriteLine("");
						Console.WriteLine("Command Not Valid.... Press Any Key To Try Again");
						Console.ReadKey();
						goto SetAgain;
					}
				case '2':
				SELTEK: //Tech Select Return
					Console.Clear();
					/*Tech View and Edit
					 * Number = Select Tech
					 * A = Add Tech
					 * D = Delete Tech
					 * Num ET = Edit Tech
					 * B = Back
					 */
					//Display , sep vals in Config on their own lines
					//When user selects a tech use the tech name to read the teks .TXT file and display details
					i = 1;
					foreach (string S in TEK.Values)
					{
						Console.Write(i + ": ");
						Console.WriteLine(S);
						i++;
					}

					CMD = Console.ReadKey().KeyChar;
					if (CMD == 'B' || CMD == 'b')
					{
						goto A;
					}
					else if (CMD == 'A' || CMD == 'a')
					{
						try
						{
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.Blue;
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("TECH ADD");
							Console.ResetColor();
							Console.WriteLine("");
							string TNAME = null;
							string FT = null;
							string ST = null;
							Console.Write("Enter Tech Name: ");
							TNAME = Console.ReadLine();
							Console.Write("First Tone? ");
							FT = Console.ReadLine();
							Console.Write("Second Tone? ");
							ST = Console.ReadLine();

							StreamWriter sw = new StreamWriter(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + TNAME + ".txt");
							sw.WriteLine(FT);
							sw.WriteLine(ST);
							sw.Close();

							TEK.Add((TEK.Keys.Count + 1), TNAME);
							string TEKSTRING = null;
							foreach (string S in TEK.Values)
							{
								TEKSTRING = S + ",";
							}
							P.Techs = TEKSTRING;
							PENDUP = 1;
							goto B;
						}
						catch (Exception e)
						{
							Console.WriteLine("Exception: " + e.Message);
						}
					}
					else if (CMD == 'D' || CMD == 'd')
					{
						try
						{
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.Red;
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine("TECH DELETE");
							Console.ResetColor();
							Console.WriteLine("");
							Console.WriteLine("Enter Password: ");
							if (Console.ReadLine() != P.ADP)
							{
								Console.WriteLine("Incorrect Password");
								goto SELTEK;
							}
							string TNAME = null;
							Console.Write("Enter Tech Name: ");
							TNAME = Console.ReadLine();
							File.Delete(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + TNAME + ".txt");
							TEK.Remove(TEK.Keys.Where(x => TEK[x] == TNAME).FirstOrDefault());
							string TEKSTRING = null;
							foreach (string S in TEK.Values)
							{
								TEKSTRING = S + ",";
							}
							P.Techs = TEKSTRING;
							PENDUP = 1;
							goto B;
						}
						catch (Exception e)
						{
							Console.WriteLine("Exception: " + e.Message);
						}
					}
					else if (TEK.ContainsKey(int.Parse(CMD.ToString())))
					{
						Console.Clear();
						Console.BackgroundColor = ConsoleColor.White;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine(TEK[int.Parse(CMD.ToString())]);
						Console.ResetColor();
						Console.WriteLine("");
						string[] lines = null;
						string TPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + TEK[int.Parse(CMD.ToString())] + ".txt";
						try
						{
							lines = File.ReadAllLines(TPATH);
						}
						catch (Exception e)
						{
							Console.WriteLine("");
							Console.WriteLine("Tech File Missing");
							Console.Beep();
							Console.Beep();
							Console.Beep();
							Console.ReadKey();
							goto SELTEK;
						}

						i = 0;
						foreach (string line in lines)
						{
							if (i == 0)
							{
								Console.Write("First Tone: ");
							}
							else if (i == 1)
							{
								Console.Write("Second Tone: ");
							}
							Console.WriteLine(line);
							i++;
						}
						CMD = Console.ReadKey().KeyChar;
						if (CMD == 'E' || CMD == 'e')
						{
							if (CMD == 'T' || CMD == 't')
							{
								string FT = null;
								string ST = null;
								Console.Clear();
								Console.Write("First Tone? ");
								FT = Console.ReadLine();
								Console.Write("Second Tone? ");
								ST = Console.ReadLine();

								try
								{
									StreamWriter sw = new StreamWriter(TPATH);
									sw.WriteLine(FT);
									sw.WriteLine(ST);
									sw.Close();
								}
								catch (Exception e)
								{
									Console.WriteLine("Exception: " + e.Message);
								}
							}
							else
							{
								Console.WriteLine("");
								Console.WriteLine("Command Not Valid.... Press Any Key To Try Again");
								Console.ReadKey();
								goto SELTEK;
							}
						}
						else if (CMD == 'B' || CMD == 'b')
						{
							goto SELTEK;
						}
						else
						{
							Console.WriteLine("");
							Console.WriteLine("Command Not Valid.... Press Any Key To Try Again");
							Console.ReadKey();
							goto SELTEK;
						}
					}
					else
					{
						Console.WriteLine("");
						Console.WriteLine("Tech Not Valid.... Press Any Key To Try Again");
						Console.ReadKey();
						goto SELTEK;
					}

					Console.ReadKey();
					goto SELTEK;

				case '3':
					String RxedData = null;             // String to store received data
					SerialPort MyCOMPort = new SerialPort(); //new SerialPort Object

					//COM port settings to 8N1 mode
					MyCOMPort.PortName = P.COMP;            // Name of the COM port
					MyCOMPort.BaudRate = 115200;            // Baudrate = 115200bps
					MyCOMPort.Parity = Parity.None;         // Parity bits = none
					MyCOMPort.DataBits = 8;                 // No of Data bits = 8
					MyCOMPort.StopBits = StopBits.One;      // No of Stop bits = 1

					int NT = 0;
					int CAP = 0;
					string TXMSG = null;
					string[] RXTECH;

					try
					{
						MyCOMPort.Open();      // Open the port
					}
					catch (Exception Ex)
					{
					}
					if (MyCOMPort.IsOpen == false)
					{
						Console.Clear();
						Console.WriteLine("Port " + P.COMP + " Failed to open... Try again");
						Console.ReadKey();
						goto A;
					}
					else
					{
						Console.Clear();
						Console.WriteLine("Waiting for Data");
					}
				ST:
					MyCOMPort.WriteLine("TNS");
					try
					{
						RxedData = MyCOMPort.ReadLine(); // Wait for data reception
#if DEBUG
						Console.WriteLine(RxedData);
#endif
					}
					catch (Exception Ex)//Catch Time out Exception
					{
#if DEBUG
						Console.WriteLine(Ex.Message);
#endif
					}
					if (RxedData == "VCALL737")
					{
						MyCOMPort.WriteLine("RCALL858");
					RT:
						RxedData = MyCOMPort.ReadLine();
#if DEBUG
						Console.WriteLine(RxedData);
#endif
						string SHAR = null;
						try { SHAR = RxedData.Substring(0, 2); }
						catch (Exception e)
						{
							MyCOMPort.WriteLine("NAK");
							goto RT;
						}

						if (SHAR == "NT")
						{
							try { SHAR = RxedData.Substring(2, 2); }
							catch (Exception e)
							{
								MyCOMPort.WriteLine("NAK");
								goto RT;
							}

							try
							{
								NT = int.Parse(SHAR);
								MyCOMPort.WriteLine("NTACK");
							}
							catch (Exception E)
							{
								MyCOMPort.WriteLine("NAK");
								goto RT;
							}
						TK:
							RxedData = MyCOMPort.ReadLine();
#if DEBUG
							Console.WriteLine(RxedData);
#endif
							try { SHAR = RxedData.Substring(0, 2); }
							catch (Exception e)
							{
								MyCOMPort.WriteLine("NAK");
								goto TK;
							}
							if (SHAR == "TK")
							{
								string rxtechtemp;
								try { rxtechtemp = RxedData.Substring(2, (RxedData.Length - 2)); }
								catch (Exception e)
								{
									MyCOMPort.WriteLine("NAK");
									goto TK;
								}
								RXTECH = rxtechtemp.Split(',');
#if DEBUG
								Console.WriteLine("DEBUG: TECHS:");
								foreach (string s in RXTECH)
								{
									Console.WriteLine(s);
								}
#endif
								MyCOMPort.WriteLine("TKAK");
							}
							else
							{
								MyCOMPort.WriteLine("NAK");
								goto TK;
							}

						NT:
							RxedData = MyCOMPort.ReadLine();
#if DEBUG
							Console.WriteLine(RxedData);
#endif
							try { SHAR = RxedData.Substring(0, 3); }
							catch (Exception e)
							{
								MyCOMPort.WriteLine("NAK");
								goto NT;
							}
							if (SHAR == "CAP")
							{
								try { SHAR = RxedData.Substring(3, 2); }
								catch (Exception e)
								{
									MyCOMPort.WriteLine("NAK");
									goto NT;
								}
								try
								{
									CAP = int.Parse(SHAR);
								}
								catch (Exception ex)
								{
									MyCOMPort.WriteLine("NAK");
									goto NT;
								}
								MyCOMPort.WriteLine("CAPACK");
							CAP:
								RxedData = MyCOMPort.ReadLine();
#if DEBUG
								Console.WriteLine(RxedData);
#endif
								if (RxedData == "TOMR")
								{
									MyCOMPort.WriteLine("RFT");
								}
								else
								{
									MyCOMPort.WriteLine("NAK");
									goto CAP;
								}
							TOM:
								RxedData = MyCOMPort.ReadLine();
								try { SHAR = RxedData.Substring(0, 3); }
								catch (Exception e)
								{
									MyCOMPort.WriteLine("NAK");
									goto TOM;
								}

#if DEBUG
								Console.WriteLine(RxedData);
#endif
								if (SHAR == "TOM")
								{
									try { TXMSG = RxedData.Substring(3, (RxedData.Length - 3)); }
									catch (Exception e)
									{
										MyCOMPort.WriteLine("NAK");
										goto TOM;
									}

#if DEBUG
									Console.WriteLine("Message: " + TXMSG);
#endif
								}
								else
								{
									MyCOMPort.WriteLine("NAK");
									goto TOM;
								}
								MyCOMPort.WriteLine("TOMACK");
							TACK:
								RxedData = MyCOMPort.ReadLine();
#if DEBUG
								Console.WriteLine(RxedData);
#endif
								string rxsum;
								string hash;
								string dbugtemp = (RxedData.Substring(0, 6));
								if (dbugtemp == "CHKSUM")
								{
									try
									{
										rxsum = RxedData.Substring(6, (RxedData.Length - 6));
#if DEBUG
										Console.WriteLine("RXSUM: " + rxsum);
#endif
										using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
										{
											hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(TXMSG))).Replace("-", String.Empty);
										}
#if DEBUG
										Console.WriteLine("HASH: " + hash);
#endif
										if (String.Equals(rxsum, hash))
										{
											MyCOMPort.WriteLine("CHKSUMAK");
										}
										else
										{
											MyCOMPort.WriteLine("CHKSUMNAK");
											goto CAP;
										}
										//Start Page
										//FYI IDIOT: You didnt add a place in the comms for it to tell TechNet what techs to page.... Just do an all call for now... idot
										//TODO: THIS
										TONEOUT(TXMSG, RXTECH, NT, CONFO.COMT);
										MyCOMPort.WriteLine("RFNM");
										goto ST;
									}
									catch (Exception e)
									{
										MyCOMPort.WriteLine("CHKSUMNAK");
										goto CAP;
									}
								}
								else
								{
									MyCOMPort.WriteLine("NAK");
									goto TACK;
								}
							}
							else
							{
								MyCOMPort.WriteLine("NAK");
								goto NT;
							}
						}
						else
						{
							MyCOMPort.WriteLine("NAK");
							goto RT;
						}
						/*
						 * Wait for VCALL737
						 * Send RCALL858
						 * Wait for NT## (must be sent as two digit)
						 * Store NT (Number of Techs)
						 * Send NTACK
						 * Wait for TKtech1,tech2,tech3 (Tech list must be Comma seped)
						 * Send TKACK
						 * TODO:Wait for CHKSUM
						 * TODO:Store TCHKSUM
						 * TODO:Compare TCHKSUM RX to Computed Checksum of TK
						 * TODO:Send TCHKSUMAK if good
						 * TODO:Send TCHKSUMNAK if bad
						 * TODO:If bad, jump back to wait for TOMR
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
						 *
						 * TODO: Add Abort and Retry Code
						 */
					}
					else
					{
						MyCOMPort.Write("SNAK");
						goto ST;
					}
					Console.Beep();
					goto ST;
				case '4':
					Console.Clear();
					break;

				case '5':
					Console.Clear();
					Console.Write("Enter Password: ");

					if (Console.ReadLine() == P.ADP)
					{
					T:
						Console.Clear();
						Console.WriteLine("Monthly");
						Console.WriteLine("Tech");
						CMD = Console.ReadKey().KeyChar;
						if (CMD == 'M' || CMD == 'm')
						{
							Console.WriteLine("Page Out");
							log.Info("Test Page ");
							RS232RELAYOPEN(P.COMT);
							using (var synthesizer = new SpeechSynthesizer())
							{
								using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Alert1.wav"))
								{
									synthesizer.SetOutputToDefaultAudioDevice();
									Sin(1000, 8);
									Thread.Sleep(1000);

									player.PlaySync();
									synthesizer.Speak("This is a monthly test of the Centex Trunked Radio System Tech Net Pageing System. Technet Out");
								}
							}
							RS232RELAYCLOSE(P.COMT);
							goto T;
						}
						else if (CMD == 'T' || CMD == 't')
						{
							Console.WriteLine("Multiple? Y/N");
							Console.Clear();
							i = 1;
							foreach (string S in TEK.Values)
							{
								Console.Write(i + ": ");
								Console.WriteLine(S);
								i++;
							}

							CMD = Console.ReadKey().KeyChar;
							if (CMD == 'B' || CMD == 'b')
							{
								goto T;
							}
							else if (TEK.ContainsKey(int.Parse(CMD.ToString())))
							{
								Console.Clear();
								Console.BackgroundColor = ConsoleColor.White;
								Console.ForegroundColor = ConsoleColor.Black;
								Console.WriteLine(TEK[int.Parse(CMD.ToString())]);
								Console.ResetColor();
								Console.WriteLine("");
								string[] lines = null;
								double FT = 0;
								double ST = 0;
								string T = TEK[int.Parse(CMD.ToString())];
								string TPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + T + ".txt";
								try
								{
									lines = File.ReadAllLines(TPATH);
								}
								catch (Exception e)
								{
									Console.WriteLine("");
									Console.WriteLine("Tech File Missing");
									Console.Beep();
									Console.Beep();
									Console.Beep();
									Console.ReadKey();
									goto T;
								}

								i = 0;
								foreach (string line in lines)
								{
									if (i == 0)
									{
										FT = double.Parse(line);
									}
									else if (i == 1)
									{
										ST = double.Parse(line);
									}
									i++;
								}

								Console.WriteLine("Page Out - " + T);
								log.Info("Test Page -" + T);

								//Console.Beep(FT, 1000);
								//Console.Beep(ST, 3000);
								RS232RELAYOPEN(P.COMT);
								using (var synthesizer = new SpeechSynthesizer())
								{
									using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Alert1.wav"))
									{
										synthesizer.SetOutputToDefaultAudioDevice();
										Sin(FT, 1);
										Sin(ST, 3);
										Thread.Sleep(1000);
										player.PlaySync();
										synthesizer.Speak(T + "," + T + "This is a  test of the paging system. Time out," + DateTime.Now.ToString("hh mm ss tt") + " Technet Out");
									}
								}
								RS232RELAYCLOSE(P.COMT);
								goto T;
							}
						}
						else if (CMD == 'B' || CMD == 'b')
						{
							goto B;
						}
						else
						{
							Console.ReadKey();
							goto B;
						}
						Console.ReadKey();
						goto B;
					}
					else
					{
						Console.WriteLine("Wrong Password");
						Console.ReadKey();
						goto B;
					}

				case '6':
					Console.Clear();
					break;

				case 'E':
				case 'e':
					Console.Beep();
					Environment.Exit(1);
					break;

				default:
					Console.WriteLine("");
					Console.WriteLine("Command Not Valid.... Press Any Key To Try Again");
					Console.ReadKey();
					Console.Clear();
					goto A;
			}
			Console.ReadLine();
		}

		/// <summary>
		/// Starts a toneout, Requires a Message, String Array of techs, the Radio Comport, and The Priority
		/// </summary>
		/// <param name="message"></param>
		/// <param name="techs"></param>
		/// <param name="pri"></param>
		/// <param name="COMR"></param>
		internal static bool TONEOUT(string message, string[] techs, int pri, string COMR)
		{
			try
			{
				Logger log = LogManager.GetCurrentClassLogger();
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Page Out");
				log.Info("Page Out");
				Console.WriteLine("Priority: " + pri);
				log.Info("Priority: " + pri);
				if (techs != null)
				{
					foreach (string S in techs)
					{
						Console.WriteLine("Tech: " + S);
						log.Info("Tech: " + S);
					}
				}
				else
				{
					return false;
				}

				Console.WriteLine("Message: " + message);
				log.Info("Message: " + message);
				Console.ResetColor();
				RS232RELAYOPEN(COMR);
				using (var synthesizer = new SpeechSynthesizer())
				{
					string alert = "\\Alert1.wav";
					switch (pri)
					{
						case 1:
							alert = "\\Alert2.wav";
							break;

						case 2:
							alert = "\\Alert3.wav";
							break;

						case 3:
							alert = "\\Alert4.wav";
							break;

						case 4:
							alert = "\\Alert5.wav";
							break;

						case 0:
						default:
							alert = "\\Alert1.wav";
							break;
					}
					using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + alert))
					{
						synthesizer.SetOutputToDefaultAudioDevice();
						Sin(1000, 8);
						Thread.Sleep(1000);

						player.PlaySync();
						synthesizer.Speak(message);
					}
				}
				RS232RELAYCLOSE(COMR);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// Opens the relay, Requires a comport
		/// </summary>
		/// <param name="COMT"></param>
		internal static void RS232RELAYOPEN(string COMT)
		{
			using (SerialPort MyCOMPort = new SerialPort())
			{
				string jsonString;
				jsonString = File.ReadAllText(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Conf.TNCONF");
				CONF? CONFO = JsonSerializer.Deserialize<CONF>(jsonString);
				//COM port settings to 8N1 mode
				MyCOMPort.PortName = CONFO.COMT;          // Name of the COM port
				MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
				MyCOMPort.Parity = Parity.None;        // Parity bits = none
				MyCOMPort.DataBits = 8;                  // No of Data bits = 8
				MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1

				try
				{
					MyCOMPort.Open();   // Open the port
				}
				catch (Exception Ex)
				{
				}
				try
				{
					MyCOMPort.Write("A");                    // Write an ascii "a"
				}
				catch (Exception Ex) { }

				MyCOMPort.Close();
			}
		}

		/// <summary>
		/// closes the relay, Requires a Comport
		/// </summary>
		/// <param name="COMT"></param>
		internal static void RS232RELAYCLOSE(string COMT)
		{
			using (SerialPort MyCOMPort = new SerialPort())
			{
				string jsonString;
				jsonString = File.ReadAllText(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Conf.TNCONF");
				CONF? CONFO = JsonSerializer.Deserialize<CONF>(jsonString);
				//COM port settings to 8N1 mode
				MyCOMPort.PortName = CONFO.COMT;          // Name of the COM port
				MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
				MyCOMPort.Parity = Parity.None;        // Parity bits = none
				MyCOMPort.DataBits = 8;                  // No of Data bits = 8
				MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1

				try
				{
					MyCOMPort.Open();   // Open the port
				}
				catch (Exception Ex)
				{
				}
				try
				{
					MyCOMPort.Write("a");                    // Write an ascii "a"
				}
				catch (Exception Ex) { }
				MyCOMPort.Close();
			}
		}

		/// <summary>
		/// Makes a sinewave, Requires a Freq and a time
		/// </summary>
		/// <param name="Freq"></param>
		/// <param name="time"></param>
		internal static void Sin(double Freq, int time)
		{
			var sineSeconds = new SignalGenerator()
			{
				Gain = 0.5,
				Frequency = Freq,
				Type = SignalGeneratorType.Sin
			}
			.Take(TimeSpan.FromSeconds(time));
			using (var wo = new WaveOutEvent())
			{
				wo.Init(sineSeconds);
				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					Thread.Sleep(100);
				}
			}
		}
	}
}