using System;
using System.Collections.Generic;
using System.Text;

namespace Aventure.Model
{
    interface ISerializePlayer
    {
        public void Serialize(List<Player> p);

        public List<Player> UnSerialize();
    }
}
