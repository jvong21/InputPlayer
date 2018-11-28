namespace InputCapturePlayUi.Data
{
    public interface IFramesToMsConverter
    {
        int ConvertFramesToMs(int frames);
        int ConvertMsToFrames(int frames);
    }

    public class FramesToMsConverter60fps : IFramesToMsConverter
    {
        public int ConvertFramesToMs(int frames)
        {
            return frames * 16; 
        }

        public int ConvertMsToFrames(int ms)
        {
            return ms / 16; 
        }
    }

    public class FramesToMsConverter30fps: IFramesToMsConverter
    {
        public int ConvertFramesToMs(int frames)
        {
            return frames * 33; 
        }

        public int ConvertMsToFrames(int ms)
        {
            return ms / 33;
        }
    }
}
