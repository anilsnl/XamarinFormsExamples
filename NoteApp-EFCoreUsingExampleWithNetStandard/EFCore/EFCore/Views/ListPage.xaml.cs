using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EFCore.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstNotes.ItemsSource = App.Database.Notes.OrderBy(a => a.Title).ToList();

        }

        private async void btnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNotePage());
        }

        private async void lstNotes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (Note)e.SelectedItem;
            var lst = (ListView)sender;
            lst.SelectedItem = null;
            await DisplayAlert(selected.Title, selected.NoteDetail, "Ok");
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var id = (int)item.CommandParameter;
            var isOk = await DisplayAlert("Delete?", "Are you sure you wanna delete the note!" + id.ToString(), "Yes,Delete!", "No");
            if (isOk)
            {
                var note = await App.Database.Notes.FindAsync(id);
                if(note!=null)
                {
                    App.Database.Notes.Remove(note);
                    var result= await App.Database.SaveChangesAsync();
                    if (result>0)
                    {
                        await DisplayAlert("Result", "The note has beeen deleted!", "OK");
                        lstNotes.ItemsSource = await App.Database.Notes.OrderBy(a => a.Title).ToListAsync();
                    }
                }
            }
        }
    }
}