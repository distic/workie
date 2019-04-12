using System;
using System.Runtime.Serialization;

namespace Workie.DeployHelper.Exceptions
{
    internal class DeployWorkieWebAdminException : TypeLoadException
    {
        public DeployWorkieWebAdminException()
        {

        }
        //
        // Summary:
        //     Initializes a new instance of the System.DllNotFoundException class with a specified
        //     error message.
        //
        // Parameters:
        //   message:
        //     The error message that explains the reason for the exception.
        public DeployWorkieWebAdminException(string message)
        {

        }
        //
        // Summary:
        //     Initializes a new instance of the System.DllNotFoundException class with a specified
        //     error message and a reference to the inner exception that is the cause of this
        //     exception.
        //
        // Parameters:
        //   message:
        //     The error message that explains the reason for the exception.
        //
        //   inner:
        //     The exception that is the cause of the current exception. If the inner parameter
        //     is not null, the current exception is raised in a catch block that handles the
        //     inner exception.
        public DeployWorkieWebAdminException(string message, Exception inner)
        {

        }
        //
        // Summary:
        //     Initializes a new instance of the System.DllNotFoundException class with serialized
        //     data.
        //
        // Parameters:
        //   info:
        //     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        //     object data about the exception being thrown.
        //
        //   context:
        //     The System.Runtime.Serialization.StreamingContext that contains contextual information
        //     about the source or destination.
        protected DeployWorkieWebAdminException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
