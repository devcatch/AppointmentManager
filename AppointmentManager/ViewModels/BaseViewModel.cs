using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppointmentManager
{
	/// <summary>
	/// Base view model. Realisation INotifyPropertyChanged interface.
	/// </summary>
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

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AppointmentManager.BaseViewModel"/> is inactive.
		/// </summary>
		/// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
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

		/// <summary>
		/// Changes the can execute. Should be overridden in inherited classes;
		/// </summary>
		public virtual void ChangeCanExecute ()
		{

		}
	}
}

