using MyFirstMobileApp.Models.Entities;

namespace MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit;

public partial class EditCollectionView : ContentPage
{
	public EditCollectionView(StarWarsMovies sw)
	{
		InitializeComponent();
		BindingContext = new EditCollectionViewModel();
		MovieTitle.Text = sw.NameOfMovie;
	}
}