namespace NasaConsumer.Models
{
    public class PicOfTheDayViewModel
    {
        public string Copyright { get; set; }

        public DateTime Date { get; set; }

        public string Explanation { get; set; }

        public string Title { get; set; }

        public Uri Url { get; set; }
    }
}