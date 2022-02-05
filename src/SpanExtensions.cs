// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    public static partial class SpanExtensions
    {
        /// <summary>
        /// Returns an enumeration of <see cref="Rune"/> from the provided span.
        /// </summary>
        /// <remarks>
        /// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
        /// </remarks>
        public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<char> span)
        {
            return new SpanRuneEnumerator(span);
        }

        /// <summary>
        /// Returns an enumeration of <see cref="Rune"/> from the provided span.
        /// </summary>
        /// <remarks>
        /// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
        /// </remarks>
        public static SpanRuneEnumerator EnumerateRunes(this Span<char> span)
        {
            return new SpanRuneEnumerator(span);
        }

    }
}
