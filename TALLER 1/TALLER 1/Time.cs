using System;

namespace TALLER_1
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour) : this(hour, 0, 0, 0) { }

        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }

        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }

        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidateHour(hour);
            _minute = ValidateMinute(minute);
            _second = ValidateSecond(second);
            _millisecond = ValidateMillisecond(millisecond);
        }

        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }

        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException($"The hour: {hour}, is not valid.");
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
                throw new ArgumentException($"The minute: {minute}, is not valid.");
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
                throw new ArgumentException($"The second: {second}, is not valid.");
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
                throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
            return millisecond;
        }

        public override string ToString()
        {
            string period = _hour < 12 ? "AM" : "PM";
            int displayHour = _hour % 12;
            if (displayHour == 0) displayHour = 12;

            return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {period}";
        }

        public long ToMilliseconds()
        {
            return ((_hour * 3600 + _minute * 60 + _second) * 1000L) + _millisecond;
        }

        public long ToSeconds()
        {
            return (_hour * 3600) + (_minute * 60) + _second;
        }

        public long ToMinutes()
        {
            return (_hour * 60) + _minute;
        }

        public Time Add(Time other)
        {
            int totalMilliseconds = this._millisecond + other._millisecond;
            int carrySeconds = totalMilliseconds / 1000;
            int newMilliseconds = totalMilliseconds % 1000;

            int totalSeconds = this._second + other._second + carrySeconds;
            int carryMinutes = totalSeconds / 60;
            int newSeconds = totalSeconds % 60;

            int totalMinutes = this._minute + other._minute + carryMinutes;
            int carryHours = totalMinutes / 60;
            int newMinutes = totalMinutes % 60;

            int newHours = (this._hour + other._hour + carryHours) % 24;

            return new Time(newHours, newMinutes, newSeconds, newMilliseconds);
        }

        public bool IsOtherDay(Time other)
        {
            return (this.ToMilliseconds() + other.ToMilliseconds()) >= (24 * 3600 * 1000);
        }
    }
}