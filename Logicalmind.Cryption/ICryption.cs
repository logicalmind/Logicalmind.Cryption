using System;
using System.Collections.Generic;
using System.Text;

namespace Logicalmind.Cryption
{
    public interface ICryption
    {
        string Encrypt(string str);
        string Decrypt(string str);
    }
}
