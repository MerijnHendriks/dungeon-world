/* App.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

using System.Windows;

namespace Automata
{
    public class App : Application
    {
        public App(string windowId)
        {
            WindowManager.ShowWindow(windowId);
            Run();
        }
    }
}
