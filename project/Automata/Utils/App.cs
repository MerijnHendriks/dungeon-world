/* App.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

using System.Windows;
using Automata.Controllers;

namespace Automata.Utils
{
    public class App : Application
    {
        public App(int windowId)
        {
            WindowController.ShowWindow(windowId);
            Run();
        }
    }
}
