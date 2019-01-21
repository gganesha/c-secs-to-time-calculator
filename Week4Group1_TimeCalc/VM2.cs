using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week4Group1_TimeCalc
{
    class VM2 : INotifyPropertyChanged
    {
        private string inputText = "";
        public string InputText
        {
            get { return inputText; }
            set { inputText = value; Calc(inputText); NotifyChanged(); }
        }
        private string displayText = "";
        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; NotifyChanged(); }
        }

        public void Calc(string textboxInput)
        {
            int numberofSecondsEntered = textboxInput == "" ?  0 : int.Parse(textboxInput);

            string msg = string.Empty;
            int seconds_minutes = 60;
            int seconds_hours = 3600;
            int seconds_days = 86400;
            
            if (numberofSecondsEntered == 0)
            {
                msg = "";
                DisplayText = msg;
            }
            else if (numberofSecondsEntered < seconds_minutes)
            {
                msg = $"{inputText} seconds";
                DisplayText = msg;
            }
            else if (numberofSecondsEntered < seconds_hours)
            {
                int seconds = numberofSecondsEntered % seconds_minutes;
                int minutes = numberofSecondsEntered / seconds_minutes;
                msg = $"{minutes} minutes, {seconds} seconds";
                DisplayText = msg;
            }
            else if (numberofSecondsEntered < seconds_days)
            {
                int seconds = (numberofSecondsEntered % seconds_hours) % seconds_minutes;
                int minutes = (numberofSecondsEntered % seconds_hours) / seconds_minutes;
                int hours = numberofSecondsEntered / seconds_hours;
                msg = $"{hours} hours, {minutes} minutes, {seconds} seconds";
                DisplayText = msg;
            }
            else
            {
                int seconds = ((numberofSecondsEntered % seconds_days) % seconds_hours) % seconds_minutes;
                int minutes = ((numberofSecondsEntered % seconds_days) % seconds_hours) / seconds_minutes;
                int hours = (numberofSecondsEntered % seconds_days) / seconds_hours;
                int days = numberofSecondsEntered / seconds_days;
                msg = $"{days} days, {hours} hours, {minutes} minutes, {seconds} seconds";
                DisplayText = msg;
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
