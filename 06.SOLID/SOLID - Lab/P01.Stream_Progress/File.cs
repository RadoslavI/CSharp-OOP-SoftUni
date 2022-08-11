namespace P01.Stream_Progress
{
    public class File : IFile
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
