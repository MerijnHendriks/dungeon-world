using System.Windows.Controls;

namespace Automata
{
    public class View : UserControl
    {
        public Grid Root { get; private set; }

        public View()
        {
            Root = new Grid();
            OnLoad();
        }

        /// <summary>
        /// When the view is loading
        /// </summary>
        public virtual void OnLoad()
        {
        }

        /// <summary>
        /// When the view appears
        /// </summary>
        public virtual void OnShow()
        {
        }

        /// <summary>
        /// When the view dissapears
        /// </summary>
        public virtual void OnHide()
        {
        }
    }
}
