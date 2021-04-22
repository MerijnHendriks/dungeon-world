/* Window.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

namespace Automata
{
    public class Window : System.Windows.Window
    {
        public Window()
        {
            OnLoad();
        }

        /// <summary>
        /// When the window is loading
        /// </summary>
        public virtual void OnLoad()
        {
        }

        /// <summary>
        /// When the window appears
        /// </summary>
        public virtual void OnShow()
        {
        }

        /// <summary>
        /// When the window dissapears
        /// </summary>
        public virtual void OnHide()
        {
        }

        /// <summary>
        /// When the window closes
        /// </summary>
        public virtual void OnClose()
        {
        }
    }
}
