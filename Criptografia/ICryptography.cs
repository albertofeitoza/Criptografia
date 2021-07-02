﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apis.Criptografia
{
    public interface ICryptography
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
