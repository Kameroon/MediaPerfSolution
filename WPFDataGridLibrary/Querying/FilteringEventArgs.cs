using System;

namespace WPFDataGridLibrary.Querying
{
    public class FilteringEventArgs : EventArgs
    {
        public Exception Error { get; private set; }

        public FilteringEventArgs(Exception ex)
        {
            Error = ex;
        }
    }
}
