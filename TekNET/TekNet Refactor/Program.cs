/*
*   Copyright (C) 2024 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NLog;
using System.Reflection;
using System.Speech.Synthesis;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;

namespace TekNet_Refactor
{
	internal class Program
	{
		/// <summary>
		/// Main Program
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			Program P = new Program();
			Options opt = new Options();
			Logger log = LogManager.GetCurrentClassLogger();
			bool ran = false;
			bool ranho = false;
			Dictionary<string, string[]> msgs = new Dictionary<string, string[]>();

			string emsub = "";
			bool imapcheck = false;
			string checkval1 = "";
			int highestlevel = 3;
			bool newalert = false;
			string alertsite = " Unknown ";
			bool MULTIFAIL = false;
			string messages = "TEKNET ERROR";
			Startup start = new Startup();
			start.opset();

		A:
			Console.Clear();
			Console.WriteLine(@"__/\\\\\\\\\\\\\\\_______________________________/\\\\\_____/\\\__________________________________/\\\____");
			Console.WriteLine(@" _\///////\\\/////__________________/\\\_________\/\\\\\\___\/\\\________________________________/\\\\\\\__");
			Console.WriteLine(@"  _______\/\\\______________________\/\\\_________\/\\\/\\\__\/\\\____________________/\\\_______/\\\\\\\\\_");
			Console.WriteLine(@"   _______\/\\\___________/\\\\\\\\__\/\\\\\\\\____\/\\\//\\\_\/\\\_____/\\\\\\\\___/\\\\\\\\\\\_\//\\\\\\\__");
			Console.WriteLine(@"    _______\/\\\_________/\\\/////\\\_\/\\\////\\\__\/\\\\//\\\\/\\\___/\\\/////\\\_\////\\\////___\//\\\\\___");
			Console.WriteLine(@"     _______\/\\\________/\\\\\\\\\\\__\/\\\\\\\\/___\/\\\_\//\\\/\\\__/\\\\\\\\\\\_____\/\\\________\//\\\____");
			Console.WriteLine(@"      _______\/\\\_______\//\\///////___\/\\\///\\\___\/\\\__\//\\\\\\_\//\\///////______\/\\\_/\\_____\///_____ ");
			Console.WriteLine(@"       _______\/\\\________\//\\\\\\\\\\_\/\\\_\///\\\_\/\\\___\//\\\\\__\//\\\\\\\\\\____\//\\\\\_______/\\\____");
			Console.WriteLine(@"        _______\///__________\//////////__\///____\///__\///_____\/////____\//////////______\/////_______\///_____");
			if (opt.clock == true)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(@"                                                     CLOCK ENABLED");
				Console.ResetColor();
			}
			if (opt.testpages == true)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(@"                                                  TEST PAGES ENABLED");
				Console.ResetColor();
			}
			if (opt.pageout == true)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(@"                                                   PAGE OUT ENABLED");
				Console.ResetColor();
			}
#if DEBUG
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(@"                                                   DEBUG MODE");
			Console.ResetColor();
#endif

			int i;
			i = 3;
			do
			{
				Console.WriteLine("");
				i--;
			} while (i != 0);

			Console.WriteLine("Running");
			Console.WriteLine("");
			Console.WriteLine("");
		T:
			string TN;
			string DTN = DateTime.Now.ToString("hh:mm tt");
			if (opt.clock24h == true)
			{
				TN = DateTime.Now.ToString("HH mm");
			}
			else
			{
				TN = DateTime.Now.ToString("hh mm");
			}
			string Date = DateTime.Now.ToString("dddd MMMM d");
			string DTNS;
			if (opt.clock24h == true)
			{
				DTNS = DateTime.Now.ToString("HH:mm:ss");
			}
			else
			{
				DTNS = DateTime.Now.ToString("hh:mm:ss tt");
			}
			string DTNMO = DateTime.Now.ToString("mm");

			if (imapcheck == true)
			{
				string newcheckval = DateTime.Now.ToString("mm");
				if (newcheckval != checkval1)
				{
					imapcheck = false;
					checkval1 = newcheckval;
				}
			}

			if (opt.imapenab == true && imapcheck == false)
			{
				try
				{
					using (var client = new ImapClient())
					{
						using (var cancel = new CancellationTokenSource())
						{
							Console.Write("Checking Email");
							client.Connect(opt.imapaddress, 993, true, cancel.Token);
							client.AuthenticationMechanisms.Remove("XOAUTH");
							client.Authenticate(opt.imapuser, opt.imappass, cancel.Token);
							var inbox = client.Inbox;
							inbox.Open(FolderAccess.ReadWrite, cancel.Token);
							var query = SearchQuery.NotSeen;
							foreach (var uid in inbox.Search(query, cancel.Token))
							{
								var message = inbox.GetMessage(uid, cancel.Token);
								client.Inbox.AddFlags(uid, MessageFlags.Seen, true, cancel.Token);
								emsub = message.Subject;

								//Check for the site name in the subject
								foreach (string S in opt.sites.Keys)
								{
									if (emsub.Contains(S) == true)
									{
										alertsite = opt.sites[S];
									}
								}

								//string[0] = Level
								//string[1] = Level Text
								//string[2] = Location
								//string[3] = Message (make "TEST" for rn")
								string[] tmparrsl = new string[4];

								/*Level 0 = Critical
								Level 1 = Major
								Level 2 = Commfail
								Level 10 = Warning
								Level 55 = Test*/
								int level = 3;

								string textbody = message.TextBody;

								var separators = new[] { '\r', '\n' };
								var lines = textbody.Split(separators, StringSplitOptions.RemoveEmptyEntries);
								messages = lines[1];

								if (emsub.Contains("Critical") == true)
								{
									highestlevel = 0;
									level = 0;
									if (newalert == true)
									{
										MULTIFAIL = true;
									}
									else
									{
										newalert = true;
									}
									tmparrsl[0] = "0";
									tmparrsl[1] = "Critical Alarm";
									tmparrsl[2] = alertsite;
									tmparrsl[3] = messages;
									int key1 = 0;
									try
									{
										key1 = msgs.Count + 1;
									}
									catch (Exception ex)
									{
										key1 = 0;
									}

									msgs.Add(key1.ToString(), tmparrsl);
								}
								else if (emsub.Contains("CommFailure") == true)
								{
									if (highestlevel != 0)
									{
										highestlevel = 2;
									}
									level = 2;
									if (newalert == true)
									{
										MULTIFAIL = true;
									}
									else
									{
										newalert = true;
									}
									tmparrsl[0] = "2";
									tmparrsl[1] = "Comunications Failure";
									tmparrsl[2] = alertsite;
									tmparrsl[3] = messages;
									int key = msgs.Count + 1;
									msgs.Add(key.ToString(), tmparrsl);
								}
								else if (emsub.Contains("Major") == true)
								{
									if (highestlevel != 0 && highestlevel != 2)
									{
										highestlevel = 1;
									}
									level = 1;
									if (newalert == true)
									{
										MULTIFAIL = true;
									}
									else
									{
										newalert = true;
									}
									tmparrsl[0] = "1";
									tmparrsl[1] = "Major Alarm";
									tmparrsl[2] = alertsite;
									tmparrsl[3] = messages;
									int key = msgs.Count + 1;
									msgs.Add(key.ToString(), tmparrsl);
								}
								else if (emsub.Contains("Warning") == true)
								{
									if (highestlevel != 0 && highestlevel != 2 && highestlevel != 1)
									{
										highestlevel = 10;
									}
									level = 10;
									if (newalert == true)
									{
										MULTIFAIL = true;
									}
									else
									{
										newalert = true;
									}
									tmparrsl[0] = "10";
									tmparrsl[1] = "Warning";
									tmparrsl[2] = alertsite;
									tmparrsl[3] = messages;
									int key = msgs.Count + 1;
									msgs.Add(key.ToString(), tmparrsl);
								}
								else if (emsub.Contains("TEST") == true)
								{
									if (highestlevel != 0 && highestlevel != 2 && highestlevel != 1)
									{
										highestlevel = 55;
									}
									level = 55;
									newalert = true;
								}
#if DEBUG
								Console.WriteLine(emsub);
#endif
							}

							client.Disconnect(true, cancel.Token);
						}
					}
				}
				catch (Exception ex)
				{
					log.Error(ex.Message);
#if DEBUG

					Console.WriteLine(ex.Message);
#endif
				}
				ClearCurrentConsoleLine();
				imapcheck = true;
			}

			Console.Write(DTNS);

			if (DTN == opt.testpagetrigtime)
			{
				if (ran == false)
				{
					ran = true;
					Console.Clear();
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("Trigger");
					Console.WriteLine(DTN);
					Console.ResetColor();

					using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Alert9.wav"))
					{
						using (var synthesizer = new SpeechSynthesizer())
						{
							string FPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\";

							DirectoryInfo d = new DirectoryInfo(FPATH);
							synthesizer.SetOutputToDefaultAudioDevice();
							foreach (var file in d.GetFiles("*.txt"))
							{
								int iiiiiiii = 0;
								string TPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + file.Name;

								string[] lines = null;
								Console.WriteLine(file.Name);
								double FT = 0;
								double ST = 0;

								if (iiiiiiii == 0)
								{
									iiiiiiii = 1;
									lines = File.ReadAllLines(TPATH);
									FT = double.Parse(lines[0]);
									ST = double.Parse(lines[1]);
									ToneSend.Sin(FT, 1);
									FT = 0;
									ToneSend.Sin(ST, 3);
									ST = 0;
									Thread.Sleep(700);
									iiiiiiii = 0;
								}
							}
							player.PlaySync();
							synthesizer.Speak(opt.testpagetext + DateTime.Now.ToString("HH:mm"));
							Console.Clear();
						}
					}
					goto A;
				}
			}
			else if (DTN == opt.testpagetrigclear && ran == true && opt.testpages == true)
			{
				ran = false;
				goto A;
			}
			else if (DTNMO == opt.clocktrigtime && opt.clock == true && ranho == false)
			{
				ranho = true;

				using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\CHIME.wav"))
				{
					using (var synthesizer = new SpeechSynthesizer())
					{
						synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
						player.PlaySync();
						synthesizer.Speak(opt.clockbtext + Date + " , " + TN + opt.clockatext);
					}
				}
				goto A;
			}
			else if (DTNMO == opt.clocktrigtimeclear.ToString() && ranho == true)
			{
				ranho = false;
				goto A;
			}
			else if (newalert == true)
			{
				newalert = false;
				Console.Clear();
				if (0 != 1)
				{
					Console.WriteLine("###########################++---------------------------------..");
					Console.WriteLine("############################+-----------------------------------");
					Console.WriteLine("#########+###################+---------------------------------.");
					Console.WriteLine("#######++++++++##############++---------------------+####+------");
					Console.WriteLine("########++++++++##############+-----------------++######+--.....");
					Console.WriteLine("########++++++++##############++++++++++-----++########++------.");
					Console.WriteLine("########+++++++##########################++++##########+--------");
					Console.WriteLine("########+++++++#######################################+---------");
					Console.WriteLine("##########+++++###################++++++++++########+++---------");
					Console.WriteLine("##########+++###############+++++++++++----+++######++----------");
					Console.WriteLine("#########################+++######+---+----+++#######+----------");
					Console.WriteLine("##################################+++++-..--+#######+#+---------");
					Console.WriteLine("########################++#######++++---.---+#-#####+##+--------");
					Console.WriteLine("########################++#####++#+-....-----++###+++#++--------");
					Console.WriteLine("#########################++####+--.....----------+++#++---------");
					Console.WriteLine("#######################+##++++--.......--++------+####+---------");
					Console.WriteLine("###########################++--..........----+----+##+----------");
					Console.WriteLine("####################++++++++----........---++-.----+#+----------");
					Console.WriteLine("##################++++#++++++------..----++--------+++----------");
					Console.WriteLine("######################+++++++++-------++##+++------++-----------");
					Console.WriteLine("#####################+++#++--++++###++#######+----+#+-----------");
					Console.WriteLine("#####################++++-+++###############+++++#+++-----------");
					Console.WriteLine("###############+++++------+####+###################+------------");
					Console.WriteLine("####++########+++----------+#++++++++++##########+++------------");
					Console.WriteLine("####++++++++++--------------+++++++++++#+++++++++++-------------");
					Console.WriteLine("####++++++--------------------+++++++-++---+++++++--------------");
					Console.WriteLine("####++++++----------------------+++++-+-----++++++--------------");
					Console.WriteLine("###++++++++--------------------------++----+++++++++------------");
					Console.WriteLine("####+++++++++-------+++++-----##+---+++---++-+++++++++----------");
					Console.WriteLine("#####++++++++++--++++++++-----+###+##+++++++++++++++------------");
					Console.WriteLine("#######++++++++++++++++++++-----++#####++++++++++++-------------");
					Console.WriteLine("#######++++++++++++++++++++++++#######+++++++++++++-------------");
					Console.WriteLine("########++-------++++++++++++++#######++++++++++++++++----------");
					Console.WriteLine("########+++-------+++++++++++#########++++++++++++++-++---------");
					Console.WriteLine("#########+++------+++++++++###########++++++++++++++++----------");
				}
				foreach (string[] S in msgs.Values)
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("NEW PAGE");
					Console.WriteLine(DTN);
					Console.WriteLine("Highest Alert: " + highestlevel.ToString());
					Console.WriteLine("Current Level: " + S[1]);
					Console.WriteLine("Site: " + alertsite);
					Console.ResetColor();
					int curlevel = int.Parse(S[0]);
					string alertsnd = "\\AO1.wav";
					switch (curlevel)
					{
						case 0:
							alertsnd = "\\AO1.wav";
							break;

						case 1:
							alertsnd = "\\Alert2.wav";
							break;

						case 2:
							alertsnd = "\\Alert9.wav";
							break;

						case 10:
							alertsnd = "\\Alert3.wav";
							break;

						case 55:
							alertsnd = "\\CHIME.wav";
							break;
					}
					if (MULTIFAIL == true)
					{
						alertsnd = "\\Alert7.wav";
					}
					using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\" + alertsnd))
					{
						using (var synthesizer = new SpeechSynthesizer())
						{
							string FPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\";

							DirectoryInfo d = new DirectoryInfo(FPATH);
							synthesizer.SetOutputToDefaultAudioDevice();
							foreach (var file in d.GetFiles("*.txt"))
							{
								int iiiiiiii = 0;
								string TPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Techs\\" + file.Name;

								string[] lines = null;
								Console.WriteLine(file.Name);
								double FT = 0;
								double ST = 0;

								if (iiiiiiii == 0)
								{
									iiiiiiii = 1;
									lines = File.ReadAllLines(TPATH);
									FT = double.Parse(lines[0]);
									ST = double.Parse(lines[1]);
									ToneSend.Sin(FT, 1);
									FT = 0;
									ToneSend.Sin(ST, 3);
									ST = 0;
									Thread.Sleep(700);
									iiiiiiii = 0;
								}
							}
							string alertlev = "TEK NET ERROR";
							string pageouttext = "ERROR, ERROR, ERROR,ERROR, ERROR, ERROR";

							if (MULTIFAIL == false)
							{
								switch (highestlevel)
								{
									case 0:
										alertlev = "Critical Alert";
										break;

									case 1:
										alertlev = "Major Alert";
										break;

									case 2:
										alertlev = "Comm Failure";
										break;

									case 10:
										alertlev = "Warning";
										break;

									case 55:
										alertlev = "Test Alert";
										break;
								}
							}

							player.PlaySync();
							using (System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\" + "\\YEEHAW.wav"))
							{
								if (MULTIFAIL == false && highestlevel == 55)
								{
									pageouttext = "This is a test pageout. This test could have been sent out by UEM or by a manual email. If this test was not expected please contact your system administrator";
									synthesizer.Speak(pageouttext);
								}
								else if (MULTIFAIL == false && opt.UEMadv == false)
								{
									pageouttext = "ATTENTION. ATTENTION. " + alertlev + "detected at " + alertsite + ". Respond immediately!";
									synthesizer.Speak(pageouttext);
								}
								else if (MULTIFAIL == false && opt.UEMadv == true)
								{
									pageouttext = "ATTENTION. ATTENTION. " + alertlev + "detected at " + alertsite + ". Details to follow.";
									synthesizer.Speak(pageouttext);
									pageouttext = messages;
									synthesizer.Speak("Alarm Message." + pageouttext);
									player2.PlaySync();
								}
								else if (MULTIFAIL == true)
								{
									pageouttext = "LETS ROLL THEM. MULTIPLE ALERTS DETECTED. Details to follow.";
									synthesizer.Speak(pageouttext);
									foreach (string[] s in msgs.Values)
									{
										alertlev = s[1];
										alertsite = s[2];
										messages = s[3];
										pageouttext = alertlev + "detected at " + alertsite + "." + "Alarm Message," + messages;
										synthesizer.Speak(pageouttext);
									}
									TN = DateTime.Now.ToString("HH mm");
									pageouttext = "Irina Clear," + TN;
									synthesizer.Speak(pageouttext);
									player2.Play();
								}
							}
							msgs.Clear();
							MULTIFAIL = false;
							highestlevel = 3;
							alertsite = " Unknown ";
							messages = "TEKNET ERROR";

							Console.Clear();
						}
					}
				}

				goto A;
			}

			Thread.Sleep(1000);

			ClearCurrentConsoleLine();
			goto T;
		}

		/// <summary>
		/// Clears the current line in the console
		/// </summary>
		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}

		/// <summary>
		/// Clears the last line in the console
		/// </summary>
		public static void ClearLastLine()
		{
			Console.SetCursorPosition(0, Console.CursorTop - 1);
			Console.Write(new string(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, Console.CursorTop - 1);
		}
	}
}
