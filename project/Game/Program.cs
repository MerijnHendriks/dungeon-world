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
            int windowId = (int)EWindow.TestWindow;
            WindowController.AddWindow(windowId, new TestWindow());

            // start application
            _ = new App(windowId);
        }
    }
}
