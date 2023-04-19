using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal interface IGameObject
    {
        void Draw(GameTime gameTime);
        
        void Update(GameTime gameTime);

        bool IsAlive { get; }
    }
}
