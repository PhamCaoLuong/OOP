using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumperJumper
{
    public interface ISpriteFactory
    {
        IAnimatedSprite build(SpriteFactory.sprites sprite);
    }
}
