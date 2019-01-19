namespace Sound
{
    public class EventCbCookie
    {
        public string soundItem;
        public Step nextStep;
        public bool isIntro;
        public string musicToPlay;

        public EventCbCookie(string soundItem, Step nextStep, bool isIntro = true, string musicToPlay = null)
        {
            this.soundItem = soundItem;
            this.nextStep = nextStep;
            this.isIntro = isIntro;
            this.musicToPlay = musicToPlay;
        }
    }
}