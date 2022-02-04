using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text
{
    public static class StringExtensions
    {
        public static StringRuneEnumerator EnumerateRunes(this string value) => new StringRuneEnumerator(value);
    }
}
