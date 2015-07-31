using System;
using System.Runtime.Serialization;
using WampSharp.V2.Core.Contracts;

namespace WampSharp.V2.Client
{
    /// <summary>
    /// An exception that can be thrown if can't authenticate with router.
    /// This sends an ABORT message to the router.
    /// </summary>
#if !PCL
    [Serializable]
#endif
    public class WampAuthenticationException : Exception
    {
        protected const string WampErrorCannotAuthenticate = "wamp.error.cannot_authenticate";
        protected const string DefaultMessage = "sorry, I cannot authenticate (onchallenge handler raised an exception)";

        private readonly AbortDetails mDetails;
        private readonly string mReason;

        /// <summary>
        /// Initializes an new instance of <see cref="WampAuthenticationException"/>
        /// </summary>
        /// <param name="message">The message to send with the details of the ABORT message.</param>
        /// <param name="reason">The reason to send with the ABORT message.</param>
        public WampAuthenticationException(
            string message = DefaultMessage,
            string reason = WampErrorCannotAuthenticate)
            : this(new AbortDetails {Message = message}, reason)
        {
        }

        /// <summary>
        /// Initializes an new instance of <see cref="WampAuthenticationException"/>
        /// </summary>
        /// <param name="details">The details to send with the ABORT message.</param>
        /// <param name="reason">The reason to send with the ABORT message.</param>
        public WampAuthenticationException(AbortDetails details, string reason = WampErrorCannotAuthenticate)
            : base(details.Message)
        {
            mDetails = details;
            mReason = reason;
        }

        /// <summary>
        /// Gets the details to send with the ABORT message.
        /// </summary>
        public AbortDetails Details
        {
            get
            {
                return mDetails;
            }
        }

        /// <summary>
        /// Gets the reason to send with the ABORT message.
        /// </summary>
        public string Reason
        {
            get
            {
                return mReason;
            }
        }
    }
}