using System;
using System.IO;

namespace SOLID
{
    public interface IErrorHandler
    {
        void HandleError(Exception exception);
    }

    public class FileErrorHandler : IErrorHandler
    {
        // this functionality has been moved to here and it is no longer in the customer
        public void HandleError(Exception exception)
        {
            File.WriteAllText(@"C:\Development\SOLID\Error.txt", exception.ToString());
        }
    }

    public class EventViewerHandler : IErrorHandler
    {
        public void HandleError(Exception exception)
        {
            // implement what is needed
        }
    }
}