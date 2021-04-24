/* Map.cs
 * Author: Shaquille Louisa
 * License: NCSA
 */

using Automata.Models;

namespace RPG.Models
{
    public class WorldTile : Tile
    {
        public Image[] Images;  // 1 image? static, multiple? loop with speed
        public int Speed;       // loops speed per tick
    }
}
