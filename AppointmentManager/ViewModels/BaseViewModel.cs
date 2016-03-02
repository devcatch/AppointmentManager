using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppointmentManager
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool SetProperty<T> (ref T storage, T value, [CallerMemberName] String propertyName = null)
		{
			if (object.Equals (storage, value))
				return false;

			storage = value;
			OnPropertyChanged (propertyName);
			return true;
		}

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}

		bool _inactive = true;

		public bool Inactive { 
			get { 
				return _inactive;
			} 
			set {
				if (_inactive != value) {
					_inactive = value;
					ChangeCanExecute ();
					OnPropertyChanged ();
				}
			}
		}

		public virtual void ChangeCanExecute ()
		{

		}
	}
}

