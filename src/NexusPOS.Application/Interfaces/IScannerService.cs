using System;

namespace NexusPOS.Application.Interfaces
{
    public interface IScannerService
    {
        event EventHandler<string> BarcodeScanned;
        void Start();
        void Stop();
    }
}
