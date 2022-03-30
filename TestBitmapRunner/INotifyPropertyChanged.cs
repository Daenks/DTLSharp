using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestBitmapRunner
{
    public class NotifyInt : INotifyPropertyChanged
    {
        private int _value;
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _name;

        public NotifyInt()
        {
            _name = string.Empty;
        }
        public NotifyInt(int value)
        {
            _name = string.Empty;
            _value = value;
        }

        public NotifyInt(int value, string name)
        {
            _name = name;
            _value = value;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(_name);
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public class NotifyDouble : INotifyPropertyChanged
    {
        private double _value;
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _name;

        public NotifyDouble()
        {
            _name = string.Empty;
        }
        public NotifyDouble(double value)
        {
            _name = string.Empty;
            _value = value;
        }

        public NotifyDouble(double value, string name)
        {
            _name = name;
            _value = value;
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(_name);
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}