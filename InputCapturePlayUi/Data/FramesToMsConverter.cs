namespace InputCapturePlayUi.Data
{
    public interface IFramesToMsConverter
    {
        int ConvertFramesToMs(int frames); 
    }

    public class FramesToMsConverter60fps : IFramesToMsConverter
    {
        public int ConvertFramesToMs(int frames)
        {
            return frames * 16; 
        }
    }

    public class FramesToMsConverter30fps: IFramesToMsConverter
    {
        public int ConvertFramesToMs(int frames)
        {
            return frames * 33; 
        }
    }
}
