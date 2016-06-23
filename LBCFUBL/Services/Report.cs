using Novacode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LBCFUBL.Services
{
    public abstract class Report
    {
        protected DateTime from;
        protected DateTime to;

        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string MimeType { get; private set; } = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        protected Report(string filename, string ext, DateTime? from, DateTime? to)
        {
            if (null != from && null != to && to < from)
            {
                DateTime? t = from;
                from = to;
                to = t;
            }

            this.from = (DateTime) from;
            this.to = (DateTime) to;

            string dir = @"C:\ProgramData\LBCFUBL\Reports";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (null != from && null != to)
                FileName = string.Format("{0}_{1}_{2}.{3}", filename, this.from.ToString("dd-MM-yyyy"), this.to.ToString("dd-MM-yyyy"), ext);
            else
                FileName = string.Format("{0}.{1}", filename, ext);
            FilePath = dir + @"\" + FileName;
        }
    }
}