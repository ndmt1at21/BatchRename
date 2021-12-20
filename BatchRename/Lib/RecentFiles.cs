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

    public class RecentFileItems
    {
        public List<RecentFileItem> Items { get; set; }

        public RecentFileItems()
        {
            Items = new List<RecentFileItem>();
        }
    }

    public class RecentFileConfig
    {
        public string Path;
        public int MaxItem;
    }

    public class RecentFileService
    {
        private IPersister<RecentFileItems> _persister;
        private RecentFileConfig _config;

        public RecentFileService(RecentFileConfig config)
        {
            _config = config;
            _persister = new JsonPersister<RecentFileItems>();
        }

        public RecentFileItems GetRecentFiles()
        {
            try
            {
                RecentFileItems recentFiles = _persister.Load(_config.Path);
                return recentFiles == null ? new RecentFileItems() : recentFiles;
            }
            catch
            {
                return new RecentFileItems();
            }
        }

        public void AddRecent(RecentFileItem recentFile)
        {
            RecentFileItems recentFiles = GetRecentFiles();

            if (recentFiles.Items.Count >= _config.MaxItem)
                recentFiles.Items.RemoveAt(0);
            recentFiles.Items.Add(recentFile);

            _persister.Save(_config.Path, recentFiles);
        }

        public void RemoveRecent(string path)
        {
            RecentFileItems recentFiles = GetRecentFiles();
            recentFiles.Items.RemoveAll(f => f.Path == path);
            _persister.Save(_config.Path, recentFiles);
        }
    }
}
