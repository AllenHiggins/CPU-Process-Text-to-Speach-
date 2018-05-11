using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace textToSpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounter performanceCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter memoryCounter = new PerformanceCounter("Memory","Available MBytes");
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.Speak("Welcome to the proformance App");

            while (true)
            {
                int cpu = (int) performanceCounter.NextValue();
                int mem =  (int) memoryCounter.NextValue();

                Console.WriteLine("Current CPU Process: " + cpu + "%");
                Console.WriteLine("Current Memory Available: " + mem + "MB");
                Console.WriteLine();

                string str = string.Format("Current Memory Available: {0} GB", mem / 1024);

                speech.Speak("Current CPU Process: " + cpu + "%");
                speech.Speak(str);

                Thread.Sleep(500);
                
            }
        
        }
    }
}
