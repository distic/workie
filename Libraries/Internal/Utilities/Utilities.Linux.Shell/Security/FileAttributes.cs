namespace Utilities.Linux.Shell.Security
{
    public class FileAttributes
    {
        public bool Read { get; set; }

        public bool Write { get; set; }

        public bool Execute { get; set; }

        public string AttributeString
        {
            get
            {
                var attrib = "";

                if (Read)
                {
                    attrib += "r";
                }

                if (Write)
                {
                    attrib += "w";
                }

                if (Execute)
                {
                    attrib += "x";
                }

                return attrib;
            }
        }

        public bool HasAnyTrue { get { return Read || Write || Execute; } }
    }
}
