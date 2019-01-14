namespace Sound
{
    public class EventCbCookie
    {
        public bool isIntro;
        public string musicToPlay;

        public EventCbCookie(bool isIntro = true, string musicToPlay = null)
        {
            this.isIntro = isIntro;
            this.musicToPlay = musicToPlay;
        }
    }
}