using System;
using Automata.Models;
using Automata.Controllers;
using Automata.Utils;

namespace Game
{
    public class Program 
    {
        [STAThread()]
        public static void Main(string[] args)
        {
            Window testWindow = new Window()
            {
                Title = "Test window",
                Width = 800,
                Height = 450
            };

            // register windows
            WindowController.AddWindow("testwindow", testWindow);

            // start application
            _ = new App("testwindow");
        }

        public static void OnTestWindowLoad()
        {
            Log.Debug("hello world!");
        }
    }
}
