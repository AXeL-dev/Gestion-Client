using System;
using System.Diagnostics;
using System.IO;

namespace GestionClient
{
    /// <summary>
    /// Wrapper for the WinRar compression and uncompression command line tools.
    /// </summary>
    class WinRar : IDisposable
    {
        private readonly Process _process = new Process();

        public string RarPath { get; set; }
        public string UnrarPath { get; set; }

        /// <summary>
        /// Creates a new instance using provided or available WinRar command line tools.
        /// </summary>
        /// <param name="rarPath">Path for WinRar compression command line tool (Rar). </param>
        /// <param name="unrarPath">Path for WinRar uncompression command line tool (Unrar).</param>
        public WinRar(string rarPath = null, string unrarPath = null)
        {
            if (rarPath == null)
            {
                this.RarPath = @"C:\Program Files\WinRAR\rar.exe";
            }
            if (unrarPath == null)
            {
                this.UnrarPath = @"C:\Program Files\WinRAR\unrar.exe";
            }
            if (!File.Exists(this.RarPath))
            {
                throw new IOException("Rar compression command line tool not found.");
            }
            if (!File.Exists(this.UnrarPath))
            {
                throw new IOException("Unrar uncompression command line tool not found.");
            }
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Creates an archive of compressed file or directory.
        /// </summary>
        /// <param name="archiveFilePath">Path for the archive to create.</param>
        /// <param name="sourceFilesPath">Path of the file or directory to compress.</param>
        public void Compress(string archiveFilePath, string sourceFilesPath)
        {
            _process.StartInfo.FileName = RarPath;
            _process.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"",
                archiveFilePath, sourceFilesPath);
            _process.Start();
            _process.WaitForExit();
        }

        /// <summary>
        /// Extracts an archive in a destination path.
        /// </summary>
        /// <param name="archiveFilePath">Path for archive to extract.</param>
        /// <param name="destinationPath">Path for saving the extracted files.</param>
        public void Extract(string archiveFilePath, string destinationPath)
        {
            _process.StartInfo.FileName = UnrarPath;
            _process.StartInfo.Arguments = String.Format("x \"{0}\" \"{1}\"",
                archiveFilePath, destinationPath);
            _process.Start();
            _process.WaitForExit();
        }

        #region IDisposable-Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_process != null)
                {
                    _process.Close();
                }
            }
        }
        #endregion
    }
}
