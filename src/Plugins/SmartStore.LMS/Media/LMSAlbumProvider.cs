using SmartStore.Core.Domain.Media;
using SmartStore.Data.Utilities;
using SmartStore.LMS.Data;
using SmartStore.LMS.Domain;
using SmartStore.Services.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartStore.LMS.Media
{
    public class LMSAlbumProvider : IAlbumProvider, IMediaTrackDetector
    {
        public const string Name = "LMS";

        private readonly LMSObjectContext _dbContext;

        public LMSAlbumProvider(LMSObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MediaAlbum> GetAlbums()
        {
            yield return new MediaAlbum { Name = Name, ResKey = "Plugins.FriendlyName.SmartStore.LMS", CanDetectTracks = true };
        }

        public AlbumDisplayHint GetDisplayHint(MediaAlbum album)
        {
            return null;
        }

        public void ConfigureTracks(string albumName, TrackedMediaPropertyTable table)
        {
            table.Register<LMSRecord>(x => x.PictureId);
        }

        public IEnumerable<MediaTrack> DetectAllTracks(string albumName)
        {
            var ctx = _dbContext;
            var name = nameof(LMSRecord);
            var p = new FastPager<LMSRecord>(ctx.Set<LMSRecord>().AsNoTracking().Where(x => x.PictureId > 0));
            while (p.ReadNextPage(x => new { x.Id, x.PictureId }, x => x.Id, out var list))
            {
                foreach (var x in list)
                {
                    yield return new MediaTrack { EntityId = x.Id, EntityName = name, MediaFileId = x.PictureId, Property = nameof(x.PictureId) };
                }
            }
        }
    }
}