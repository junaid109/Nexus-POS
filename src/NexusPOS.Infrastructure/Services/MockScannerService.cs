using NexusPOS.Application.Interfaces;
using System;
using System.Timers;

namespace NexusPOS.Infrastructure.Services
{
    public class MockScannerService : IScannerService
    {
        private readonly System.Timers.Timer _timer;
        private readonly Random _random;

        public event EventHandler<string>? BarcodeScanned;

        public MockScannerService()
        {
            _random = new Random();
            _timer = new System.Timers.Timer(5000); // 5 seconds
            _timer.Elapsed += (s, e) =>
            {
                var barcode = "5000123" + _random.Next(1000, 9999);
                BarcodeScanned?.Invoke(this, barcode);
            };
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();
    }
}
