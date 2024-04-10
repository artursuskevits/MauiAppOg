namespace MauiAppOg;

public partial class Failjob : ContentPage
{
    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	public Failjob()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateFilesList();
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        string fileName = fileNameEntry.Text;
        if (String.IsNullOrEmpty(fileName)) { return; }
        if (File.Exists(Path.Combine(folderPath,fileName)))
        {
            bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas Kas Taha Ümber Kirjutada?", "jah", "ei");
            if (isRewrited==false)
            {
                return;
            }
            
        }
        File.WriteAllText(Path.Combine(folderPath, fileName), textEditor.Text);
        UpdateFilesList();
    }

    private void UpdateFilesList() 
    {
        filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
        filesList.SelectedItem = null;
    }
    private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) { return; }
        string fileName = e.SelectedItem.ToString();
        textEditor.Text = File.ReadAllText(Path.Combine(folderPath, fileName));
        fileNameEntry.Text = fileName;
        filesList.SelectedItem = null;
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        string fileName = (string)((MenuItem)sender).BindingContext;
        File.Delete(Path.Combine(folderPath, fileName));
        UpdateFilesList();
    }

    private void ToList_Clicked(object sender, EventArgs e)
    {
        string fileName = (string)((MenuItem)sender).BindingContext;
        List<string> list = File.ReadLines(Path.Combine(folderPath, fileName)).ToList();
        listFailist.ItemsSource = list;
    }
}