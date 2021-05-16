using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ToastNotifications.Services
{
    public class ToastService : IDisposable
    {
        public event Action<string, ToastLevel> OnShow;
        public event Action OnHide;
        private Timer CountDown;

        public void Dispose()
        {
            CountDown?.Dispose();
        }

        public void ShowToast(string message, ToastLevel level)
        {
            OnShow?.Invoke(message, level);
            StartCountDown();
        }

        private void StartCountDown()
        {
            SetCountDown();

            if (CountDown.Enabled)
            {
                CountDown.Stop();
                CountDown.Start();
            }
            else
            {
                CountDown.Start();
            }    
        }

        private void SetCountDown()
        {
            if (CountDown == null)
            {
                CountDown = new Timer(5000);
                CountDown.Elapsed += HideToast;
                CountDown.AutoReset = false;
            }
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }
    }
}
