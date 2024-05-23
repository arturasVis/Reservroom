using Reservoom.Exeptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    internal class MakeReservationCommand : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly NavigationService navigationService;
        private readonly MakeReservationViewModel _model;
        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,Hotel hotel,NavigationService navigationService)
        {
            _hotel = hotel;
            this.navigationService = navigationService;
            _model = makeReservationViewModel;
            _model.PropertyChanged += OnViewModelPropertyChanged;
        }

       
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty( _model.UserName) && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_model.FloorNumber,_model.RoomNumber),
                _model.StartDate,
                _model.EndDate,
                _model.UserName
                );
           

            try
            {
                _hotel.MakeReservatio(reservation);
                MessageBox.Show("Room has been reserved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                navigationService.Navigate();

            }
            catch (ReservationConflictExeption)
            {

                MessageBox.Show("Room is already taken","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.UserName))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
