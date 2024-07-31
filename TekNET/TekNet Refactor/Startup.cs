/*
*   Copyright (C) 2024 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TekNet_Refactor
{
	internal class Startup
	{
		internal void opset()
		{
			Options opt = new Options();
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

			Console.Write("Loading Config File... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(10);
				}
			}

			//Read Config file here
			string CPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Config.notyml";

			DirectoryInfo dd = new DirectoryInfo(CPATH);
			string[] clines = null;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Done.");
			Console.ResetColor();

			Console.Write("Loading Site Database File... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(5);
				}
			}

			string sPATH = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\sitedb.notyml";

			DirectoryInfo sd = new DirectoryInfo(sPATH);
			string[] slines = null;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Done.");
			Console.ResetColor();

			//Read Config File and set options
			try
			{
				clines = File.ReadAllLines(CPATH);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("ERR 50: Config File Read Fail");
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
				Environment.Exit(50);
			}

			Console.Write("Validating Site Database... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(8);
				}
			}
			try
			{
				slines = File.ReadAllLines(sPATH);
				foreach (string S in slines)
				{
					if (S[0] != '#')
					{
						string[] site = S.Split(',');
						opt.sites.Add(site[0], site[1]);
					}
#if DEBUG
					Console.WriteLine("Site input >> " + S);
#endif
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Site Database invalid");
				Console.ResetColor();
				Console.WriteLine("ERR 51: Site DB Inv");
				Console.WriteLine();
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
				Environment.Exit(51);
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Valid.");
			Console.ResetColor();

			Console.Write("Validating Config Options... ");
			using (var progress = new ProgressBar())
			{
				for (int ib = 0; ib <= 100; ib++)
				{
					progress.Report((double)ib / 100);
					Thread.Sleep(5);
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
								opt.clock = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.clock = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "CBT:":
							opt.clockbtext = option;
							break;

						case "CAT:":
							opt.clockatext = option;
							break;

						case "CTT:":
							opt.clocktrigtime = option;
							break;

						case "C24:":
							if (option.ToLower() == "true")
							{
								opt.clock24h = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.clock24h = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "TPE:":
							if (option.ToLower() == "true")
							{
								opt.testpages = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.testpages = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "POE:":
							if (option.ToLower() == "true")
							{
								opt.pageout = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.pageout = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "TTH:":
							opt.testpagetrigH = option;
							break;

						case "TTM:":
							opt.testpagetrigM = option;
							break;

						case "TTA:":
							opt.testpagetrigAP = option;
							break;

						case "TTT:":
							opt.testpagetext = option;
							break;

						case "IMS:":
							if (option.ToLower() == "true")
							{
								opt.imapssl = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.imapssl = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "EIM:":
							if (option.ToLower() == "true")
							{
								opt.imapenab = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.imapenab = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;

						case "IMA:":
							opt.imapaddress = option;
							break;

						case "IMU:":
							opt.imapuser = option;
							break;

						case "IMP:":
							opt.imappass = option;
							break;

						case "UEM:":
							if (option.ToLower() == "true")
							{
								opt.UEMadv = true;
							}
							else if (option.ToLower() == "false")
							{
								opt.UEMadv = false;
							}
							else
							{
								throw new Exception("Invalid Config Option");
							}
							break;
					}
				}

				//Set dynamic options
				testpagetrigtime = opt.testpagetrigH + ":" + opt.testpagetrigM + " " + opt.testpagetrigAP;
				testpagetrigclear = opt.testpagetrigH + (int.Parse(opt.testpagetrigM) + 15) + opt.testpagetrigAP;
				clocktrigtimeclear = int.Parse(opt.clocktrigtime) + 15;
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Config file invalid");
				Console.WriteLine();
				Console.ResetColor();
				Console.WriteLine(ex.Message);
				Console.WriteLine("ERR 55: Config File Inv");
				Console.WriteLine();
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
				Environment.Exit(55);
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Valid.");
			Console.ResetColor();

			if (opt.pageout == true)
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
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Online");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("NO INTERNET ACCESS");
					Console.ResetColor();
					if (opt.pageout == true)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("No internet access detected while Pageouts are enabled. Application Stopped");
						Console.ResetColor();
						Console.WriteLine("ERR 69 :Ping test of  www.rosesam.pw  failed");
						Console.WriteLine("Press any key to exit");
						Console.ReadKey();
						Environment.Exit(69);
					}
				}
			}

#if DEBUG
			Console.Beep();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
#endif
		}
	}
}
