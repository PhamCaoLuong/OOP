using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace JumperJumper
{
    public interface ICollectablePhysicsState
    {
        void Update(ICollectable item, GameTime gameTime);
    }
}
