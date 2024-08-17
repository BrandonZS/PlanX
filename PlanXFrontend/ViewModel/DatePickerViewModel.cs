using System.ComponentModel;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PlanXFrontend;

public class DatePickerViewModel : INotifyPropertyChanged
{

    private DateTime minDate;
    private DateTime maxDate;
    private DateTime selectedDate;
    public DateTime MinDate{
        get{
            return MinDate;
            }

        set{
            if(minDate != value){
                minDate = value;
                OnPropertyChanged(nameof(MinDate));
            }
        }
    }
    public DateTime MaxDate{
        get{
            return maxDate;
            }

        set{
            if(maxDate != value){
                maxDate = value;
                OnPropertyChanged(nameof(MaxDate));
            }
        }
    }
    public DateTime SelectedDate{
        get{
            return selectedDate;
            }

        set{
            if(selectedDate != value){
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
    }

    public DatePickerViewModel(){
        minDate = new DateTime(2024,1,1);
        maxDate = new DateTime(2024,12,31);
        selectedDate = new DateTime(2023,5,17);
    }
    public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


}
