using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Opgave
{
    class PrinterJob
    {
        private string fileName;
        private string fileType;
        private int fileSize;

        // Tom constructor
        public PrinterJob() { }
        
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                this.fileName = value;
            }
        }
        public string FileType
        {
            get
            {
                return fileType;
            }
            set
            {
                this.fileType = value;
            }
        }
        public int FileSize
        {
            get
            {
                return fileSize;
            }
            set
            {
                this.fileSize = value;
            }
        }
    }

}
