/*
*   Copyright (C) 2022 by N5UWU
*   This program is distributed WITHOUT WARRANTY.
*/

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;

namespace TekNET_V2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
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
					MyCOMPort.Write("A");                    // Write an ascii "a"
				}
				catch (Exception ex) { Console.WriteLine(ex.Message); }
			}
		}

		/// <summary>
		/// Open and Close the relay port
		/// OOC = true is open
		/// OOC = false is close
		/// </summary>
		/// <param name="OOC"></param>
		internal static void RELAYport(bool OOC)
		{
			string jsonString;
			jsonString = File.ReadAllText(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..")) + "\\Conf.TNCONF");
			CONF? CONFO = JsonSerializer.Deserialize<CONF>(jsonString);
			SerialPort MyCOMPort = new SerialPort();
			MyCOMPort.PortName = CONFO.COMT;          // Name of the COM port
			MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
			MyCOMPort.Parity = Parity.None;        // Parity bits = none
			MyCOMPort.DataBits = 8;                  // No of Data bits = 8
			MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1
			try
			{
				if (OOC == true)
				{
					MyCOMPort.Open();
				}
				else
				{
					MyCOMPort.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
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
					MyCOMPort.Write("a");                    // Write an ascii "a"
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
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

	public class CONF
	{
		public Dictionary<int, string>? Techs { get; set; }
		public string? COMP { get; set; }
		public string? COMT { get; set; }
		public string? ADP { get; set; }
	}
}