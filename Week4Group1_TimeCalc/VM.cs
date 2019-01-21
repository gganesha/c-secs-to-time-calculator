using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


/// Time Calculator
/// User enters a number of seconds and works as follows:
/// 60 seconds in a minute --> seconds greater than 60, program should diplay number of minutes in that many seconds
/// 3600 seconds in an hour --> seconds greater than 3600, program should display number of hours in that many seconds
/// 86,400 seconds in a day --> seconds greater than 86,400, program should display number of days in that many seconds
namespace Week4Group1_TimeCalc
{
    class VM : INotifyPropertyChanged
    {
        private int inputText = 0;
        public int InputText
        {
            get { return inputText; }
            set { inputText = value; Calc(); NotifyChanged(); }
        }
        private string displayText = "";
        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; NotifyChanged(); }
        }
        
        public void Calc()
        {
            string msg = string.Empty;
            int seconds_minutes = 60;
            int seconds_hours = 3600;
            int seconds_days = 86400;

            if (InputText < seconds_minutes)
            {
                msg = $"{inputText} seconds";
                DisplayText = msg;
            }
            else if (InputText <seconds_hours)
            {
                int seconds = InputText % seconds_minutes;
                int minutes = InputText / seconds_minutes;
                msg = $"{minutes} minutes, {seconds} seconds";
                DisplayText = msg;
            }
            else if (InputText <seconds_days)
            {
                int seconds = (InputText % seconds_hours) % seconds_minutes;
                int minutes = (InputText % seconds_hours) / seconds_minutes;
                int hours = InputText / seconds_hours;
                msg = $"{hours} hours, {minutes} minutes, {seconds} seconds";
                DisplayText = msg;
            }
            else
            {
                int seconds = ((InputText % seconds_days) % seconds_hours)%seconds_minutes;
                int minutes = ((InputText % seconds_days) % seconds_hours)/seconds_minutes;
                int hours = (InputText % seconds_days) / seconds_hours;
                int days = InputText / seconds_days;
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
