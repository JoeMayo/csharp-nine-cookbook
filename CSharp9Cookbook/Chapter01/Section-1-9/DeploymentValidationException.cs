using System;

namespace Section_1_9
{
    [Serializable]
    public class DeploymentValidationException : Exception
    {
        public DeploymentValidationException() : 
            this("Validation Failed!", null, ValidationFailureReason.Unknown)
        {
        }

        public DeploymentValidationException(
            string message) : 
            this(message, null, ValidationFailureReason.Unknown)
        {
        }

        public DeploymentValidationException(
            string message, Exception innerException) : 
            this(message, innerException, ValidationFailureReason.Unknown)
        {
        }
        
        public DeploymentValidationException(
            string message, ValidationFailureReason reason) : 
            this(message, null, reason)
        {
        }

        public DeploymentValidationException(
            string message, Exception innerException, ValidationFailureReason reason) :
            base(message, innerException)
        {
            Reason = reason;
        }

        public ValidationFailureReason Reason { get; set; }

        public override string ToString()
        {
            return 
                base.ToString() +
                $" - Reason: {Reason} ";
        }
    }
}
