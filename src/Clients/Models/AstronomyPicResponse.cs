namespace NasaConsumer.Clients.Models
{
    public class AstronomyPicResponse
    {
        public AstronomyPicResponse()
        {
            this.AstronomyPics = new List<AstronomyPic>();
        }

        public IEnumerable<AstronomyPic> AstronomyPics { get; set; }
    }
}

