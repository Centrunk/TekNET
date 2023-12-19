/*
*   Copyright (C) 2022 by N5UWU
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

namespace TekNET
{
	internal class Program
	{
		internal bool STRIG = false;

		private static void Main(string[] args)
		{
			Program P = new Program();
			Logger log = LogManager.GetCurrentClassLogger();
			bool ran = false;
			bool ranso = false;

			Console.Clear();
		A:
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
			string DTN = DateTime.Now.ToString("hh:mm tt");
			string DTNS = DateTime.Now.ToString("hh:mm:ss tt");
			Console.Write(DTNS);

			if (DTN == "A:A1 PM")
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
							synthesizer.Speak("This is a daily test of the Centex Trunked Radio System Quick Call Two System, Test   1     2      3      4,  5,    6    7    8   9, END , This concludes this test of the Centex Trunked Radio System Quick Call Two System, The Current time is " + DateTime.Now.ToString("hh:mm tt") + "Central Standard Time");
							Console.Clear();
						}
					}
					goto A;
				}
			}
			else if (DTN == "11:00 PM")
			{
				using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\SO2.wav"))
				{
					player.PlaySync();
					Console.Clear();
				}
				goto A;
			}
			else if (DTN == "12:20 PM")
			{
				ran = false;
				goto T;
			}
			else
			{
				Thread.Sleep(1000);

				ClearCurrentConsoleLine();
				goto T;
			}
			Console.WriteLine("Done");
		}

		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}

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
