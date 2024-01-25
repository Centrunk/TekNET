/*
*   Copyright (C) 2024 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Net.NetworkInformation;

namespace TekNET
{
	internal class Program
	{
		internal bool STRIG = false;

		/// <summary>
		/// Main Program
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			Program P = new Program();
			Logger log = LogManager.GetCurrentClassLogger();
			bool ran = false;
			bool ranho = false;

			//Options
			bool clock = true;
			string clockbtext = "This is the Rose Telecom Tech net paging solution. The time is";
			string clockatext = "Zulu. Irina is clear";
			string clocktrigtime = "03";
			bool clock24h = true;
			bool testpages = true;
			bool pageout = true;
			string testpagetrigH = "12";
			string testpagetrigM = "20";
			string testpagetrigAP = "PM";
			string testpagetext = "This is a test of the Rose Telecom Tech Net paging solution. The current time is";

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(@"**************************************");
			Console.WriteLine(@"***********++++++************+********");
			Console.WriteLine(@"**********:.    .**********-.=********");
			Console.WriteLine(@"********-       .********-.  =********");
			Console.WriteLine(@"******-.        .******=.    =********");
			Console.WriteLine(@"****=.          .****=.      ......:**");
			Console.WriteLine(@"***:       .*******=               :**");
			Console.WriteLine(@"***:       .*****=.                :**");
			Console.WriteLine(@"***:       .***+=-----:      :-----=**");
			Console.WriteLine(@"***:       .**********=      =********");
			Console.WriteLine(@"***:       .**********=      =********");
			Console.WriteLine(@"***:       .**********=      =********");
			Console.WriteLine(@"***:       .**********=.          .:**");
			Console.WriteLine(@"***:       .***********-         .+***");
			Console.WriteLine(@"***:       .************=.      :+****");
			Console.WriteLine(@"***-::::::::**************+-...=******");
			Console.WriteLine(@"**************************************");
			Console.WriteLine(@"**************************************");
			Console.ResetColor();
			Console.WriteLine("");
			Console.WriteLine("Rose Telecom");
			Console.WriteLine("V1.5");

			Console.Write("Loading Config Options... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(20);
				}
			}
			Console.WriteLine("Done.");

			//Read Config file here
			string CPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Config.notyml";

			DirectoryInfo dd = new DirectoryInfo(CPATH);
			string[] clines = null;

			//Read Config File and set options
			try
			{
				clines = File.ReadAllLines(CPATH);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
				Environment.Exit(50);
			}

			Console.Write("Validating Config Options... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(10);
				}
			}

			string testpagetrigtime = "12:20 PM";
			string testpagetrigclear = "12:45 PM";
			int clocktrigtimeclear = 35;
			try
			{
				int tmpcnt = 0;
				foreach (string S in clines)
				{
					string str = S.Substring(0, 4);
					string option = S.Substring(4, S.Length - 4);
					tmpcnt++;
#if DEBUG
					Console.WriteLine("Config line " + tmpcnt.ToString() + @" . Cfg input >> " + S);
#endif
					switch (str)
					{
						case "CLK:":
							if (option.ToLower() == "true")
							{
								clock = true;
							}
							else if (option.ToLower() == "false")
							{
								clock = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "CBT:":
							clockbtext = option;
							break;

						case "CAT:":
							clockatext = option;
							break;

						case "CTT:":
							clocktrigtime = option;
							break;

						case "C24:":
							if (option.ToLower() == "true")
							{
								clock24h = true;
							}
							else if (option.ToLower() == "false")
							{
								clock24h = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "TPE:":
							if (option.ToLower() == "true")
							{
								testpages = true;
							}
							else if (option.ToLower() == "false")
							{
								testpages = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "POE:":
							if (option.ToLower() == "true")
							{
								pageout = true;
							}
							else if (option.ToLower() == "false")
							{
								pageout = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "TTH:":
							testpagetrigH = option;
							break;

						case "TTM:":
							testpagetrigM = option;
							break;

						case "TTA:":
							testpagetrigAP = option;
							break;

						case "TTT:":
							testpagetext = option;
							break;
					}
				}

				//Set dynamic options
				testpagetrigtime = testpagetrigH + ":" + testpagetrigM + " " + testpagetrigAP;
				testpagetrigclear = testpagetrigH + (int.Parse(testpagetrigM) + 15) + testpagetrigAP;
				clocktrigtimeclear = int.Parse(clocktrigtime) + 15;
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Config file invalid");
				Console.WriteLine();
				Console.ResetColor();
				Console.WriteLine(ex.Message);
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
				Environment.Exit(55);
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Valid.");
			Console.ResetColor();

			if (pageout == true)
			{
				Console.Write("Validating Internet Access... ");
				using (var progress = new ProgressBar())
				{
					for (int ib = 0; ib <= 100; ib++)
					{
						progress.Report((double)ib / 100);
						Thread.Sleep(10);
					}
				}
				var ping = new System.Net.NetworkInformation.Ping();

				var result = ping.Send("www.rosesam.pw");

				if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
				{
					Console.WriteLine("Online");
				}
				else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("NO INTERNET ACCESS"); Console.ResetColor(); }
			}

#if DEBUG
			Console.Beep();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
#endif
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
			if (clock == true)
			{
				Console.WriteLine(@"                                                     CLOCK ENABLED");
			}
			if (testpages == true)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(@"                                                  TEST PAGES ENABLED");
				Console.ResetColor();
			}
			if (pageout == true)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(@"                                                   PAGE OUT ENABLED");
				Console.ResetColor();
			}

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
			if (clock24h == true)
			{
				TN = DateTime.Now.ToString("HH mm");
			}
			else
			{
				TN = DateTime.Now.ToString("hh mm");
			}
			string Date = DateTime.Now.ToString("dddd MMMM d");
			string DTNS;
			if (clock24h == true)
			{
				DTNS = DateTime.Now.ToString("HH:mm:ss");
			}
			else
			{
				DTNS = DateTime.Now.ToString("hh:mm:ss tt");
			}
			string DTNMO = DateTime.Now.ToString("mm");

			Console.Write(DTNS);

			if (DTN == testpagetrigtime)
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
									Sin(FT, 1);
									FT = 0;
									Sin(ST, 3);
									ST = 0;
									Thread.Sleep(700);
									iiiiiiii = 0;
								}
							}
							player.PlaySync();
							synthesizer.Speak(testpagetext + DateTime.Now.ToString("HH:mm"));
							Console.Clear();
						}
					}
					goto A;
				}
			}
			else if (DTN == testpagetrigclear && ran == true && testpages == true)
			{
				ran = false;
				goto T;
			}
			else if (DTNMO == clocktrigtime && clock == true && ranho == false)
			{
				ranho = true;

				using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\CHIME.wav"))
				{
					using (var synthesizer = new SpeechSynthesizer())
					{
						synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
						player.PlaySync();
						synthesizer.Speak(clockbtext + Date + " , " + TN + clockatext);
					}
				}
				goto A;
			}
			else if (DTNMO == clocktrigtimeclear.ToString() && ranho == true)
			{
				ranho = false;
				goto T;
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
				Console.WriteLine("");
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Page Out");
				log.Info("PO: Page Out");
				Console.WriteLine("Priority: " + pri);
				log.Info("PO: Priority: " + pri);
				if (techs != null)
				{
					foreach (string S in techs)
					{
						Console.WriteLine("Tech: " + S);
						log.Info("PO: Tech: " + S);
					}
				}
				else
				{
					return false;
				}

				Console.WriteLine("Message: " + message);
				log.Info("PO: Message: " + message);
				Console.ResetColor();
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

						case 5:
							alert = "\\Alert6.wav";
							break;

						case 6:
							alert = "\\Alert7.wav";
							break;

						case 7:
							alert = "\\Alert8.wav";
							break;

						case 0:
						default:
							alert = "\\Alert1.wav";
							break;
					}
					using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + alert))
					{
						if (techs[0] != "AllCal")
						{
							foreach (string T in techs)
							{
								string[] lines = null;
								double FT;
								double ST;
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
								}
								FT = double.Parse(lines[0]);
								ST = double.Parse(lines[1]);
								synthesizer.SetOutputToDefaultAudioDevice();
								Sin(FT, 1);
								Sin(ST, 3);
								Thread.Sleep(1000);
							}
						}
						else
						{
							synthesizer.SetOutputToDefaultAudioDevice();
							Sin(1000, 8);
							Thread.Sleep(1000);
						}

						player.PlaySync();
						synthesizer.Speak(message);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
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
