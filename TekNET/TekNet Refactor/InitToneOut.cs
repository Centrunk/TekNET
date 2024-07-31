/*
*   Copyright (C) 2024 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using NLog;
using System.Reflection;
using System.Speech.Synthesis;

namespace TekNet_Refactor
{
	internal class InitToneOut
	{
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

				if (0 == 0)
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
								ToneSend.Sin(FT, 1);
								ToneSend.Sin(ST, 3);
								Thread.Sleep(1000);
							}
						}
						else
						{
							synthesizer.SetOutputToDefaultAudioDevice();
							ToneSend.Sin(1000, 8);
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
	}
}
