using Xamarin.Forms;
using System.Windows.Input;

namespace AppointmentManager.Controls
{
	/// <summary>
	/// List view with command. XF's ListView have terrible mechanism for callback
	/// </summary>
	public class ListViewWithCommand : ListView
	{
		public ListViewWithCommand ()
		{
			ItemTapped += DoItemTaped;
		}

		/// <summary>
		/// The bindable property for callback command.
		/// </summary>
		public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<ListViewWithCommand, ICommand> (x => x.ItemClickCommand, null);

		public ICommand ItemClickCommand {
			get { return (ICommand)GetValue (ItemClickCommandProperty); }
			set { SetValue (ItemClickCommandProperty, value); }
		}

		/// <summary>
		/// Reaction for ItemTapped.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void DoItemTaped (object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && ItemClickCommand != null) {
				ItemClickCommand.Execute (e.Item);
				SelectedItem = null;
			}
		}
	}
}


