using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename.Lib
{
    public class RecentFileItem
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class RecentFileConfig
    {
        public string Path;
        public int MaxItem;
    }

    public class RecentFileService
    {
        private IPersister _persister;
        private RecentFileConfig _config;

        public RecentFileService(RecentFileConfig config)
        {
            _config = config;
            _persister = new JsonPersister();
        }

        public List<RecentFileItem> GetRecentFiles()
        {
            try
            {
                List<RecentFileItem> recentFiles = (List<RecentFileItem>)_persister.Load(_config.Path);
                return recentFiles == null ? new List<RecentFileItem>() : recentFiles;
            }
            catch
            {
                return new List<RecentFileItem>();
            }
        }

        public void AddRecent(RecentFileItem recentFile)
        {
            List<RecentFileItem> recentFiles = GetRecentFiles();

            if (recentFiles.Count >= _config.MaxItem)
                recentFiles.RemoveAt(0);
            recentFiles.Add(recentFile);

            _persister.Save(_config.Path, recentFiles);
        }

        public void RemoveRecent(string path)
        {
            List<RecentFileItem> recentFiles = GetRecentFiles();
            recentFiles.RemoveAll(f => f.Path == path);
            _persister.Save(_config.Path, recentFiles);
        }
    }
}
