using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic_encrypter
{
    internal class ChiefEncrypter
    {
        private IStrategy Strategy;

        public void SetStrategy(IStrategy NewStrategy)
        {
            Strategy = NewStrategy;
        }

        public void InitializeEncrypting(string Path, string FilePath)
        {
            Strategy.CreatePicture(Path, FilePath);
        }
    }
}
