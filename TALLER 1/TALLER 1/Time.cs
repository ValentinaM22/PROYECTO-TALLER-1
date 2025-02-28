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
            return ((_hour * 3600L + _minute * 60 + _second) * 1000) + _millisecond;
        }

        public long ToSeconds()
        {
            return (_hour * 3600L) + (_minute * 60) + _second;
        }

        public long ToMinutes()
        {
            return (_hour * 60L) + _minute;
        }

        public Time Add(Time other)
        {
            long totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
            totalMilliseconds %= 86400000; // Asegurar que no exceda 24 horas

            int newHour = (int)(totalMilliseconds / (3600 * 1000));
            totalMilliseconds %= (3600 * 1000);
            int newMinute = (int)(totalMilliseconds / (60 * 1000));
            totalMilliseconds %= (60 * 1000);
            int newSecond = (int)(totalMilliseconds / 1000);
            int newMillisecond = (int)(totalMilliseconds % 1000);

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        public bool IsOtherDay(Time other)
        {
            return (this.ToMilliseconds() + other.ToMilliseconds()) >= 86400000;
        }
    }
}

