namespace MauiFilePickerSample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var result = await FilePicker.PickAsync(new PickOptions
		{
			PickerTitle = "Pick Image Please",
			FileTypes = FilePickerFileType.Images
		});

		if (result == null)
			return;

		var stream = await result.OpenReadAsync();

		myImage.Source = ImageSource.FromStream(() => stream);
	}

	private async void PickImages_Clicked(object sender, EventArgs e)
	{
		// For custom file types            
		//var customFileType =
		//	new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
		//	{
		//		 { DevicePlatform.iOS, new[] { "com.adobe.pdf" } }, // or general UTType values
		//       { DevicePlatform.Android, new[] { "application/pdf" } },
		//		 { DevicePlatform.WinUI, new[] { ".pdf" } },
		//		 { DevicePlatform.Tizen, new[] { "*/*" } },
		//		 { DevicePlatform.macOS, new[] { "pdf"} }, // or general UTType values
		//	});

		var results = await FilePicker.PickMultipleAsync(new PickOptions
		{
			//FileTypes = customFileType
        });

		foreach (var result in results)
		{
			await DisplayAlert("You picked...", result.FileName, "OK");
		}
    }
}

