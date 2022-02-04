using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace System.Text
{
    internal static class SR
    {
        public static string Arg_MustBeRune => "Arg_MustBeRune";
    }
    internal struct ExceptionArgument
    {
        public string Text { get; }
        public static readonly ExceptionArgument ch = new ExceptionArgument("ch");
        public static readonly ExceptionArgument value = new ExceptionArgument("value");
        public static readonly ExceptionArgument index = new ExceptionArgument("index");
        public static readonly ExceptionArgument input = new ExceptionArgument("input");
        public static readonly ExceptionArgument culture = new ExceptionArgument("culture");

        public ExceptionArgument(string text)
        {
            Text = text;
        }
    }
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException();
        }

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(ExceptionArgument paramName)
        {
            throw new ArgumentOutOfRangeException(paramName.Text);
        }

        [DoesNotReturn]
        internal static void ThrowArgumentOutOfRange_IndexException()
        {
            throw new ArgumentOutOfRangeException("index");
        }


        [DoesNotReturn]
        internal static void ThrowArgumentException_DestinationTooShort()
        {
            throw new ArgumentException("DestinationTooShort", "destination");
        }

        [DoesNotReturn]
        internal static void ThrowArgumentException_CannotExtractScalar(ExceptionArgument paramName)
        {
            throw new ArgumentException("ArgumentException", paramName.Text);
        }

        [DoesNotReturn]
        internal static void ThrowArgumentNullException(ExceptionArgument paramName)
        {
            throw new ArgumentNullException(paramName.Text);
        }

    }
}
