using Automata.Models;
using Automata.Utils;

namespace Game.Models
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            Title = "TestWindow";
            Width = 800;
            Height = 450;
        }

        public override void OnLoad()
        {
            Log.Debug("hello world!");
        }
    }
}
