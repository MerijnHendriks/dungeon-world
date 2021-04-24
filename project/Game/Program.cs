using System;
using Automata.Controllers;
using Automata.Utils;
using Game.Models;

namespace Game
{
    public class Program 
    {
        [STAThread()]
        public static void Main(string[] args)
        {
            // register windows
            WindowController.AddWindow("testwindow", new TestWindow());

            // start application
            _ = new App("testwindow");
        }
    }
}
