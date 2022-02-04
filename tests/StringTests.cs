// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Tests
{
    public partial class StringTests
    {
        [Theory]
        [InlineData(new char[0], new int[0])] // empty
        [InlineData(new char[] { 'x', 'y', 'z' }, new int[] { 'x', 'y', 'z' })]
        [InlineData(new char[] { 'x', '\uD86D', '\uDF54', 'y' }, new int[] { 'x', 0x2B754, 'y' })] // valid surrogate pair
        [InlineData(new char[] { 'x', '\uD86D', 'y' }, new int[] { 'x', 0xFFFD, 'y' })] // standalone high surrogate
        [InlineData(new char[] { 'x', '\uDF54', 'y' }, new int[] { 'x', 0xFFFD, 'y' })] // standalone low surrogate
        [InlineData(new char[] { 'x', '\uD86D' }, new int[] { 'x', 0xFFFD })] // standalone high surrogate at end of string
        [InlineData(new char[] { 'x', '\uDF54' }, new int[] { 'x', 0xFFFD })] // standalone low surrogate at end of string
        [InlineData(new char[] { 'x', '\uD86D', '\uD86D', 'y' }, new int[] { 'x', 0xFFFD, 0xFFFD, 'y' })] // two high surrogates should be two replacement chars
        [InlineData(new char[] { 'x', '\uFFFD', 'y' }, new int[] { 'x', 0xFFFD, 'y' })] // literal U+FFFD
        public static void EnumerateRunes(char[] chars, int[] expected)
        {
            // Test data is smuggled as char[] instead of straight-up string since the test framework
            // doesn't like invalid UTF-16 literals.

            string asString = new string(chars);

            // First, use a straight-up foreach keyword to ensure pattern matching works as expected

            List<int> enumeratedScalarValues = new List<int>();
            foreach (Rune rune in asString.EnumerateRunes())
            {
                enumeratedScalarValues.Add(rune.Value);
            }
            Assert.Equal(expected, enumeratedScalarValues.ToArray());

            // Then use LINQ to ensure IEnumerator<...> works as expected

            int[] enumeratedValues = new string(chars).EnumerateRunes().Select(r => r.Value).ToArray();
            Assert.Equal(expected, enumeratedValues);
        }

    }
}
