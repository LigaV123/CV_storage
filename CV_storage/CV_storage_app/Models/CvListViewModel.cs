namespace CV_storage_app.Models
{
    public class CvListViewModel
    {
        public CvListViewModel()
        {
            CvItems = new List<CvItemViewModel>();
        }

        public List<CvItemViewModel> CvItems { get; set; }
    }
}
