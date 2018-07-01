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
	public partial class NewNotePage : ContentPage
	{
		public NewNotePage ()
		{
			InitializeComponent ();
		}

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDetail.Text)||string.IsNullOrEmpty(txtTitle.Text))
            {
                await DisplayAlert("Ops!", "Fill in the blanks...", "Ok");
            }
            else
            {
                var result = App.Database.AddAsync(new Note()
                {
                    Title = txtTitle.Text,
                    NoteDetail = txtDetail.Text
                });
                await App.Database.SaveChangesAsync();
                if (result.IsCompleted)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "The note could not be added!", "Ok");
                }
            }
        }
    }
}