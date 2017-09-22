using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.MusicStore.Models
{
    public class Album:BaseEntity
    {
        [DisplayName("")]
        public virtual int GenreId { get; set; }
        [DisplayName("")]
        public virtual int ArtistId { get; set; }
        [DisplayName("标题")]
        public virtual string Title { get; set; }
        [DisplayName("价格")]
        public virtual decimal Price { get; set; }
        [DisplayName("连接")]
        public virtual string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
