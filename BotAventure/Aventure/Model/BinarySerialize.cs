using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Aventure.Model
{
    public class BinarySerialize : ISerializePlayer
    {
        public void Serialize(List<Player> p)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("save.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();
        }

        public List<Player> UnSerialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("save.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            if(stream != null || stream.Length != 0)
            {
                stream.Position = 0;
                
                return (List<Player>)formatter.Deserialize(stream);
            }
            return null;
        }
    }
}
