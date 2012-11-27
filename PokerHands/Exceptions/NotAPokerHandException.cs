
using System;
using System.Runtime.Serialization;

namespace PokerHands.Exceptions
{
    [Serializable]
    public class NotAPokerHandException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NotAPokerHandException()
        {
        }

        public NotAPokerHandException(string message)
            : base(message)
        {
        }

        public NotAPokerHandException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NotAPokerHandException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
