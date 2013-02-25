using SuiteValue.UI.MVVM;

namespace BestManApp.Model
{
    public class Gift : NotifyObject
    {
        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }
         
    }
}