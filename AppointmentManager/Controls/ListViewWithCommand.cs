using Xamarin.Forms;
using System.Windows.Input;

namespace AppointmentManager.Controls
{
	public class ListViewWithCommand : ListView
	{
		public ListViewWithCommand ()
		{
			ItemTapped += DoItemTaped;
		}

		public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<ListViewWithCommand, ICommand> (x => x.ItemClickCommand, null);

		public ICommand ItemClickCommand {
			get { return (ICommand)GetValue (ItemClickCommandProperty); }
			set { SetValue (ItemClickCommandProperty, value); }
		}

		void DoItemTaped (object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && ItemClickCommand != null) {
				ItemClickCommand.Execute (e.Item);
				SelectedItem = null;
			}
		}
	}
}


