using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModel
{
    public class MakeReservationViewModel : ViewModelBase , INotifyDataErrorInfo
    {
		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		private int _roomNumber;
		public int RoomNumber
		{
			get
			{
				return _roomNumber;
			}
			set
			{
				_roomNumber = value;
				OnPropertyChanged(nameof(RoomNumber));
			}
		}

		private int _floorNumber;
		public int FloorNumber
		{
			get
			{
				return _floorNumber;
			}
			set
			{
				_floorNumber = value;
				OnPropertyChanged(nameof(FloorNumber));
			}
		}

		private DateTime _startDate = new DateTime(2021,1,1);
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDate = value;
				OnPropertyChanged(nameof(StartDate));

				ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));
                if (EndDate < StartDate)
                {
                    AddError(nameof(StartDate), "The start date cannot be after the end date");
                }

			}
		}
		private DateTime _endDate=new DateTime(2021,1,8);
        private readonly Func<ViewModelBase> createViewModel;

        

        public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));
                if (EndDate < StartDate)
                {
                    AddError(nameof(EndDate), "The end date cannot be before the start date");
                }


            }
        }

        private void AddError(string propertyName, string endDateErrors)
        {
			if (!_propertyNameToErrorDictionary.ContainsKey(propertyName))
			{
				_propertyNameToErrorDictionary.Add(propertyName, new List<string>());
			}
			_propertyNameToErrorDictionary[propertyName].Add(endDateErrors);
			OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyname)
        {
            _propertyNameToErrorDictionary.Remove(propertyname);
            OnErrorsChanged(propertyname);
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		private readonly Dictionary<string, List<string>> _propertyNameToErrorDictionary=new Dictionary<string, List<string>>();
		public bool HasErrors => _propertyNameToErrorDictionary.Any();

        public MakeReservationViewModel(HotelStore hotelStore, Services.NavigationService<ReservationListingViewModel> reservationViewNavigationSerive)
        {
			SubmitCommand = new MakeReservationCommand(this,hotelStore,reservationViewNavigationSerive);
			CancelCommand = new NavigateCommand<ReservationListingViewModel>(reservationViewNavigationSerive);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
			return _propertyNameToErrorDictionary.GetValueOrDefault(propertyName, new List<string>());
        }
    }
}
