using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic_encrypter
{
    internal class ChiefEncrypter<T>
    {
        private IStrategy<T> Strategy;

        public void InitializeEncrypting(string Path, T Object)
        {
            Strategy.CreatePicture(Path, Object);
        }
    }
}
