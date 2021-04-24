using System;
using Automata.Controllers;
using Automata.Utils;
using Game.Models;

namespace Game
{
    public class Program 
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">Launch parameters</param>
        [STAThread()]
        public static void Main(string[] args)
        {
            // register window
            int windowId = (int)EWindow.TestWindow;
            WindowController.AddWindow(windowId, new TestWindow());

            // start application
            _ = new App(windowId);
        }
    }
}
